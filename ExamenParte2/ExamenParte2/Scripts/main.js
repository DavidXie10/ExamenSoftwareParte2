function increment(inputId) {
    let input = document.getElementById(inputId);
    input.value = parseInt(input.value) + 1;
    console.log(input.value);
}

function decrement(inputId) {
    let input = document.getElementById(inputId);
    if (parseInt(input.value) - 1 >= 0) {
        input.value = input.value - 1;
    }
    console.log(input.value);
}

function hide(elementId) {
    document.getElementById(elementId).style.display = "none";
}

function show(elementId) {
    document.getElementById(elementId).style.display = "block";
}