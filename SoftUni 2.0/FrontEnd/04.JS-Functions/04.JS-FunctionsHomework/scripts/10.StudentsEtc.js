function solve(args) {
    "use strict";
    Array.prototype.unique = function () {
        var array = [];
        for (let index = 0, l = this.length; index < l; index++)
            if (array.indexOf(this[index]) === -1)
                array.push(this[index]);
        return array;
    };

    function sortCourses(courses) {
        let keys = Object.keys(courses).sort();
        let sortedCourses = {};
        for (let key of keys) {
            sortedCourses[key] = courses[key];
        }

        return sortedCourses;
    }

    let courses = {};

    for (let inputLine of args) {
        let inputArgs = inputLine.split(/\|/).map(s => s.trim());
        let studentName = inputArgs[0];
        let courseName = inputArgs[1];
        let grade = inputArgs[2];
        let visitsCount = inputArgs[3];
        if (!courses[courseName]) {
            courses[courseName] = {
                avgGrade: +grade,
                avgVisits: +visitsCount,
                students: [studentName]
            }
        } else /* if (courses[courseName].students.indexOf(studentName) === -1) */ {
            courses[courseName].avgGrade += +grade;
            courses[courseName].avgVisits += +visitsCount;
            courses[courseName].students.push(studentName);
        }
    }

    courses = sortCourses(courses);
    for (let course in courses) {
        courses[course].students.sort();
        courses[course].avgGrade = parseFloat(((courses[course].avgGrade / courses[course].students.length)).toFixed(2));
        courses[course].avgVisits = parseFloat(((courses[course].avgVisits / courses[course].students.length)).toFixed(2));
        courses[course].students = courses[course].students.unique();
    }

    console.log(JSON.stringify(courses));
}

solve([
    'Peter Nikolov | PHP  | 5.50 | 8',
    'Maria Ivanova | Java | 5.83 | 7',
    'Ivan Petrov   | PHP  | 3.00 | 2',
    'Ivan Petrov   | C#   | 3.00 | 2',
    'Peter Nikolov | C#   | 5.50 | 8',
    'Maria Ivanova | C#   | 5.83 | 7',
    'Ivan Petrov   | C#   | 4.12 | 5',
    'Ivan Petrov   | PHP  | 3.10 | 2',
    'Peter Nikolov | Java | 6.00 | 9'
]);