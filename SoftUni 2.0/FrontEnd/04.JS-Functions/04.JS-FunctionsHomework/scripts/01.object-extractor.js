'use strict';

function extractObjects(array){
    let objectArray = [];
    for(let element of array){

        if(element instanceof Object && !(element instanceof Array)){
            objectArray.push(element);
        }
    }

    return objectArray;
}
let array = [
    "Pesho",
    4,
    4.21,
    { name : 'Valyo', age : 16 },
    { type : 'fish', model : 'zlatna ribka' },
    [1,2,3],
    "Gosho",
    { name : 'Penka', height: 1.65}
];

let objectArray = extractObjects(array);
console.log(objectArray.toString());
