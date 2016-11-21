var separators = ['.', ' ', '?', '\t', ',', ':', '!'];
function editLine() {
    var sourceLine;
    sourceLine = document.getElementById("text_input").value;
    temp(sourceLine + " ");
    // alert(sourceLine);
}

function temp(s) {
    getCharsToRemove(stringSplit(s));
}

function stringSplit(stringToSplit) {
    var startWordIndex,
        endWordIndex,
        arrayWords = [],
        i = 0;

    for (i; i < stringToSplit.length - 1; i++) {
        if (separators.indexOf(stringToSplit[i]) === -1) {
            startWordIndex = i;
            endWordIndex = i;

            while (true) {
                i++;
                if (separators.indexOf(stringToSplit[i]) === -1) {
                    endWordIndex++;
                }
                else {
                    arrayWords.push(stringToSplit.slice(startWordIndex, endWordIndex + 1));
                    break;
                }
            }
        }
    }

    return arrayWords;
}

function getCharsToRemove(arrayWords) {
    var i = 0,
        j,
        word,
        charsToRemove = [];

    for (i; i < arrayWords.length; i++) {
        word = arrayWords[i];
        for (j = 0; j < word.length; j++) {
            if (word.lastIndexOf(word[j]) != j && charsToRemove.indexOf(word[j]) == -1) {
                charsToRemove.push(word[j]);
            }
        }
    }

    for (i = 0; i < charsToRemove.length; i++) {
        alert(charsToRemove[i]);
    }
}