<?php

use \Psr\Http\Message\ResponseInterface as Response;
use \Psr\Http\Message\ServerRequestInterface as Request;
require '../models/NMMEventModel.php';

$container = $app->getContainer();

$configuration = [
    'settings' => [
        'displayErrorDetails' => true,
    ],
];
$errorConfigurations = new \Slim\Container($configuration);
$app = new \Slim\App($errorConfigurations);

function UploadImages(Request $request, $EventId)
{
    $directory = $_SERVER['DOCUMENT_ROOT'] . '/mylearningapp/uploads/';
    $uploadedFiles = $request->getUploadedFiles();
    $uploadedImageArray = $uploadedFiles['EventImages'];

    foreach ($uploadedImageArray as $keyIndex => $fileName) {

        if ($fileName->getError() === UPLOAD_ERR_OK) {
            // if directory is not present as per the event id then create the directory
            if (!file_exists($directory . $EventId)) {
                mkdir($directory . $EventId, 0755, true);
            }
            $userFileName = $fileName->getClientFileName();
            $directoryPath = $directory . $EventId . '/';
            $fileName->moveTo($directoryPath . $userFileName);
            InsertImageInDatabase($directoryPath, $directoryPath . $userFileName, $EventId);

        }
    }
}

function InsertImageInDatabase($rootFolderPath, $imagePath, $EventId)
{
    try {
        $db = new db();
        $db = $db->connect();

        $sqlProcedure = 'CALL uspInsertPhoto(:EventId,:Imagepath,:RootFolder)';
        $stmt = $db->prepare($sqlProcedure);
        $stmt->bindParam(':EventId', $EventId, PDO::PARAM_INT);
        $stmt->bindParam(':Imagepath', $imagePath, PDO::PARAM_STR);
        $stmt->bindParam(':RootFolder', $rootFolderPath, PDO::PARAM_STR);

        // execute the stored procedure
        $stmt->execute();
        $stmt->closeCursor();
        $db = null;
    } catch (PDOException $exception) {
        echo '{"error":{"text":' . $exception->getMessage() . '}';
    }
}

//Add event record in the db
$app->post('/api/events/add', function (Request $request, Response $response) {

    $eventName = $request->getParam('Name');
    $eventDescription = $request->getParam('Description');
    $eventIsCommercial = $request->getParam('IsCommercial');
    $eventCost = $request->getParam('Cost');
    $eventLocation = $request->getParam('Location');
    $eventDate = $request->getParam('Date');
    $eventVenuName = $request->getParam('VenuName');

    $sqlInsertStmt = 'INSERT INTO Event (Name, Description, IsCommercial, Cost, Location,Event_Date, Venu_Name, IsActive, CreatedOn, ModifiedOn)
    VALUES (:Name, :Description, :IsCommercial, :Cost, :Location,
    :Event_Date, :Venu_Name, 1, NOW(), NOW())';
    try {
        $db = new db();
        $db = $db->connect();
        $stmt = $db->prepare($sqlInsertStmt);
        $stmt->bindParam(':Name', $eventName);
        $stmt->bindParam(':Description', $eventDescription);
        $stmt->bindParam(':IsCommercial', $eventIsCommercial);
        $stmt->bindParam(':Cost', $eventCost);

        $stmt->bindParam(':Location', $eventLocation);
        $stmt->bindParam(':Event_Date', $eventDate);
        $stmt->bindParam(':Venu_Name', $eventVenuName);

        $stmt->execute();
        $insertedEventId = $db->lastInsertId();
        echo 'inserted id = ' . $insertedEventId;

        $db = null;

        UploadImages($request, $insertedEventId);

    } catch (PDOException $exception) {
        echo '{"error":{"text":' . $exception->getMessage() . '}';
    }
});

//get event details by id
$app->get('/api/events/{id}', function (Request $request, Response $response) {
    $id = $request->getAttribute('id');
    $sql = "SELECT * FROM Event WHERE Id = $id";
    try {
        $db = new db();
        $db = $db->connect();
        $stmt = $db->query($sql);
        $eventData = $stmt->fetchAll(PDO::FETCH_OBJ);
        $db = null;
        echo json_encode($eventData);
    } catch (PDOException $exception) {
        echo '{"error":{"text":' . $exception->getMessage() . '}';
    }
});

//get all event details
$app->get('/api/events', function (Request $request, Response $response) {
    try {
        $NMMEventObject[] = new NMMEvent();
        $sqlProcedure = 'CALL sp_getEvents';
        $db = new db();
        $db = $db->connect();
        $stmt = $db->prepare($sqlProcedure);
        $stmt->execute();
        $NMMEventObject = $stmt->fetchAll(PDO::FETCH_OBJ);
        $db = null;

        foreach ($NMMEventObject as $key => $value) {
            $scanned_directory = array_diff(scandir($value->RootFolder), array('..', '.'));
            $NMMEventObject[$key]->EventImages = $scanned_directory;
        }
        echo json_encode($NMMEventObject);
    } catch (PDOException $exception) {
        echo '{"error":{"text":' . $exception->getMessage() . '}';
    }
});

//delete event by id
$app->get('/api/events/delete/{id}', function (Request $request, Response $response) {
    $id = $request->getAttribute('id');
    $sql = "Delete FROM Event where id=$id";
    try {
        $db = new db();
        $db = $db->connect();
        $stmt = $db->prepare($sql);
        $eventData = $stmt->execute();
        $db = null;
        echo json_encode($eventData);
    } catch (PDOException $exception) {
        echo '{"error":{"text":' . $exception->getMessage() . '}';
    }
});

//get photos path by Id
$app->get('/api/eventsPhoto/{id}', function (Request $request, Response $response) {
    $id = $request->getAttribute('id');
    $sql = "SELECT photo.Id,photo.EventId,photo.ImagePath FROM Event_Photo photo where photo.EventId = $id and photo.IsActive = true";
    try {
        $db = new db();
        $db = $db->connect();
        $stmt = $db->query($sql);
        $eventPhotoData = $stmt->fetchAll(PDO::FETCH_OBJ);
        $db = null;
        echo json_encode($eventPhotoData);
    } catch (PDOException $exception) {
        echo '{"error":{"text":' . $exception->getMessage() . '}';
    }
});
