function noScroll(id) {
    $(id).on('focus', function (e) {
        e.preventDefault(); e.stopPropagation();
        window.scrollTo(0, 0);
    });
}