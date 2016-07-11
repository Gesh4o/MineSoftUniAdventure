<html>
<head>

</head>
<body>
<form>
    Input:
    <br>
    <textarea name="input"></textarea>
    <br>
    Delimiter:
    <br>
    <input type="text" name="delimiter">
    <br>
    <input type="submit">
</form>
</body>
</html>

<?php
if (isset($_GET['input']) && isset($_GET['delimiter'])) {
    $array = array();
    $inputLines = explode("\n", $_GET['input']);
    $delimiter = $_GET['delimiter'];
    for ($i = 0; $i < count($inputLines); $i++) {
        $lineArgs = explode($delimiter, $inputLines[$i]);

        $array[$i] = (object)[
            'name' => $lineArgs[0],
            'age' => intval($lineArgs[1]),
            'grade' => floatval($lineArgs[2]),
        ];
    }

    for ($i = 0; $i < count($array); $i++) {
        echo "<ul>";

        echo "<li>Name: ";
        echo $array[$i]->name;
        echo "</li>";


        echo "<li>Age: ";
        echo $array[$i]->age;
        echo "</li>";

        echo "<li>Grade: ";
        echo $array[$i]->grade;
        echo "</li>";

        echo "</ul>";
    }
}
?>