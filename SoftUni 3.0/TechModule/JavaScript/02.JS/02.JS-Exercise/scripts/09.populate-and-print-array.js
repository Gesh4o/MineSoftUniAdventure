function populateAndPrintArray(inputInfo) {
    var arrayLength = +inputInfo[0];
    var array = new Array(arrayLength);
    for (var lineIndex = 1; lineIndex < inputInfo.length; lineIndex++) {
        var line = inputInfo[lineIndex].split(' ');
        var index = line[0];
        var value = line[2];
        array[index] = value;
    }

    for (var numberIndex = 0; numberIndex < array.length; numberIndex++) {
        if (array[numberIndex])
            console.log(array[numberIndex]);
        else {
            console.log(0);
        }
    }
}

populateAndPrintArray(['2', '0 - 5', '0 - 6', '0 - 7']);