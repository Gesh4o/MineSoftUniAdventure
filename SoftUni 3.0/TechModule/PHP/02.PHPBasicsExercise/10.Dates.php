<html>
<head>
</head>
<body>
<form>
    Start Date:
    <br>
    <input type="text" name="date">
    <br>
    Output Format:
    <br>
    <input type="text" name="format">
    <br>
    Commands:
    <br>
    <textarea name="commands"></textarea>
    <br>
    <input type="submit">
</form>
</body>
</html>

<?php
if (isset($_GET['date']) && isset($_GET['commands']) && isset($_GET['format'])) {
    $date =  DateTime::createFromFormat("d/m/Y", $_GET['date']);

    $commands = explode("\n", $_GET['commands']);
    $format = $_GET['format'];
    for ($i = 0; $i < count($commands); $i++) {
        $commandInfo = explode(" ", $commands[$i]);

        if ($commandInfo[0] == 'add') {
            date_add($date, date_interval_create_from_date_string($commandInfo[1] . ' days'));
        } else {
            date_sub($date, date_interval_create_from_date_string($commandInfo[1] . ' days'));
        }
    }

    echo $date->format($format);

}

?>