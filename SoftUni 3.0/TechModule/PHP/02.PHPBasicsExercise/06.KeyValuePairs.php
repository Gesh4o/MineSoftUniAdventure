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
    $delimiter = $_GET['delimiter'];
    $key = $_GET['target-key'];
    $array = array();
    for ($i = 0; $i < count($keyValuePairs); $i++) {
        $keyValuePair = explode($delimiter, $keyValuePairs[$i]);
        $array[$keyValuePair[0]] = $keyValuePair[1];
    }



    echo $array[$key] == null ? 'None' : $array[$key];
}