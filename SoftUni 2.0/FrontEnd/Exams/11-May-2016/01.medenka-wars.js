function solve(args) {
    "use strict";

    const singleMedenkaDmg = 60;

    let naskorDamageDone = 0;
    let vitkorDamageDone = 0;

    let naskorPreviousAttackDmg = -1;
    let naskorStreak = 0;

    let vitkorPreviousAttackDmg = -1;
    let vitkorStreak = 0;

    for (let line of args) {
        let inputInfo = line.split(/\s+/);
        let medenkaCount = +inputInfo[0];
        let medenkaType = inputInfo[1];

        let medenkaDmg = medenkaCount * singleMedenkaDmg;
        if (medenkaType === 'white') {
            if (medenkaDmg === vitkorPreviousAttackDmg) {
                vitkorStreak++;

                if (vitkorStreak == 2) {
                    medenkaDmg *= 2.75;
                    vitkorStreak = 0;
                }
            } else {
                vitkorPreviousAttackDmg = medenkaDmg;
                vitkorStreak = 1;
            }

            vitkorDamageDone += medenkaDmg;
        } else {
            if (medenkaDmg === naskorPreviousAttackDmg) {
                naskorStreak++;

                if (naskorStreak == 5) {
                    medenkaDmg *= 4.5;
                    naskorStreak = 0;
                }
            } else {
                naskorPreviousAttackDmg = medenkaDmg;
                naskorStreak = 1;
            }

            naskorDamageDone += medenkaDmg;
        }
    }

    let winner = vitkorDamageDone > naskorDamageDone ? 'Vitkor' : 'Naskor';
    let damage = vitkorDamageDone > naskorDamageDone ? vitkorDamageDone : naskorDamageDone;

    console.log('Winner - ' + winner);
    console.log('Damage - ' + damage);
}

solve([
    '2 dark medenkas',
    '1 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas',
    '15 white medenkas',
    '2 dark medenkas',
    '2 dark medenkas'
]);
