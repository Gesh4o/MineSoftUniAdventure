function populateDictionary(commandArgs) {
    var obj = {};
    for (var index = 0; index < commandArgs.length - 1; index++) {
        var commandInfo = commandArgs[index].split(' ');
        if (!(commandInfo[0] in obj)) {
            obj[commandInfo[0]] = [];
        }
        obj[commandInfo[0]].push(commandInfo[1]);
    }

    var key = commandArgs[commandArgs.length - 1];
    if (obj[key]) {
        for (var index = 0; index < obj[key].length; index++) {
            console.log(obj[key][index]);
        }
    }
    else {
        console.log('None');
    }
}

populateDictionary(['key value', 'key eulav', 'test tset', '3']);