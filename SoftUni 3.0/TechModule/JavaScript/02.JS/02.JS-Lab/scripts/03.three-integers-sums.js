function solve(arr) {
    let array = arr[0].toString().split(/\s+/);

    let a = array[0];
    let b = array[1];
    let c = array[2];

    if (check(a, c, b) || check(b, c, a) || check(a, b, c) ) {
    }
    else {
        console.log('No');
    }

    function check(a, b, c) {
        var bool = (+a) + (+b) === (+c);
        if (bool) {
            if ( +a < + b) {
                console.log(a + " + " + b + " = " + c);
            }else {
                console.log(b + " + " + a + " = " + c);

            }
        }
        return bool;
    }
}