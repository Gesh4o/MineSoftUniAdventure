function solve(args) {
    let sequence = args.map(Number);

    sequence = sequence.sort(function (firstNumber, secondNumber) {
        return +firstNumber < +secondNumber;
    });

    // sequence = sequence.sort((a, b) => b - a);

    for (let index = 0; index < 3; index++) {
        if (sequence[index]) {
            console.log(sequence[index]);
        }
    }
}
