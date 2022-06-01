function noScroll(id) {
    document.getElementById(id).onfocus = function (e) {
        e.preventDefault();
        e.stopPropagation();
        window.scrollTo(0, 0);
        document.body.scrollTop = 0;
    }
}