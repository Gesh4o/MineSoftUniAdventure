<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Input: <textarea name="numbers"></textarea>
    <input type="submit">
</form>
</body>
</html>

<?php
if (isset($_GET['delimiter']) && isset($_GET['numbers'])) {
    $delimiter = $_GET['delimiter'];
    $numbers = $_GET['numbers'];

    $reverseNumbers = explode($delimiter, $numbers);
    $reverseNumbers = array_map('trim', $reverseNumbers);
    for ($i = count($reverseNumbers) - 1; $i >= 0; $i--) {
        echo $reverseNumbers[$i] . '<br>';
    }
}
?>



