<?php
$servername = "localhost";
$username = "victormb3";
$password = "48076579r";
$dbname = "victormb3";

$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$PosX = $_POST["X"];
$PosY = $_POST["Y"];
$PosZ = $_POST["Z"];
$Time = $_POST["Time"];
$Type = $_POST["Type"];

$sql = "INSERT INTO `Hits` (pos_x, pos_y, pos_z, time, reason_of_hit) 
VALUES ('$PosX', '$PosY', '$PosZ', '$Time', '$Type')";

if ($conn->query($sql) === TRUE) {
  // return ID to Unity
  echo "Valid connection";

} else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();
?>