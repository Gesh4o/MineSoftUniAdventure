document.write(calcCircleArea(7));
document.write('<br>');
document.write(calcCircleArea(1.5));
document.write('<br>');
document.write(calcCircleArea(20));
document.write('<br>');

function calcCircleArea(r) {
    var result = Math.PI * r * r;
    return 'r = ' + r + '; area = ' + result ;
}