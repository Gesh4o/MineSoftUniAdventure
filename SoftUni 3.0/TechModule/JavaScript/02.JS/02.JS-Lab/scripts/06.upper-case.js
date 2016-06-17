function solve(args) {
    var words = args.join(",").split(/\W+/).filter(w => w.length > 0).filter(isUppercase);
    console.log(words.join(", "));

    function isUppercase(word) {
        for(var c of word){
            if(c !== c.toUpperCase())
            {
                return false;
            }
        }

        return true;
    }
}