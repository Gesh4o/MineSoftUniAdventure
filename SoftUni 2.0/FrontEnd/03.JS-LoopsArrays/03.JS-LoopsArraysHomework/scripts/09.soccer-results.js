function solve(args) {
    'use strict';
    let ladder = {};
    for (let row = 0; row < args.length; row++) {
        let regex = /\s*([\w\s]+)\s*\/\s*([\w\s]+)\s*:\s*([0-9]+)\-([0-9]+)/g;
        let lineArgs = regex.exec(args[row]);
        let homeTeamName = lineArgs[1].trim();
        let awayTeamName = lineArgs[2].trim();
        let homeTeamGoals = lineArgs[3];
        let awayTeamGoals = lineArgs[4];

        if (!(homeTeamName in ladder)) {
            ladder[homeTeamName] = {
                goalsScored: +homeTeamGoals,
                goalsConceded: +awayTeamGoals,
                matchesPlayedWith: [awayTeamName]
            };
        } else {
            ladder[homeTeamName].goalsScored += +homeTeamGoals;
            ladder[homeTeamName].goalsConceded += +awayTeamGoals;
            if (ladder[homeTeamName].matchesPlayedWith.indexOf(awayTeamName) === -1) {
                ladder[homeTeamName].matchesPlayedWith.push(awayTeamName);
            }
        }

        if (!(awayTeamName in ladder)) {
            ladder[awayTeamName] = {
                goalsScored: +awayTeamGoals,
                goalsConceded: +homeTeamGoals,
                matchesPlayedWith: [homeTeamName]
            };
        }
        else {
            ladder[awayTeamName].goalsScored += +awayTeamGoals;
            ladder[awayTeamName].goalsConceded += +homeTeamGoals;
            if (ladder[awayTeamName].matchesPlayedWith.indexOf(homeTeamName) === -1) {
                ladder[awayTeamName].matchesPlayedWith.push(homeTeamName);
            }
        }
    }

    function sortLadder(ladder) {
        let keys = Object.keys(ladder).sort();
        let sortedLadder = {};
        for (let key of keys) {
            sortedLadder[key] = ladder[key];
        }

        return sortedLadder;
    }

    ladder = sortLadder(ladder);

    for (let team in ladder) {
        ladder[team].matchesPlayedWith.sort();
    }
    console.log(JSON.stringify(ladder));
}

solve([
    'Levski / CSKA: 0-2',
    'Pavlikeni / Loko Gorna: 4-2',
    'Loko Gorna / Levski: 1-4',
    'Litex / Loko Gorna: 0-0',
    'Beroe / Botev Plovdiv: 2-1',
    'Loko Gorna / Beroe: 3-1',
    'Pavlikeni / Ludogorets: 0-2',
    'Loko Sofia / Litex: 0-2',
    'Pavlikeni / Marek: 1-1',
    'Litex / Levski: 0-0',
    'Beroe / Litex: 3-2',
    'Litex / Beroe: 1-0',
    'Ludogorets / Litex: 3-0',
    'Litex / Ludogorets: 1-0',
    'CSKA / Beroe: 1-0',
    'Botev Plovdiv / CSKA: 1-1',
    'Ludogorets / Loko Sofia: 1-0',
    'Litex / CSKA: 0-1',
    'Marek / Haskovo: 0-1',
    'Levski / Loko Gorna: 1-1'
]);