<html>
<head>

</head>
<body>
<form>
    Delimiter: <input type="text" name="delimiter">
    Array-size: <input type="text" name="array-size">
    Input: <textarea name="key-value-pairs"></textarea>
    <input type="submit">
</form>
</body>
</html>
<?php
if(isset($_GET['delimiter']) && isset($_GET['key-value-pairs']) && isset($_GET['array-size'])){
    $arrayKeyValues = str_replace($_GET['delimiter'],"\n" ,$_GET['key-value-pairs']);
    $arrayKeyValues = explode("\n" ,$arrayKeyValues);


    $arraySize = intval($_GET['array-size']);
    $array = array();

    for($i = 0; $i < $arraySize; $i++){
        $array[$i] = 0;
    }

    for($i = 0; $i < count($arrayKeyValues) - 1; $i+= 2){
        $index = $arrayKeyValues[$i];
        $value = $arrayKeyValues[($i + 1)];
        $array[$index] = $value;
    }

    for($i = 0; $i < $arraySize; $i++){
        echo $array[$i] . '<br>';
    }
}
?>