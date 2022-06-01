export function focusInput(id) {
    document.getElementById(id).focus();
}
//export function noScroll(id) {
//    $(id).on('focus', function (e) {
//        e.preventDefault(); e.stopPropagation();
//        window.scrollTo(0, 0);
//    });
//}
export function scrollToTop() {
    window.scrollTo(0, 0);
}