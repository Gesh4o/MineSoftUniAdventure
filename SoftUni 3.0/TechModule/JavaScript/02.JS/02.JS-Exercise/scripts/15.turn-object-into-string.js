function stringObject(objectInfo) {
    var name = objectInfo[0].split(' ')[2];
    var surname = objectInfo[1].split(' ')[2];
    var age = objectInfo[2].split(' ')[2];
    var grade = objectInfo[3].split(' ')[2];
    var date = objectInfo[4].split(' ')[2];
    var town = objectInfo[5].split(' ')[2];

    var student = {};
    student.name = name;
    student.surname = surname;
    student.age = +age;
    student.grade = +grade;
    student.date = date;
    student.town = town;
    console.log(JSON.stringify(student));
}

stringObject(['name -> Angel','surname -> Georgiev','age -> 20','grade -> 6.00','date -> 23/05/1995','town -> Sofia']);