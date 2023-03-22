function Collapse(elementId) {
    if (document.getElementById(elementId) !== null) {
        new bootstrap.Collapse(document.getElementById(elementId), {
            toggle: false
        }).toggle();
    }
}

function Hide(elementId) {
    if (document.getElementById(elementId) !== null) {
        new bootstrap.Collapse(document.getElementById(elementId), {
            toggle: false
        }).hide();
    }
}