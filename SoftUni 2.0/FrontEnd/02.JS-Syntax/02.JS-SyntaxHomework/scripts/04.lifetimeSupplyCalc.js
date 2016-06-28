'use strict';

var readline = require('readline');
var readLineInterface = readline.createInterface(process.stdin, process.stdout);
var count = 0;
var array = new Array(4);
readLineInterface.on('line', function (inputLune) {
    array[count] = inputLune;
    count++;
    if (count > 3) {
        readLineInterface.close();
        process.stdin.destroy();
        var result = calculateSupply(array[0], array[1], array[2], array[3]);
        console.log(result);
    }
});

function calculateSupply(age, maxAge, foodName, foodQuantity) {
    var agesLeft = maxAge - age;
    var quantityForALifeTime = agesLeft * foodQuantity * 365.0;
    console.log(foodQuantity);
    var result = "{0}kg of {1} would be enough until I am {2} years old.".format(quantityForALifeTime, foodName, maxAge);
    return result;
}

String.prototype.format = function () {
    var args = arguments;
    return this.replace(/{(\d+)}/g, function (match, number) {
        return typeof args[number] != 'undefined'
            ? args[number] : match;
    });
};