function doMagic(numberArray) {
    //'use strict';
    let n = +numberArray[0];
    let x = +numberArray[1];
    if (n > x) {
        console.log(n / x);
    } else {
        console.log(n * x);
    }
}

doMagic([2, 3]);