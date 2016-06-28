function concerts(args) {
    var concertInfo = {};
    for (var lineIndex in args) {
        var tokens = args[lineIndex].split('|');
        var band = tokens[0].trim();
        var town = tokens[1].trim();
        var date = tokens[2].trim();
        var venue = tokens[3].trim();

        if (!concertInfo[town]) {
            concertInfo[town] = {};
        }
        if (!concertInfo[town][venue]) {
            concertInfo[town][venue] = [];
        }
        if (concertInfo[town][venue].indexOf(band) == -1) {
            concertInfo[town][venue].push(band);
        }
    }
    concertInfo = sortObjectProperties(concertInfo);
    for (var town in concertInfo) {
        concertInfo[town] = sortObjectProperties(concertInfo[town]);
        for (var venue in concertInfo[town]) {
            concertInfo[town][venue].sort();
        }
    }
    console.log(JSON.stringify(concertInfo));

    function sortObjectProperties(obj) {
        var keysSorted = Object.keys(obj).sort();
        var sortedObj = {};
        for (var i = 0; i < keysSorted.length; i++) {
            var key = keysSorted[i];
            sortedObj[key] = obj[key];
        }
        return sortedObj;
    };

}