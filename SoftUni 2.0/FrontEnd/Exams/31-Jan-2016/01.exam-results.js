function solve(args) {
    "use strict";

    let courses = {};
    for (let index = 0; index < args.length - 1; index++) {
        let courseArgs = args[index].split(/\s+/g).filter(function (e) {
            return e;
        });

        let studentName = courseArgs[0];
        let courseName = courseArgs[1];
        let examPoints = +courseArgs[2];
        let bonusPoints = +courseArgs[3];

        if (!courses[courseName]) {
            courses[courseName] = [];
        }

        let coursePoints = (examPoints / 5) + bonusPoints;
        let grade = ((coursePoints / 80) * 4) + 2;
        if (grade > 6) {
            grade = 6;
        }

        if (examPoints < 100) {
            console.log(`${studentName} failed at "${courseName}"`);
        } else {
            console.log(`${studentName}: Exam - "${courseName}"; Points - ${parseFloat(coursePoints.toFixed(2))}; Grade - ${grade.toFixed(2)}`);
        }

        courses[courseName].push({examPoints: examPoints});
    }

    let courseWanted = args[args.length - 1].trim();
    let examResultSum = 0;

    let examResultAvg = 0;
    if (courseWanted in courses) {
        for (let student of courses[courseWanted]) {
            examResultSum += student.examPoints;
        }

        if (courses[courseWanted].length == 0) {
            examResultAvg = 0;
        } else {
            examResultAvg = parseFloat((examResultSum / courses[courseWanted].length).toFixed(2));
        }
    }

    console.log(`"${courseWanted}" average points -> ${examResultAvg}`);
}