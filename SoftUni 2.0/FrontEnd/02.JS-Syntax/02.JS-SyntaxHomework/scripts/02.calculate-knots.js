"using strict";
var inputLine = require('readline');
var readLine = inputLine.createInterface(process.stdin, process.stdout);
readLine.on('line', function (line) {
    if (line != 'end') {
        var result = new Number(line) * 0.5399568034557235;
        console.log(result.toFixed(2));
    } else {
        readLine.close();
        process.stdin.destroy();
    }
    
    readLine.prompt();
});