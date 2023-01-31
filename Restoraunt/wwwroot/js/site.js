function setLinksOutline() {
    var current = 0;
    var navbarElems = document.getElementsByClassName("navbar-link");

    for (var i = 0; i < navbarElems.length; i++) {
        if (navbarElems[i].href.toLowerCase() === document.URL.toLowerCase()) {
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