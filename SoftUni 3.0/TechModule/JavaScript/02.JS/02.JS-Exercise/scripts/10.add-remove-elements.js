function executeCommands(commandArgs) {
    var numbers = [];
    for (var command in commandArgs) {
        var commandInfo = commandArgs[command].split(' ');
        var commandName = commandInfo[0];
        var commandValue = commandInfo[1];

        if (commandName === 'add') {
            numbers.push(commandValue);
        }
        else {
                numbers.splice(commandValue, 1);
        }
    }


    for (var number in numbers) {
        console.log(numbers[number]);
    }
}

executeCommands(['add 3', 'add 5', 'remove 3']);