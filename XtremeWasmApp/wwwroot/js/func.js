function noScroll() {
    var funct = (id) => {
        document.getElementById(id).onfocus = function (e) {
            e.preventDefault();
            e.stopPropagation();
            window.scrollTo(0, 0);
            document.body.scrollTop = 0;
            setTimeout(function () { window.scrollTo(0, 0); }, 0);
        }
        document.getElementById(id).onblur = function (e) {
            e.preventDefault();
            e.stopPropagation();
            window.scrollTo(0, 0);
            document.body.scrollTop = 0;
            setTimeout(function () { window.scrollTo(0, 0); }, 0);
        }
    }
    funct('MixDigitInput');
    funct('Prize2');
    funct('Prize1');
}