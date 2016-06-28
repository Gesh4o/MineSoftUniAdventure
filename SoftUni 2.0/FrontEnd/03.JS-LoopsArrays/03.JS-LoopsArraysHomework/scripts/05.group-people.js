'use strict';
function getPeople() {
    let Person = function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    };

    let people = [
        new Person("Scott", "Guthrie", 38),
        new Person("Scott", "Johns", 40),
        new Person("Scott", "Hanselman", 36),
        new Person("Jesse", "Liberty", 57),
        new Person("Jon", "Skeet", 36)
    ];

    return people;
}

Array.prototype.groupBy = function (selector) {
    let groupedPeople = {};
    for (let person of people){
        if (!groupedPeople[selector(person)]){
            groupedPeople[selector(person)] = [];
        }

        groupedPeople[selector(person)].push(person);
    }

    return groupedPeople;
};

let people = getPeople();
let groupedPeople = people.groupBy(p => p.firstName);
console.log(groupedPeople);