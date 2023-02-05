function setLinksOutline(urlPos, byClass, toClass) {
    var current = 0;
    var navbarElems = document.getElementsByClassName(byClass);
    var urlFirstEndpoint = document.URL.toLowerCase().split('/');

    for (var i = 0; i < navbarElems.length; i++) {
        var splitted = navbarElems[i].href.toLowerCase().split('/');
        console.log(splitted[urlPos] + ' : ' + urlFirstEndpoint[urlPos]);
        if (splitted[urlPos] === urlFirstEndpoint[urlPos]) {
            current = i;
        }
    }

    navbarElems[current].className = toClass;
}