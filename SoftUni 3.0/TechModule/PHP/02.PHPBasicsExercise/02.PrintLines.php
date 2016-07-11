<html>
<head>
</head>
<body>
<form>
    Input: <textarea name="lines"></textarea>
    <input type="submit">
</form>
</body>
</html>

<?php
if(isset($_GET['lines'])){
    $lines = array_map('trim',explode("\n", $_GET['lines']));
    for($i = 0; $i < count($lines); $i++){
        if($lines[$i] == 'Stop'){
            break;
        }
        echo $lines[$i] . '<br>';
    }
}
