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
    $object = [];
    $inputLines = str_replace("\r", "", $_GET['input']);
    $inputLines = explode("\n", $inputLines);
    $delimiter = $_GET['delimiter'];
    for ($i = 0; $i < count($inputLines); $i++) {

        $lineArgs = explode($delimiter, $inputLines[$i]);
        echo $lineArgs[1] . " ";
        if (is_numeric($lineArgs[1])) {
            $object[$lineArgs[0]] = floatval($lineArgs[1]);
        } else {
            $object[$lineArgs[0]] = $lineArgs[1];
        }
    }

    echo json_encode((object)$object, JSON_UNESCAPED_SLASHES);
}
?>