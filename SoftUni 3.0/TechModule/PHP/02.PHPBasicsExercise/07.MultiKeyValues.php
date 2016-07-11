<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="key-value-pairs"></textarea>
    Target Key: <input type="text" name="target-key">
    <input type="submit">
</form>
</body>
</html>

<?php
if (isset($_GET['key-value-pairs']) && isset($_GET['delimiter']) && isset($_GET['target-key'])) {
    $keyValuePairs = explode("\n", $_GET['key-value-pairs']);
    $keyValuePairs = array_map('trim', $keyValuePairs);
    $delimiter = $_GET['delimiter'];
    $key = $_GET['target-key'];
    $array = array();
    for ($i = 0; $i < count($keyValuePairs); $i++) {
        $keyValuePair = array_map('trim',explode($delimiter, $keyValuePairs[$i]));
        if (!array_key_exists($keyValuePair[0],$array)) {
            $array[$keyValuePair[0]] = [];
        }

        array_push($array[$keyValuePair[0]], $keyValuePair[1]);
    }

    if ($array[$key] == null) {
        echo 'None';
    } else {
        echo implode('<br>', $array[$key]);
    }
}
?>

