function solve(args) {
    "use strict";

    function isInSequence(array, currentCol, sequenceLength) {
        let currentElement = array[currentCol];

        let isInSeq = true;
        for (let col = currentCol + 1; col < currentCol + sequenceLength; col++) {
            if (array[col] === '&') {
                sequenceLength++;
            } else {
                if (array[col] !== currentElement) {
                    isInSeq = false;
                    break;
                }
            }
        }

        return isInSeq;
    }

    let sequenceLength = +args[args.length - 1];
    delete args[args.length - 1];
    let array = args.join(" & ").split(/\s/).filter(function (e) {
        return e;
    });

    let isSeq = [];
    for (let col = 0; col < array.length - 1; col++) {
        if (isInSequence(array, col, sequenceLength)) {
            let newLineDelimiterCount = 0;
            for (let i = col; i < col + sequenceLength + newLineDelimiterCount; i++) {
                if (array[i] === '&') {
                    isSeq.push(true);
                    newLineDelimiterCount++;
                }
                else {
                    isSeq.push(false);
                }
            }
            col += sequenceLength - 1 + newLineDelimiterCount;
        } else {
            isSeq.push(true);
        }
    }

    let filtered = [];
    for (let i = 0; i < array.length; i++) {
        if (isSeq[i]) {
            filtered.push(array[i]);
        }
    }

    filtered = filtered.filter(function (e) {
        return e;
    }).join(" ").split(/\s*&\s*/);

    for (let i = 0; i < filtered.length; i++) {
        if (filtered[i].length > 0){
            console.log(filtered[i]);
        }
        else {
            console.log("(empty)");
        }
    }
}

solve([
    '3 3 3 2 5 9 9 9 9 1 2',
    '1 1 1 1 1 2 5 8 1 1 7',
    '7 7 1 2 3 5 7 4 4 1 2',
    '2'
]);