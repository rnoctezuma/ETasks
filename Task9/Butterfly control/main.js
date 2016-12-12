(function() {
    var moveRightElems = document.getElementsByClassName('moveRight'),
        moveLeftElems = document.getElementsByClassName('moveLeft'),
        moveAllRightElems = document.getElementsByClassName('moveRightAll'),
        moveAllLeftElems = document.getElementsByClassName('moveLeftAll');

    for (var i = 0; i < moveRightElems.length; i++) {
        moveRightElems[i].addEventListener('click', moveRight);
    }

    for (var i = 0; i < moveLeftElems.length; i++) {
        moveLeftElems[i].addEventListener('click', moveLeft);
    }

    for (var i = 0; i < moveAllRightElems.length; i++) {
        moveAllRightElems[i].addEventListener('click', moveRightAll);
    }

    for (var i = 0; i < moveAllLeftElems.length; i++) {
        moveAllLeftElems[i].addEventListener('click', moveLeftAll);
    }

    function move(target, destination, source) {
        var sourceList = target.closest(".form").querySelector(source),
            destinationList = target.closest(".form").querySelector(destination),
            j;

        if (sourceList.options.selectedIndex == -1) {
            alert("Nothing selected");
        }

        for (j = 0; j < sourceList.options.length; j++) {
            if (sourceList.options[j].selected) {
                destinationList.appendChild(sourceList.options[j]);
                j--;
            }
        }
        destinationList.selectedIndex = -1;
    }

    function moveAll(target, destination, source) {
        var sourceList = target.closest(".form").querySelector(source),
            destinationList = target.closest(".form").querySelector(destination),
            j;

        for (j = 0; j < sourceList.options.length; j++) {
            destinationList.appendChild(sourceList.options[j]);
            j--;
        }
        destinationList.selectedIndex = -1;
    }

    function moveRight(e) {
        move(e.target, '.rightList', '.leftList');
    }

    function moveLeft(e) {
        move(e.target, '.leftList', '.rightList');
    }

    function moveRightAll(e) {
        moveAll(e.target, '.rightList', '.leftList');
    }

    function moveLeftAll(e) {
        moveAll(e.target, '.leftList', '.rightList');
    }
}());