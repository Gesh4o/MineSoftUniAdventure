function printNumbers(end) {
    for (var number = 1; number <= +end; number++) {
        console.log(number);
    }
}

function printNumbersBackwards(end) {
    for (var number = +end; number > 0; number--) {
        console.log(number);
    }
}