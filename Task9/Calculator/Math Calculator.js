(function() {
    var editButton = document.getElementById('calculate');

    editButton.onclick = calculate;

    function calculate(e) {
        var regex = /(?:\d+(?:\.\d+)|\d+)|(?:\+|\-|\/|\*|=)/g,
            symbol = '+-',
            result,
            counter = 0,
            item = 0,
            i,
            items = document.getElementById('inputLine').value.match(regex),
            firstItem = items[0];

        if (items === null) {
            alert("Incorrect Expression");
            return;
        }
        if (symbol.indexOf(firstItem) === -1) {
            result = parseFloat(firstItem);
            counter++;
        } else {
            item++;
            result = parseFloat(firstItem.concat(items[1]));
        }

        for (i = 2; i < items.length; i += 2) {
            switch (items[i - counter]) {
                case '+':
                    {
                        result += parseFloat(items[i + item]);
                        continue;
                    }
                case '-':
                    {
                        result -= parseFloat(items[i + item]);
                        continue;
                    }
                case '/':
                    {
                        result /= parseFloat(items[i + item]);
                        continue;
                    }
                case '*':
                    {
                        result *= parseFloat(items[i + item]);
                        continue;
                    }
                case '=':
                    break;
                default:
                    alert("Incorrect Expression");
                    return;
            }
        }

        if (isNaN(result) || result === parseFloat(firstItem) || items[items.length - 1] !== '\=') {
            alert("Incorrect Expression");
            return;
        } else {
            document.getElementById('inputLine').value = result.toFixed(2);
        }
    }
})();