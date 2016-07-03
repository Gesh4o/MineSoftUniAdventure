function solve(args) {
    "use strict";

    function isValidAuthenticationType(methodType, credentialsType) {
        if (credentialsType === 'Basic' &&
            (methodType === 'POST' ||
            methodType === 'PUT' ||
            methodType === 'DELETE')) {
            return false;
        }

        return true;
    }

    function isValidAuthorizationToken(credentialsKey, hashCode) {
        for (let index = 0; index < hashCode.length; index += 2) {
            let expectedCount = +hashCode[index];
            let char = hashCode[index + 1];

            if (!(/[a-zA-Z]/g).exec(char)){
                throw new SQLException();
            }

            let actualCount = 0;
            for (let ch of credentialsKey) {
                if (ch.toLowerCase() === char.toLowerCase()) {
                    actualCount++;
                }
            }

            if (actualCount === expectedCount) {
                return true;
            }
        }

        return false;

    }

    let hashCode = args[args.length - 1];
    let credentialsRegex = /Credentials: (Basic|Bearer) ([a-zA-Z0-9]+)$/m;
    let contentRegex = /Content: ([a-zA-Z\.0-9]+)$/m;
    for (let i = 0; i < args.length - 1; i += 3) {
        let methodInfo = args[i].split(/\s+/);
        let methodType = methodInfo[1];

        if (methodType !== 'POST' &&
            methodType !== 'PUT' &&
            methodType !== 'DELETE' &&
            methodType !== 'GET'){
            console.log('Response-Code:400');
            continue;
        }

        let credentialsMatch = credentialsRegex.exec(args[i + 1]);
        let credentialsType;
        let credentialsKey;
        if (credentialsMatch) {
            credentialsType = credentialsMatch[1];
            credentialsKey = credentialsMatch[2];
        } else {
            console.log('Response-Code:400');
            continue;
        }

        let contentMatch = contentRegex.exec(args[i + 2]);
        let content;
        if (contentMatch) {
            content = contentMatch[1];
        }
        else {
            console.log('Response-Code:400');
            continue;
        }

        if (!isValidAuthenticationType(methodType, credentialsType)) {
            console.log('Response-Method:' + methodType + '&Code:401');
            continue;
        }

        if (!isValidAuthorizationToken(credentialsKey, hashCode)) {
            console.log('Response-Method:' + methodType + '&Code:403');
            continue;
        }

        let regex = /[^0-9a-zA-Z]+/m;
        if(regex.exec(hashCode)){
            throw new SQLException();
        }

        console.log('Response-Method:' +
            methodType +
            '&Code:200&Header:' +
            credentialsKey);

    }
}

solve([
    'Method: PUT',
    'Credentials: Bearer as9133jsdbhjslkfqwkqiuwjoxXJIdahefJAB',
    'Content: users.asd/1782452$278///**asd123',
    'Method: POST',
    'Credentials: Bearer 028591u3jtndkgwndskfjwelfqkjwporjqebhas',
    'Content: Johnathan',
    'Method: delete',
    'Credentials: Bearer ee',
    'Content: This.is.a.sample.content',
    '2e5g']);