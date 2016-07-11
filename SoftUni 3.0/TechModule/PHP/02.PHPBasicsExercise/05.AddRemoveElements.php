<html>
<head>
</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="commands"></textarea>
    <input type="submit">
</form>
</body>
</html>

<?php
if (isset($_GET['commands']) && isset($_GET['delimiter'])) {
    $arrayKeyValues = str_replace($_GET['delimiter'], "\n", $_GET['commands']);
    $arrayKeyValues = array_map("trim", explode("\n", $arrayKeyValues));
    $array = array();

    for ($i = 0; $i < count($arrayKeyValues); $i += 2) {
        $command = $arrayKeyValues[$i];
        $value = $arrayKeyValues[$i + 1];
        if ($command == 'add') {
            array_push($array, $value);
        } else {
            unset($array[$value]);
            $array = array_values($array);
        }
    }

    for ($i = 0; $i < count($array); $i++) {
        echo $array[$i] . '<br>';
    }
}
?>
