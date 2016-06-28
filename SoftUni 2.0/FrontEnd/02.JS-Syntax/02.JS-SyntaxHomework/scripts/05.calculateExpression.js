'use strict';
console.log('Hellooo');
var onButtonClick = function () {
    var text = document.getElementById("inputText");
    console.log("Clicked!");
    document.getElementById("paragraph").innerHTML = calculateExpression(text.value);
};

var calculateExpression = function (text) {
    var numbersArray = text.match(/([0-9]+(\.[0-9]+)?)/g);
    var operatorsArray = text.replace(/([0-9\s]+\.*)/g, "");
    var result = +numbersArray[0];
    for(var index = 1; index < numbersArray.length; index++){
        var secondOperand = +numbersArray[index];
        var operator = operatorsArray[index - 1];
        switch (operator){
            case "+":
                result += secondOperand;
                break;
            case "-":
                result -= secondOperand;
                break;
            case "*":
                result *= secondOperand;
                break;
            case "/":
                result /= secondOperand;
                break;
            default:
                throw new EventException('Invalid operand');
        }
    }
    
    return result;
};