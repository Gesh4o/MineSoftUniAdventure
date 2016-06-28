function Solve(arr) {
    var start = +arr[0];
    var end = +arr[1];
    var outputArray = new Array(((end - start) + 1) + 1);

    var fibonacciSequence = new Array(31);
    fibonacciSequence[0] = 0;
    fibonacciSequence[1] = 1;
    populateFibonacci(31);
    function populateFibonacci(endNumber) {
        for (var index = 2; index < endNumber; index++) {
            fibonacciSequence[index] = fibonacciSequence[index - 1] + fibonacciSequence[index - 2];
        }
    }

    var isFibonacci = function (number) {
        for (var index = 0; index < fibonacciSequence.length; index++) {
            var currentNumber = fibonacciSequence[index];
            if (currentNumber === number) {
                return true;
            }

            if (currentNumber > number) {
                return false;
            }
        }
    };

    outputArray.push('<table>');
    outputArray.push('<tr><th>Num</th><th>Square</th><th>Fib</th></tr>');
    for (var num = start; num <= end; num++) {
        var isFib = isFibonacci(num) ? 'yes' : 'no';
        outputArray.push(
            '<tr><td>' +
            num +
            '</td><td>' +
            num * num +
            '</td><td>' +
            isFib +
            '</td></tr>')
    }
    outputArray.push('</table>');

    var result = outputArray.join("\n");
    return result;
}