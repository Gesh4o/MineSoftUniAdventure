function solve(args) {
    'use strict';
    function getCountOfI(args) {
        let count = 0;
        for (let row = 0; row < args.length - 3; row++) {
            for (let col = 0; col < args[row].length; col++) {
                if (args[row].charAt(col) === 'o' &&
                    args[row].charAt(col) === args[row + 1].charAt(col) &&
                    args[row].charAt(col) === args[row + 2].charAt(col) &&
                    args[row].charAt(col) === args[row + 3].charAt(col)) {
                    count++;
                }
            }
        }

        return count;
    }

    function getCountOfL(args) {
        let count = 0;
        for (let row = 0; row < args.length - 2; row++) {
            for (let col = 0; col < args[row].length + 1; col++) {
                if (args[row].charAt(col) === 'o' &&
                    args[row].charAt(col) === args[row + 1].charAt(col) &&
                    args[row].charAt(col) === args[row + 2].charAt(col) &&
                    args[row].charAt(col) === args[row + 2].charAt(col + 1)) {
                    count++;
                }
            }
        }

        return count;
    }

    function getCountOfJ(args) {
        let count = 0;
        for (let row = 0; row < args.length - 2; row++) {
            for (let col = 1; col < args[row].length; col++) {
                if (args[row].charAt(col) === 'o' &&
                    args[row].charAt(col) === args[row + 1].charAt(col) &&
                    args[row].charAt(col) === args[row + 2].charAt(col) &&
                    args[row].charAt(col) === args[row + 2].charAt(col - 1)) {
                    count++;
                }
            }
        }

        return count;
    }

    function getCountOfO(args) {
        let count = 0;
        for (let row = 0; row < args.length - 1; row++) {
            for (let col = 0; col < args[row].length - 1; col++) {
                if (args[row].charAt(col) === 'o' &&
                    args[row].charAt(col) === args[row].charAt(col + 1) &&
                    args[row].charAt(col) === args[row + 1].charAt(col) &&
                    args[row].charAt(col) === args[row + 1].charAt(col + 1)) {
                    count++;
                }
            }
        }

        return count;
    }

    function getCountOfZ(args) {
        let count = 0;
        for (let row = 0; row < args.length - 1; row++) {
            for (let col = 0; col < args[row].length - 2; col++) {
                if (args[row].charAt(col) === 'o' &&
                    args[row].charAt(col) === args[row].charAt(col + 1) &&
                    args[row].charAt(col) === args[row + 1].charAt(col + 1) &&
                    args[row].charAt(col) === args[row + 1].charAt(col + 2)) {
                    count++;
                }
            }
        }

        return count;
    }

    function getCountOfS(args) {
        let count = 0;
        for (let row = 0; row < args.length - 1; row++) {
            for (let col = 1; col < args[row].length - 1; col++) {
                if (args[row].charAt(col) === 'o' &&
                    args[row].charAt(col) === args[row].charAt(col + 1) &&
                    args[row].charAt(col) === args[row + 1].charAt(col) &&
                    args[row].charAt(col) === args[row + 1].charAt(col - 1)) {
                    count++;
                }
            }
        }

        return count;
    }


    function getCountOfT(args) {
        let count = 0;
        for (let row = 0; row < args.length - 1; row++) {
            for (let col = 0; col < args[row].length - 2; col++) {
                if (args[row].charAt(col) === 'o' &&
                    args[row].charAt(col) === args[row].charAt(col + 1) &&
                    args[row].charAt(col) === args[row].charAt(col + 2) &&
                    args[row].charAt(col) === args[row + 1].charAt(col + 1)) {
                    count++;
                }
            }
        }

        return count;
    }


    let countOfI = getCountOfI(args);
    let countOfL = getCountOfL(args);
    let countOfJ = getCountOfJ(args);
    let countOfO = getCountOfO(args);
    let countOfZ = getCountOfZ(args);
    let countOfS = getCountOfS(args);
    let countOfT = getCountOfT(args);
    console.log(
        '{"I":' +
        countOfI +
        ',"L":' +
        countOfL +
        ',"J":' +
        countOfJ +
        ',"O":' +
        countOfO +
        ',"Z":' +
        countOfZ +
        ',"S":' +
        countOfS +
        ',"T":' +
        countOfT +
        '}');
}

solve(
    [
        '--o--o-',
        '--oo-oo',
        'ooo-oo-',
        '-ooooo-',
        '---oo--'
    ]);


solve(
    [
    '-oo',
    'ooo',
    'ooo'
    ]);