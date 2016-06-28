'use strict';
function countOfDivs(htmlText) {
     let regexPattern = /<[\s]*div/g;
    let count = 0;
    while (regexPattern.exec(htmlText)){
        count++;
    }

    return count;
}

console.log(countOfDivs('<!DOCTYPE html>\n    <html>\n    <head lang="en">\n    <meta charset="UTF-8">\n    <title>index</title>\n    <script src="/yourScript.js" defer></script>\n</head>\n<body>\n<div id="outerDiv">\n    <div\nclass="first">\n    <div><div>hello</div></div>\n    </div>\n    <div>hi<div></div></div>\n    <div>I am a div</div>\n</div>\n</body>\n</html>'));