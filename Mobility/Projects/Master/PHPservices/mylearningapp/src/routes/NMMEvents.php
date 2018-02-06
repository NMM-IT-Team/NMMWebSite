    <?php
        use \Psr\Http\Message\ServerRequestInterface as Request;
        use \Psr\Http\Message\ResponseInterface as Response;
        
        $app = new \Slim\App;

    //Add event record in the db
    $app->post('/api/events/add',function(Request $request,Response $response){

        //Photo Id will be passed as 0 and then will be updated once photos are stored
        $eventName = $request->getParam('Name');
        $eventDescription = $request->getParam('Description');
        $eventIsCommercial = $request->getParam('IsCommercial');
        $eventCost = $request->getParam('Cost');
        $eventLocation = $request->getParam('Location');
        $eventDate = $request->getParam('Date');
        $eventVenuName = $request->getParam('VenuName');
        $eventPhotoId = $request->getParam('PhotoId');
        $eventIsActive = $request->getParam('IsActive');
        $eventCreatedOn = $request->getParam('CreatedOn');
        $eventModifiedOn = $request->getParam('ModifiedOn');

        $sql = "INSERT INTO Event (Name, Description, IsCommercial, Cost, Location, 
        Event_Date, Venu_Name, PhotoId, IsActive, CreatedOn, ModifiedOn) 
        VALUES (:Name, :Description, :IsCommercial, :Cost, :Location, 
        :Date, :Venu_Name, :PhotoId, :IsActive, :CreatedOn, :ModifiedOn)";
    try{
    $db = new db();
    $db = $db->connect();
    $stmt = $db->prepare($sql);
    $stmt->bindParam(':Name',$eventName);
    $stmt->bindParam(':Description',$eventDescription);
    $stmt->bindParam(':IsCommercial',$eventIsCommercial);
    $stmt->bindParam(':Cost',$eventCost);

    $stmt->bindParam(':Location',$eventLocation);
    $stmt->bindParam(':Date',$eventDate);
    $stmt->bindParam(':Venu_Name',$eventVenuName);
    $stmt->bindParam(':PhotoId',$eventPhotoId);

    $stmt->bindParam(':IsActive',$eventIsActive);
    $stmt->bindParam(':CreatedOn',$eventCreatedOn);
    $stmt->bindParam(':ModifiedOn',$eventModifiedOn);
    
    $stmt->execute();
    echo '{ "Message":{"text":Data added}}';
    $db = null;

    }catch(PDOException $exception){
    echo'{"error":{"text":'.$exception->getMessage().'}';
    }
    });

    //get event details by id
    $app->get('/api/events/{id}',function(Request $request,Response $response){
        $id = $request->getAttribute('id');
        $sql = "SELECT * FROM Event WHERE Id = $id";
    try{
    $db = new db();
    $db = $db->connect();
    $stmt = $db->query($sql);
    $eventData = $stmt->fetchAll(PDO::FETCH_OBJ);
    $db = null;
    echo json_encode($eventData);
    }
    catch(PDOException $exception){
    echo'{"error":{"text":'.$exception->getMessage().'}';
    }
    });

        //get all event details
        $app->get('/api/events',function(Request $request,Response $response){
            $id = $request->getAttribute('id');
            $sql = "SELECT * FROM Event";
        try{
        $db = new db();
        $db = $db->connect();
        $stmt = $db->query($sql);
        $eventData = $stmt->fetchAll(PDO::FETCH_OBJ);
        $db = null;
        echo json_encode($eventData);
        }
        catch(PDOException $exception){
        echo'{"error":{"text":'.$exception->getMessage().'}';
        }
        });

                //delete event by id
                $app->get('/api/events/delete/{id}',function(Request $request,Response $response){
                    $id = $request->getAttribute('id');
                    $sql = "Delete FROM Event where id=$id";
                try{
                $db = new db();
                $db = $db->connect();
                $stmt = $db->prepare($sql);
                $eventData = $stmt->execute();
                $db = null;
                echo json_encode($eventData);
                }
                catch(PDOException $exception){
                echo'{"error":{"text":'.$exception->getMessage().'}';
                }
                });