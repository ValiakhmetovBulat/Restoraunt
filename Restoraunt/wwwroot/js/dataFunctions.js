function getCurrentDate() {
    let date = new Date();
    date = (date.toISOString().split('T')[0]);
    return date;
}

function setMaxDate() {
    var elem = document.getElementById("dateOfVisit");
    elem.setAttribute("max", getCurrentDate());
}