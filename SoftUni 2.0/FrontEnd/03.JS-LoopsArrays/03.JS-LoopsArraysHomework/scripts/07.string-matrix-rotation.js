function solve(args) {
    'use strict';
    let regexPattern = /Rotate\(([0-9\-]+)\)/g;
    let angle = (regexPattern.exec(args[0]))[1] % 360;
    let matrix = rotateAtZeroDegrees(args);
    switch (+angle) {
        case 0:
            break;
        case 90:
            matrix = rotateAtNinetyDegrees(matrix);
            break;
        case 180:
            matrix = rotateAtOneHundredAndEightyDegrees(matrix);
            break;
        case 270:
            matrix = rotateAtTwoHundredAndSeventy(matrix);
            break;
    }

    printMatrix(matrix);

    function rotateAtZeroDegrees(args) {
        let largestStringLength = 0;
        for (let row = 1; row < args.length; row++) {
            if (args[row].length > largestStringLength) {
                largestStringLength = args[row].length;
            }
        }

        let matrix = [];
        for (let row = 0; row < args.length - 1; row++) {
            matrix[row] = new Array(largestStringLength);
            for (let col = 0; col < args[row + 1].length; col++) {
                matrix[row][col] = args[row + 1][col]
            }
        }

        return matrix;
    }

    function rotateAtNinetyDegrees(initialMatrix) {
        let matrix = [];
        for (let col = 0; col < initialMatrix.length; col++) {
            for (let row = 0; row < initialMatrix[initialMatrix.length - 1 - col].length; row++) {
                if (!matrix[row]) {
                    matrix[row] = [];
                }
                matrix[row][col] = initialMatrix[initialMatrix.length - 1 - col][row];
            }
        }

        return matrix;
    }

    function rotateAtOneHundredAndEightyDegrees(initialMatrix) {
        let matrix = [];
        for (let row = 0; row < initialMatrix.length; row++) {
            matrix[row] = [];
            let lastRow = initialMatrix.length - 1 - row;
            for (let col = 0; col < initialMatrix[lastRow].length; col++) {
                matrix[row][col] = initialMatrix[lastRow][initialMatrix[lastRow].length - 1 - col];
            }
        }

        return matrix;
    }

    function rotateAtTwoHundredAndSeventy(initialMatrix) {
        let matrix = [];
        for (let col = 0; col < initialMatrix.length; col++) {
            for (let row = 0; row < initialMatrix[col].length; row++) {
                if(!matrix[row]){
                    matrix[row] = new Array(initialMatrix[col].length);
                }
                matrix[row][col] = initialMatrix[col][initialMatrix[col].length - 1 - row];
            }
        }

        return matrix;
    }

    function printMatrix(matrix) {
        for (let row = 0; row < matrix.length; row++) {
            let output = "";

            for (let col = 0; col < matrix[row].length; col++) {
                if (matrix[row][col]) {
                    output += matrix[row][col];
                }
                else {
                    output += ' ';
                }
            }
            console.log(output);
        }
    }
}

solve(['Rotate(810)', 'js', 'exam']);