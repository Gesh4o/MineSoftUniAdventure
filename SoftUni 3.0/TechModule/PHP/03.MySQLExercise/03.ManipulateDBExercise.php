<?php
$hostname = 'localhost';
$username = 'root';
$password = '';
$dbname = 'blog';

$mysqli = new mysqli($hostname, $username, $password, $dbname);

if ($mysqli->connect_errno) {
    die("Failed to connect to SQL database!");
}
$mysqli->set_charset("utf8");

//function loadUsers($mysqli)
//{
//    $query = "SELECT * FROM users";
//    $result = $mysqli->query($query);
//    if (!$result) {
//        die('Failed to load query!');
//    }
//
//    if ($result->num_rows > 0) {
//        while ($row = $result->fetch_assoc()) {
//            echo "Id: " . htmlspecialchars($row['id']) . "<br>" .
//                "Username: " . htmlspecialchars($row['username']) . "<br>" .
//                "Full name: " . htmlspecialchars($row['fullname']) . "<br>";
//        }
//        return array($query, $result, $row);
//    } else {
//        echo "0 result";
//        return array($query, $result, $row);
//    }
//}
//
//function loadPosts($mysqli)
//{
//    $query = "SELECT * FROM posts";
//    $result = $mysqli->query($query);
//    if (!$result) {
//        die('Failed to load query!');
//    }
//
//    if ($result->num_rows > 0) {
//        while ($row = $result->fetch_assoc()) {
//            echo "Id: " . htmlspecialchars($row['id']) . "<br>" .
//                "Title: " . htmlspecialchars($row['title']) . "<br>" .
//                "Content: " . htmlspecialchars($row['content']) . "<br>" .
//                "Date: " . htmlspecialchars($row['date']) . "<br>";
//        }
//    } else {
//        echo "0 result";
//    }
//}


// list($query, $result, $row) = loadUsers($mysqli);
// loadPosts($mysqli);


$query = $mysqli->prepare("INSERT INTO users (username, password, fullname) VALUES (?,?,?)");
$name = "ges2";
$fullname = "Georgi";
$password = md5("Paro2la");
$query->bind_param("sss", $name,$password , $fullname);

$query->execute();

if($query->affected_rows == 1){
    echo "User created";
} else{
    echo "User creation failed";
}

?>