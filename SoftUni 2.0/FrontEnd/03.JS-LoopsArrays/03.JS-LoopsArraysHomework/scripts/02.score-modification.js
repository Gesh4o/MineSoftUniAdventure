var array = getArray();
var modifiedScore = modifyScore(array);

printScore(modifiedScore);

function getArray() {
    var array = [200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1, undefined];

    return array;
}

function modifyScore(array) {
    var filteredArray = array.filter(function (element) {
        return !(element < 0 || element > 400) && typeof element === 'number';
    });

    filteredArray.map(function (element) {
        return element - element * 0.2;
    });
    
    return filteredArray;
}

function printScore(score) {
    Array.prototype.getString = function () {
        return '[' + this.join(', ') + ']';
    };

    console.log(score.getString());
}