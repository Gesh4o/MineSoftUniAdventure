'use strict';
var array = getArray();

manipulateArray(array);

function getArray() {
    var array = ["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", {bunniesCount: 10}, [10, 20, 30, 40]];

    return array;
}

function manipulateArray(array) {
    Array.prototype.min = function () {
        var minValue = Number.MAX_VALUE;
        for (var index in this) {
            if (minValue > this[index]) {
                minValue = this[index];
            }
        }

        if (minValue !== Number.MAX_VALUE) {
            return minValue;
        }

        return undefined;
    };

    Array.prototype.max = function () {
        var maxValue = Number.MIN_VALUE;
        for (var index in this) {
            if (maxValue < this[index]) {
                maxValue = this[index];
            }
        }

        if (maxValue !== Number.MIN_VALUE) {
            return maxValue;
        }
        return undefined;
    };

    Array.prototype.getMostFrequent = function () {
        var mostFrequentNumberCount = -1;
        var mostFrequentNumber;
        for (var comparedNumberIndex in this) {
            var counter = 0;
            for (var comparingNumberIndex in this) {
                if (this[comparedNumberIndex] === this[comparingNumberIndex]) {
                    counter++;
                }
            }

            if (counter > mostFrequentNumberCount) {
                mostFrequentNumberCount = counter;
                mostFrequentNumber = this[comparedNumberIndex];
            }
        }

        if (mostFrequentNumberCount !== -1) {
            return mostFrequentNumber;
        }

        return undefined;
    };

    var numberArray = array.filter(function (element) {
        var isEmpty = element !== 0 && !element;
        return typeof element === 'number';
    });

    Array.prototype.getString = function () {
        return '[' + this.join(', ') + ']';
    };

    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined' ? args[number] : match;
        });
    };

    console.log("Min number: {0}".format(numberArray.min()));
    console.log("Max number: {0}".format(numberArray.max()));
    console.log("Most frequent number: {0}".format(numberArray.getMostFrequent()));
    console.log(numberArray.sort(function (firstArg, secondArg) {
        return secondArg > firstArg;
    }).getString());
}