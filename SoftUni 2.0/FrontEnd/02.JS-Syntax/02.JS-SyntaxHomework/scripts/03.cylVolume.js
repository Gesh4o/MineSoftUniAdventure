'use strict';
var readLine = require('readline');
var readLineInterface = readLine.createInterface(process.stdin, process.stdout);

readLineInterface.on('line', function (inputLine) {
    if (inputLine !== 'end') {
        var array = inputLine.split(/[\D]+/);
        array = array.filter(function (element) {
            if (element){
                return element;
            }
        });
        
        var volume = array[0] * array[1];
        console.log(volume);

    } else {
        readLineInterface.close();
        process.stdin.destroy();
    }
});