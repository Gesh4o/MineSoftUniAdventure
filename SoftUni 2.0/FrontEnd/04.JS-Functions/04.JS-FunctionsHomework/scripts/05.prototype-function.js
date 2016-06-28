'use strict';
Array.prototype.where = function (predicate) {
    let filteredArray = [];
    for (let element of this) {
        if (predicate(element)) {
            filteredArray.push(element);
        }
    }

    return filteredArray;
};

Array.prototype.removeItem = function (item) {
    return this.where(e => e !== item);
};

let arr = [1,2,3,4,5,1,2,3,1,1,1,1];
console.log(arr.removeItem(2));