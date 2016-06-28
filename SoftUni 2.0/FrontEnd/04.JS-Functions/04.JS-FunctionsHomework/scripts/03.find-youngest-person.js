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

Array.prototype.min = function (action) {
    if (this.length > 0) {
        let maxElementIndex = 0;
        let maxElement = action(this[0]);
        for (let i = 1; i < this.length; i++) {
            let currentElement = action(this[i]);
            if (currentElement < maxElement) {
                maxElement = currentElement;
                maxElementIndex = i;
            }
        }

        return this[maxElementIndex];
    }
};

function findYoungestPerson(array) {
    let youngestPerson = array.where(x => x['hasSmartphone'] === true).min(x => x['age']);
    console.log('The youngest person is ' +
        youngestPerson.firstname +
        ' ' +
        youngestPerson.lastname);

}

var people = [
    {firstname: 'George', lastname: 'Kolev', age: 32, hasSmartphone: false},
    {firstname: 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true},
    {firstname: 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true},
    {firstname: 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false}];

findYoungestPerson(people);
