function storeObjects(args) {
    var students = args.map(JSON.parse);
    for (var student in students)
    {
        console.log('Name: ' +
            students[student]['name'] +
            '\nAge: ' +
            students[student]['age'] +
            '\nDate: ' +
            students[student]['date'])
    }
}


storeObjects(['{"name":"Gosho","age":"10","date":"19/06/2005"}',
'{"name":"Tosho","age":"11","date":"04/04/2005"}']);