function solve(args) {
    "use strict";

    let regex = /#([a-zA-Z][\w\-]{2,})/g;
    let isInCodeTag = false;
    let openingCodeTag = "<code>";
    let closingCodeTag = "</code>";
    let charForBannedUser = "*";
    let bannedUsers = args[args.length - 1].split(/\s+/);
    for (let index = 0; index < args.length - 1; index++) {
        let line = args[index];

        let match = regex.exec(line);
        if (match) {
            while (match) {
                let username = match[1];
                if (line.indexOf(openingCodeTag) === -1 && !isInCodeTag) {
                    if (bannedUsers.indexOf(username) === -1) {
                        let userHyperlink = `<a href="/users/profile/show/${username}">${username}</a>`;
                        args[index] = line.replace(match[0], userHyperlink);
                    } else {
                        let bannedString = Array(match[0].length).join(charForBannedUser);
                        args[index] = line.replace(match[0], bannedString);
                    }
                } else if (line.indexOf(openingCodeTag) !== -1 && !isInCodeTag) {
                    isInCodeTag = true;

                    // ToDo: check if opening tag is before or after match.
                } else if (isInCodeTag) {
                    if (line.indexOf(closingCodeTag) !== -1) {
                        isInCodeTag = false;
                    }

                    // ToDo: check for closing tag.
                }

                match = regex.exec(line);
            }
        } else {
            if (line.indexOf(openingCodeTag) !== -1) {
                isInCodeTag = true;
            }

            if (line.indexOf(closingCodeTag) !== -1) {
                isInCodeTag = false;
            }

        }

    }


    delete args[args.length - 1];
    console.log(args.join("\n"));
}

solve(
    [
    '< code >',
    '#gosho',
    '#pesho',
    '#madafaka',
    '</code>',
    '#1nval1d says yoo',
    '#another_invalid_ says gz gg gj',
    '#Make_me_a_LINK!',
    'gosho pesho'
])
;