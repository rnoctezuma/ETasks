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
}());

function moveRight(e) {
    var leftList = e.target.closest(".form").querySelector('.leftList'),
        j;
    if (leftList.options.selectedIndex == -1) {
        alert("Nothing selected");
    }
    var rightList = e.target.closest(".form").querySelector('.rightList');

    for (j = 0; j < leftList.options.length; j++) {
        if (leftList.options[j].selected) {
            rightList.appendChild(leftList.options[j]);
            j--;
        }
    }
    rightList.selectedIndex = -1;
}

function moveRightAll(e) {
    var leftList = e.target.closest(".form").querySelector('.leftList'),
        rightList = e.target.closest(".form").querySelector('.rightList'),
        j;

    for (j = 0; j < leftList.options.length; j++) {
        rightList.appendChild(leftList.options[j]);
        j--;
    }
    rightList.selectedIndex = -1;
}

function moveLeft(e) {
    var rightList = e.target.closest(".form").querySelector('.rightList');
    if (rightList.options.selectedIndex == -1) {
        alert("Nothing selected");
    }
    var leftList = e.target.closest(".form").querySelector('.leftList');

    for (var j = 0; j < rightList.options.length; j++) {
        if (rightList.options[j].selected) {
            leftList.appendChild(rightList.options[j]);
            j--;
        }
    }
    leftList.selectedIndex = -1;
}

function moveLeftAll(e) {
    var rightList = e.target.closest(".form").querySelector('.rightList'),
        leftList = e.target.closest(".form").querySelector('.leftList'),
        j;

    for (j = 0; j < rightList.options.length; j++) {
        leftList.appendChild(rightList.options[j]);
        j--;
    }
    leftList.selectedIndex = -1;
}