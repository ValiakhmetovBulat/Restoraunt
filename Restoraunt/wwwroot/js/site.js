function setLinksOutline() {
    var current = 0;
    var navbarElems = document.getElementsByClassName("navbar-link");
    var urlLastEndpoint = document.URL.split('/');
    urlLastEndpoint = urlLastEndpoint[urlLastEndpoint.length - 1].toLowerCase()

    for (var i = 0; i < navbarElems.length; i++) {
        var splitted = navbarElems[i].href.toLowerCase().split('/');
        if (splitted[splitted.length - 1].toLowerCase() === urlLastEndpoint) {
            current = i;
        }
    }

    navbarElems[current].className = 'active-page';

    var current = 0;
    var sections = document.getElementsByClassName("menu-section");

    for (var i = 0; i < sections.length; i++) {
        if (sections[i].href.toLowerCase() === document.URL.toLowerCase()) {
            current = i;
        }
    }

    sections[current].className = 'active-section';
}