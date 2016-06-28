function solve(args) {
    'use strict';
    class Item {
        constructor(name, price, value) {
            this.name = name;
            this.price = price;
            this.value = value;
        }

        /**
         * @return {string}
         */
        Stringify() {
            return '<tr><td>' + this.name + '<\/td><td>' + this.price + '<\/td><td>' + this.value + '<\/td><\/tr>';
        }
    }

    let regexPattern = /<tr><td>(.*?)<\/td><td>(.*?)<\/td><td>(.*?)<\/td><\/tr>/m;
    let items = [];
    for (let lineIndex = 2; lineIndex < args.length - 1; lineIndex++) {
        let match = regexPattern.exec(args[lineIndex]);
        if (match) {
            let name = match[1].toString();
            let price = match[2];
            let value = match[3].toString();
            items.push(new Item(name, price, value));
        }
    }

    console.log('<table>\n<tr><th>Product</th><th>Price</th><th>Votes</th></tr>');
    items = items.sort(function (firstItem, secondItem) {
        if (firstItem.price != secondItem.price) {
            return +firstItem.price - +secondItem.price;
        } else {
            return firstItem.data == secondItem.data ? 0 : firstItem.data < secondItem.data ? -1 : 1;
        }
    });

    items.forEach(item => console.log(item.Stringify()));
    console.log('</table>');
}

solve([
    '<table>',
    '<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
    '<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
    '<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
    '<tr><td>Laptop Lenovo IdeaPad B5400</td><td>929.00</td><td>0</td></tr>',
    '<tr><td>Laptop ASUS ROG G550JK-CN268D</td><td>1939.00</td><td>+1</td></tr>',
    '<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
    '<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
    '</table>'
]);