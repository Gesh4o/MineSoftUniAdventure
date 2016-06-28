function solve(args) {
    'use strict';
    let start = +args[0];
    let end = +args[1];

    console.log('<ul>');
    for (let number = start; number <= end; number++) {
        if (isRakiyaNumber(number)) {
            console.log('<li><span class=\'rakiya\'>' + number + '</span><a href="view.php?id=' + number + '>View</a></li>');
        }
        else {
            console.log('<li><span class=\'num\'>' + number + '</span></li>');
        }
    }
    console.log('</ul>');

    function isRakiyaNumber(number) {
        let numberAsString = number.toString();

        for (let firstGroupIndex = 0; firstGroupIndex < numberAsString.length - 1; firstGroupIndex++) {
            let currentSequence = numberAsString[firstGroupIndex] + numberAsString[firstGroupIndex + 1];
            for (let secondGroupIndex = firstGroupIndex + 2; secondGroupIndex < numberAsString.length - 1; secondGroupIndex++) {
                let sequence = numberAsString[secondGroupIndex] + numberAsString[secondGroupIndex + 1];
                if (sequence === currentSequence) {
                    return true;
                }
            }
        }

        return false;
    }
}

solve([55555, 55560]);