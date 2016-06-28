function solve(args) {
    'use strict';

    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');
    console.log("<tr><td>" + (+args[0]).toFixed(2) + "</td><td><img src=" + "\"fixed.png\"" + "/></td></tr>");
    let previousValue = (+args[0]).toFixed(2);
    for (let i = 1; i < args.length; i++) {
        let imageValue = 'fixed.png';
        let currentValue = (+args[i]).toFixed(2);
        if (currentValue > previousValue) {
            imageValue = 'up.png';
        } else if (currentValue < previousValue) {
            imageValue = 'down.png';
        }

        previousValue = currentValue;
        console.log("<tr><td>" + (+args[i]).toFixed(2) + "</td><td><img src=\"" + imageValue + "\"/></td></tr>");
    }

    console.log('</table>');
}

solve([36.333, 36.5, 37.019, 35.4, 35, 35.001, 36.225]);