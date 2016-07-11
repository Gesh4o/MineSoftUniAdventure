<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="lines"></textarea>
    <input type="submit">
</form>
</body>
</html>

<?php
if (isset($_GET['lines']) && isset($_GET['delimiter'])) {
    $array = array_map('trim', explode($_GET['delimiter'], $_GET['lines']));
    for ($i = 0; $i < count($array); $i++) {
        if ($array[$i] == 'Stop') {
            break;
        }
        echo $array[$i] . '<br>';
    }
}
?>