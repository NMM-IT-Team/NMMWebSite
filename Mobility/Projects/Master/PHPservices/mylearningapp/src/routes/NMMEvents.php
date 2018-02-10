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

function UploadImages(Request $request, Response $response)
{
    /* TODO
     * create sepearate folder for seperate event with eventId
     * make sure the size of any the image uploaded is not more than 1MB even before you upload the image
     * save the path of the destination folder along with the image name and extension
     * clean up unwanted code
     */
    $directory = $_SERVER['DOCUMENT_ROOT'] . '/mylearningapp/uploads/';
    $uploadedFiles = $request->getUploadedFiles();
    $uploadedFileArray = $uploadedFiles['EventImages'];

    foreach ($uploadedFileArray as $keyIndex => $fileName) {

        if ($fileName->getError() === UPLOAD_ERR_OK) {
            $userFileName = $fileName->getClientFileName();
            $fileName->moveTo($directory . $userFileName);
            $response->write('uploaded ' . $directory . $userFileName . '<br/>');
            //database operation based on the event id
            InsertImageInDatabase($directory . $userFileName);
        }
    }
}

function InsertImageInDatabase($imagePath)
{
    try {
        $db = new db();
        $db = $db->connect();

        $sqlProcedure = 'CALL uspInsertPhoto(:EventId,:Imagepath)';
        //TODO: get this dynamically
        $eventId = 1;
        $stmt = $db->prepare($sqlProcedure);
        $stmt->bindParam(':EventId', $eventId, PDO::PARAM_INT);
        $stmt->bindParam(':Imagepath', $imagePath, PDO::PARAM_STR);

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
    $eventIsActive = $request->getParam('IsActive');
    $eventCreatedOn = $request->getParam('CreatedOn');
    $eventModifiedOn = $request->getParam('ModifiedOn');

    $sql = "INSERT INTO Event (Name, Description, IsCommercial, Cost, Location,
        Event_Date, Venu_Name, PhotoId, IsActive, CreatedOn, ModifiedOn)
        VALUES (:Name, :Description, :IsCommercial, :Cost, :Location,
        :Date, :Venu_Name, :PhotoId, :IsActive, :CreatedOn, :ModifiedOn)";
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

        $stmt->bindParam(':IsActive', $eventIsActive);
        $stmt->bindParam(':CreatedOn', $eventCreatedOn);
        $stmt->bindParam(':ModifiedOn', $eventModifiedOn);

        $stmt->execute();
        echo '{ "Message":{"text":Data added}}';
        $db = null;

        //Start uploading images here
        UploadImages($request, $response);

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
    $id = $request->getAttribute('id');
    $sql = "SELECT * FROM Event";
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
