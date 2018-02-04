    <?php
    use \Psr\Http\Message\ServerRequestInterface as Request;
    use \Psr\Http\Message\ResponseInterface as Response;
    
    $app = new \Slim\App;

    // get all customer
    $app->get('/api/customers',function(Request $request,Response $response){

        $sql = "SELECT * FROM customerInfo";
    try{

    $db = new db();
    $db = $db->connect();
    $stmt = $db->query($sql);

    $customerData = $stmt->fetchAll(PDO::FETCH_OBJ);
    $db = null;

    echo json_encode($customerData);
    }catch(PDOException $exception){
    echo'{"error":{"text":'.$exception->getMessage().'}';
    }
    });

    //Get Single Customer
    $app->get('/api/customer/{id}',function(Request $request,Response $response){

        $id = $request->getAttribute('id');
        $sql = "SELECT * FROM customerInfo WHERE Id = $id";
    try{
    $db = new db();
    $db = $db->connect();
    $stmt = $db->query($sql);

    $customerData = $stmt->fetchAll(PDO::FETCH_OBJ);
    $db = null;

    echo json_encode($customerData);
    }catch(PDOException $exception){
    echo'{"error":{"text":'.$exception->getMessage().'}';
    }
    });

    //Add customer record in the db
    $app->post('/api/customer/add',function(Request $request,Response $response){

        $id = $request->getParam('customer_Id');
        $customer_name = $request->getParam('customer_Name');
        $sql = "INSERT INTO customerInfo (Id,Name) VALUES (:customer_Id,:customer_Name)";
    try{
    $db = new db();
    $db = $db->connect();
    $stmt = $db->prepare($sql);
    $stmt->bindParam(':customer_Id',$id);
    $stmt->bindParam(':customer_Name',$customer_name);

    $stmt->execute();
    echo '{ "Message":{"text":Data added}}';
    $db = null;

    }catch(PDOException $exception){
    echo'{"error":{"text":'.$exception->getMessage().'}';
    }
    });

    //Update customer record in the db
    $app->post('/api/customer/update/{id}',function(Request $request,Response $response){
        $id = $request->getAttribute('customer_Id');

        $id = $request->getParam('customer_Id');
        $customer_name = $request->getParam('customer_Name');
        $sql = "INSERT INTO customerInfo (Id,Name) VALUES (:customer_Id,:customer_Name)";
    try{
    $db = new db();
    $db = $db->connect();
    $stmt = $db->prepare($sql);
    $stmt->bindParam(':customer_Id',$id);
    $stmt->bindParam(':customer_Name',$customer_name);

    $stmt->execute();
    echo '{ "Message":{"text":Data added}}';
    $db = null;

    }catch(PDOException $exception){
    echo'{"error":{"text":'.$exception->getMessage().'}';
    }
    });