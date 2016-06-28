function solve(args) {
    'use strict';
    let regex = /<tr><td>.*?<\/td><td>(.*?)<\/td><td>(.*?)<\/td><td>(.*?)<\/td><\/tr>/m;
    let biggestSum = Number.MIN_SAFE_INTEGER;
    let firstVal;
    let secondVal;
    let thirdVal;
    let isSet = false;

    for (let i = 2; i < args.length - 1; i++) {
        let match = regex.exec(args[i]);
        if (match) {
            let firstValue = match[1];
            let secondValue = match[2];
            let thirdValue = match[3];
            let sum = 0;
            if (!isNaN(parseFloat(firstValue)) && isFinite(firstValue)) {
                sum += +firstValue;
                isSet = true;

            }

            if (!isNaN(parseFloat(secondValue)) && isFinite(secondValue)) {
                sum += +secondValue;
                isSet = true;
            }

            if (!isNaN(parseFloat(thirdValue)) && isFinite(thirdValue)) {
                sum += +thirdValue;
                isSet = true;
            }
            if (biggestSum < sum) {
                biggestSum = sum;
                firstVal = firstValue;
                secondVal = secondValue;
                thirdVal = thirdValue;
            }
        }
    }

    function filterArray(arr) {
        let filteredArray = [];
        for (let num of arr) {
            if (!isNaN(parseFloat(num)) && isFinite(num)) {
                filteredArray.push(num)
            }
        }

        return filteredArray;
    }

    if (!isSet) {
        console.log('no data');
    } else {
        let arr = filterArray([firstVal, secondVal, thirdVal]);
        console.log(biggestSum + " = " + arr.join(" + "));
    }
}

solve([
    '<table>',
    '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
    '<tr><td>Sofia</td><td></td><td></td><td>-1</td></tr>',
    // '<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>',
    // '<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>',
    // '<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>',
    '</table>'
]);
