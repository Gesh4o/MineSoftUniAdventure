function solve(inputArgs) {
    "use strict";

    let tasks = [];
    for (let line of inputArgs) {
        let taskInfo = line.split(/&/g).map(s => s.trim()).filter(function (e) {
            return e;
        });

        let name = taskInfo[0];
        let type = taskInfo[1];
        let number = +taskInfo[2];
        let score = +taskInfo[3];
        let linesOfCode = +taskInfo[4];

        let objectName = number;
        if (!(objectName in tasks)) {
            tasks[objectName] = {average: 0, lines: 0};
        }

        if (!('tasks' in tasks[objectName])) {
            tasks[objectName]['tasks'] = [];
        }
        let taskObj = {name: name, type: type};
        tasks[objectName]['tasks'].push(taskObj);
        tasks[objectName]['average'] += score;
        tasks[objectName]['lines'] += linesOfCode;
        tasks[objectName]['number'] = number;
    }

    for (let taskName in tasks) {
        if (tasks.hasOwnProperty(taskName)) {
            tasks[taskName].average = parseFloat((tasks[taskName].average / tasks[taskName]['tasks'].length).toFixed(2));
            tasks[taskName]['tasks'] = tasks[taskName]['tasks'].sort(function (t1, t2) {
                return t1.name > t2.name;
            });
        }
    }

    tasks = tasks.sort(function (firstTask, secondTask) {
        if (firstTask.average === secondTask.average) {
            return firstTask.lines - secondTask.lines;
        } else {
            return secondTask.average - firstTask.average;
        }
    });

    let object ={};
    for (let taskName in tasks) {
        if (tasks.hasOwnProperty(taskName)) {
            let objectName = "Task " + tasks[taskName].number;
            object[objectName] = {};
            object[objectName]['tasks'] = tasks[taskName].tasks;
            object[objectName]['average'] = tasks[taskName].average;
            object[objectName]['lines'] = tasks[taskName].lines;
        }
    }

    console.log(JSON.stringify(object));
}

solve([
    'Array Matcher & strings & 4 & 100 & 38',
    'Magic Wand & draw & 3 & 100 & 15',
    'Dream Item & loops & 2 & 88 & 80',
    'Knight Path & bits & 5 & 100 & 65',
    'Basket Battle & conditionals & 2 & 100 & 120',
    'Torrent Pirate & calculations & 1 & 100 & 20',
    'Encrypted Matrix & nested loops & 4 & 90 & 52',
    'Game of bits & bits & 5 &  100 & 18',
    'Fit box in box & conditionals & 1 & 100 & 95',
    'Disk & draw & 3 & 90 & 15',
    'Poker Straight & nested loops & 4 & 40 & 57',
    'Friend Bits & bits & 5 & 100 & 81'
]);