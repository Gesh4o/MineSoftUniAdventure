function solve(args) {
    "use strict";

    function bombMatrix(matrix, bombRow, bombCol) {
        let startCol = Math.max(0, +bombCol - 1);
        let endCol = Math.min(matrix[bombRow].length - 1, +bombCol + 1);

        let startRow = Math.max(0, +bombRow - 1);
        let endRow = Math.min(matrix.length - 1, +bombRow + 1);

        let bombDmg = +matrix[bombRow][bombCol];

        for (let row = startRow; row <= endRow; row++) {
            for (let col = startCol; col <= endCol; col++) {
                matrix[row][col] -= bombDmg;
            }
        }
    }

    let matrix = [];
    let damageDone = 0;
    let killedBunnies = 0;

    for (let line = 0; line < args.length - 1; line++) {
        let lineInfo = args[line].split(/\s+/); // filter memory issue?
        matrix[line] = [];
        for (let number of lineInfo) {
            matrix[line].push(+number);
        }
    }

    let bombCoordinates = args[args.length - 1].split(/\s+/);

    for (let bombCoordinate of bombCoordinates) {
        let bombInfo = bombCoordinate.trim().split(/,+/);
        let row = bombInfo[0];
        let col = bombInfo[1];

        if (matrix[row][col] > 0) {
            killedBunnies++;
            damageDone += matrix[row][col];
            bombMatrix(matrix, row, col);
        }
    }

    for (let row = 0; row < matrix.length; row++) {
        let upperBound = matrix[row].length;
        for (let col = 0; col < upperBound; col++) {
            if (matrix[row][col] > 0) {
                damageDone += +matrix[row][col];
                killedBunnies++;
            }
        }
    }

    console.log(damageDone);
    console.log(killedBunnies);
}


solve([
    '5 10 15',
    '10 20 10',
    '10 15 10',
    '1,1 2,2'
]);