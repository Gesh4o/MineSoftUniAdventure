function solve(args) {
    let n = +args[0];
    for (let number = 1; number <= n; number++) {
        if (isPalindrome(number.toString())) {
            console.log(number + " ");
        }
    }

    function isPalindrome(text) {
        for (let index = 0; index < text.length / 2; index++) {
            if (text[index] !== text[text.length - 1 - index]) {
                return false;
            }
        }

        return true;
    }
}