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

$sqlDeaths = "TRUNCATE TABLE `Deaths`";
$sqlDefeats = "TRUNCATE TABLE `Defeats`";
$sqlHits = "TRUNCATE TABLE `Hits`";
$sqlPositions = "TRUNCATE TABLE `Positions`";

$conn->query($sqlDeaths);
$conn->query($sqlDefeats);
$conn->query($sqlHits);
$conn->query($sqlPositions);

echo "Truncated all tables";

?>