<?php

use \Psr\Http\Message\ResponseInterface as Response;
use \Psr\Http\Message\ServerRequestInterface as Request;

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

    $sql = "INSERT INTO Event (Name, Description, IsCommercial, Cost, Location,
        Event_Date, Venu_Name, IsActive, CreatedOn, ModifiedOn)
        VALUES (:Name, :Description, :IsCommercial, :Cost, :Location,
        :Date, :Venu_Name, :IsActive, :CreatedOn, :ModifiedOn);";
    try {
        $db = new db();
        $db = $db->connect();
        $stmt = $db->prepare($sql);
        $stmt->bindParam(':Name', $eventName);
        $stmt->bindParam(':Description', $eventDescription);
        $stmt->bindParam(':IsCommercial', $eventIsCommercial);
        $stmt->bindParam(':Cost', $eventCost);

        $stmt->bindParam(':Location', $eventLocation);
        $stmt->bindParam(':Date', $eventDate);
        $stmt->bindParam(':Venu_Name', $eventVenuName);

        $eventActive = 1;
        $stmt->bindParam(':IsActive', $eventActive);

        $createdDateTime = date("m/d/Y h:i:sa");
//TODO: Created date is always null :(
        $stmt->bindParam(':CreatedOn', $createdDateTime);
        $stmt->bindParam(':ModifiedOn', $createdDateTime);

        $stmt->execute();
        $insertedEventId = $db->lastInsertId();
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
        $sqlProcedure = 'CALL sp_getEvents';
        $db = new db();
        $db = $db->connect();
        $stmt = $db->prepare($sqlProcedure);
        $stmt->execute();
        $eventData = $stmt->fetchAll(PDO::FETCH_OBJ);
        $db = null;
        /* TODO: Items
        Iterate throw the folder in the rootpath and create an array of image path
        Return the JSON
         * */
        echo json_encode($eventData);
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
