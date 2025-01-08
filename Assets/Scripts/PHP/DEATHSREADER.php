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

$sql = "SELECT * FROM `Deaths`";
$result = $conn->query($sql);
$posts = $result->fetch_all(MYSQLI_ASSOC);

echo json_encode($posts);

?>