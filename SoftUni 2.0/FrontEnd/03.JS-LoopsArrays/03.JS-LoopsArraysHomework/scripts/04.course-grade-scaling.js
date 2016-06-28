var students = getStudents();

students = evaluateStudents(students);
students = students.filter(function (student) {
    return student['hasPassed'] === true;
});

console.log(students.sort(function (firstStudent, secondStudent) {
    return firstStudent['name'] > secondStudent['name'];
}));

function getStudents() {
    var studentsJSON = [
            {
                'name' : 'Пешо',
                'score' : 91
            },
            {
                'name' : 'Лилия',
                'score' : 290
            },
            {
                'name' : 'Алекс',
                'score' : 343
            },
            {
                'name' : 'Габриела',
                'score' : 400
            },
            {
                'name' : 'Жичка',
                'score' : 70
            }
        ];


    return studentsJSON;
}

function evaluateStudents(students) {
    for(var index in students){
        var student = students[index];
        student['score'] += (0.1 * student['score']);
        student['hasPassed'] = student['score'] >= 100;
    }

    return students;
}