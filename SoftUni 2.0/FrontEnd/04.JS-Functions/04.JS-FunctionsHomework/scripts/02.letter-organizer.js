'use strict';
String.prototype.toCharArray = function () {
    let array = new Array(this.length);

    for (let c of this) {
        array.push(c);
    }

    return array;
};

function sortLetters(word, isAscendingSort) {
    if (isAscendingSort) {
        return word.toString().toCharArray().sort((a, b) => a.toLowerCase() > b.toLowerCase()).join("");
    }
    else {
        return word.toString().toCharArray().sort((a, b) => a.toLowerCase() < b.toLowerCase()).join("");
    }
}

console.log(sortLetters('HelloWorld', false));