function Solve(arr) {
    String.prototype.replaceAt = function (index, character) {
        return this.substr(0, index) + character + this.substr(index + character.length);
    };

    var isInTriangle = new Array(arr.length);
    for (var row = 0; row < isInTriangle.length; row++) {
        isInTriangle[row] = new Array(arr[row].length);
    }

    var isFormingATriangle = function (arr, row, col) {
        var isForming =  col + 1 < arr[row + 1].length &&
            (arr[row][col] === arr[row + 1][col - 1]) &&
            (arr[row][col] === arr[row + 1][col]) &&
            (arr[row][col] === arr[row + 1][col + 1]);
        return isForming;
    };

    for (row = 0; row < isInTriangle.length - 1; row++) {
        for (var col = 1; col < isInTriangle[row].length; col++) {
            if (isFormingATriangle(arr, row, col)) {
                isInTriangle[row][col] = true;
                isInTriangle[row + 1][col - 1] = true;
                isInTriangle[row + 1][col] = true;
                isInTriangle[row + 1][col + 1] = true;
            }
        }
    }

    for (row = 0; row < isInTriangle.length; row++) {
        for (col = 0; col < isInTriangle[row].length; col++) {
            if (isInTriangle[row][col]) {
                arr[row] = arr[row].replaceAt(col, '*');
            }
        }
    }

    var result = arr.join("\n");

    return result;
}