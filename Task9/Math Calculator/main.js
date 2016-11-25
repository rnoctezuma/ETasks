function main() {
    var sourceLine,
        regexExpression = /(?:d+\.d+)|(?:d+)|(?:[\+\-\*\/])/g;
    sourceLine = document.getElementById("text_input").value; //-3.5 землекопа +4 поросенка *10 рублей - 5.5 $ /5 человек =

    alert(matchCalculator(sourceLine.match(regexExpression)).toFixed(2));
}


function matchCalculator(numberMatches) {
    var result = 0;
    var operator = '';
    for (var i = 0; i < numberMatches.length; i++) {
        if (numberMatches[i] == '+' || numberMatches[i] == '-' || numberMatches[i] == '*' || numberMatches[i] == '/') {
            operator = numberMatches[i];
            continue;
        }

        if (operator == '+') {
            result += +numberMatches[i];
            operator = '';
            continue;
        }
        if (operator == '-') {
            result -= +numberMatches[i];
            operator = '';
            continue;
        }
        if (operator == '*') {
            result *= +numberMatches[i];
            operator = '';
            continue;
        }
        if (operator == '/') {
            result /= +numberMatches[i];
            operator = '';
            continue;
        }
        result = +numberMatches[i];
    }
    return result;

}