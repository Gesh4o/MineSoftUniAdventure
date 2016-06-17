'use strict';
function printProduct(numberArray) {
    let count = 0;
    if (numberArray[0] < 0) {
        count++;
    }

    if (numberArray[1] < 0) {
        count++;
    }

    if (numberArray[2] < 0) {
        count++;
    }

    if (count % 2 == 0) {
        console.log('Positive');
    }
    else {
        console.log('Negative');
    }
}

printProduct([1, 2, 3]);