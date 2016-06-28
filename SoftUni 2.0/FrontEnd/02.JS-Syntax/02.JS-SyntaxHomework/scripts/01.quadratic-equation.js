"use strict";
var a = prompt("Insert a: ");
var b = prompt("Insert b: ");
var c = prompt("Insert c: ");

var diskriminant = (b * b) - 4 * a * c;
if (diskriminant > 0){
    var x1 = ((-1 * b) +  Math.sqrt(diskriminant)) / (2 * a);
    var x2 = ((-1 * b) -  Math.sqrt(diskriminant)) / (2 * a);

    alert("x1 = " + x1 + '\n' + "x2 = " + x2);
} else if (diskriminant == 0){
    var x = ((-1 * b) + Math.sqrt(diskriminant)) / (2 * a);
    alert("x = " + x);
} else {
    alert("No real roots");
}