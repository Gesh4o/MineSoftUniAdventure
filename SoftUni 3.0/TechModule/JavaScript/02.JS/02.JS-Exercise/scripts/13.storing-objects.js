function storeObjects(args) {
    'use strict';
    var students = args.map(parseStudent);
    for (var student in students)
    {
        console.log('Name: ' +
            students[student].name +
            '\nAge: ' +
            students[student].age +
            '\nGrade: ' +
            students[student].grade)
    }

    function parseStudent(studentText) {
        class Student{
            constructor(name, age, grade){
                this.name = name;
                this.age = age;
                this.grade = grade;
            }
        }

        studentText = studentText.split(' ');

        return new Student(studentText[0], studentText[2], studentText[4]);
    }


}

storeObjects(['Pesho -> 13 -> 6.00','Ivan -> 12 -> 5.57','Toni -> 13 -> 4.90']);