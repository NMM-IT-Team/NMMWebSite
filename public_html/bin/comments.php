
<?php
// define variables and set to empty values
$name =  $comments = "";

if ($_SERVER["REQUEST_METHOD"] == "POST") {
  $name = test_input($_POST["name"]);
  //$email = test_input($_POST["email"]);
  //$website = test_input($_POST["website"]);
  $comments = test_input($_POST["comment"]);
  //$gender = test_input($_POST["gender"]);
}

function test_input($data) {
  $data = trim($data);
  $data = stripslashes($data);
  $data = htmlspecialchars($data);
  return $data;
}
?>




