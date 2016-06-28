var text = getText();
console.log(replaceATag(text));


function getText() {
    var text = '<ul> \n<li> \n<a href=http://softuni.bg>SoftUni</a> \n</li> \n</ul>';
    return text;
}

function replaceATag(htmlText) {
    var regex = /<a([^<>]*href[\s]*=[\s]*"[.*?]"|'[.*?]'|[^\"\']*[\n]*)>([\n]*.*?([\n]*))<\/a>/m;
    var match = regex.exec(htmlText);
    htmlText = htmlText.toString().replace(regex, "[URL$1]$2[/URL]");

    return htmlText;
}