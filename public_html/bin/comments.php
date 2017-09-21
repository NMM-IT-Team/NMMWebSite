<?php
// define variables and set to empty values
$nameErr =  "";
$name =  $comment ="";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
  if (empty($_POST["name"])) {
    $nameErr = "Name is required";
  } else {
    $name = test_input($_POST["name"]);
  }

  

  if (empty($_POST["message"])) {
    $comment = "";
  } else {
    $comment = test_input($_POST["message"]);
  }

  
?>