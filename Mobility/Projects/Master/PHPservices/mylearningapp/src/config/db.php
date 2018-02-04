<?php
class db{
    // properties
    private $dbHost = 'localhost';
    private $dbUser = 'root';
    private $dbPass = 'root';
    private $dbName = 'Northwind';

//Connect
public function connect(){
    $mysql_connect_str = "mysql:host=$this->dbHost;dbname=$this->dbName;";
    $dbConnection = new PDO($mysql_connect_str,$this->dbUser,$this->dbPass);
    $dbConnection->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
    return $dbConnection;
}

}