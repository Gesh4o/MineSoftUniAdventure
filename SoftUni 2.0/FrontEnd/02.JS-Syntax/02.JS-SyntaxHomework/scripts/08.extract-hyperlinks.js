function extractLinks(args) {
    var regex = /<a[^>]*href\s*=[\W]*?[\n]*\s*(("(.*?)")|([^'\s]+?)(>|<|\s)|('(.*?)'(<|\s|>)))/g;
    var result = new Array();
    var html = args.join('\n');

    var match;
    while (match = regex.exec(html)) {
        var groupThree = match[3];
        var groupFour = match[4];
        var groupSeven = match[7];
        if (groupThree !== undefined) {
            result.push(groupThree);
        }
        else if (groupFour !== undefined) {
            result.push(groupFour);
        }
        else if (groupSeven !== undefined) {
            result.push(groupSeven);
        }
        /*
        var hrefValue = match[3];
        if (hrefValue == undefined) {
            var hrefValue = match[4];
        }
        if (hrefValue == undefined) {
            var hrefValue = match[7];
        }
        console.log(hrefValue);
        */

    }

    return result.join("\n");
}