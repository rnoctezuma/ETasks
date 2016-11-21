var separators = ['.', ' ', '?', '\t', ',', ':', '!'];
function editLine() {
    var sourceLine;
    sourceLine = document.getElementById("text_input").value;
    temp(sourceLine + " ");
    // alert(sourceLine);
}

function temp(s) {
    var startWordIndex;
    var endWordIndex;
    var array = [];
    for (var i = 0; i < s.length - 1; i++) {
        if (separators.indexOf(s[i]) === -1) {
            startWordIndex = i;
            endWordIndex = i;

            while (true) {
                i++;
                if (separators.indexOf(s[i]) === -1) {
                    endWordIndex++;
                }
                else {
                    array.push(s.slice(startWordIndex, endWordIndex + 1));
                    break;
                }
            }
        }
    }

    alert();
    for (var i = 0; i < array.length; i++) {
        alert(array[i]);
    }
}