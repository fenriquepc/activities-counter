function Collapse(elementId) {
    if (document.getElementById(elementId) !== null) {
        new bootstrap.Collapse(document.getElementById(elementId)).toggle();
    }
}