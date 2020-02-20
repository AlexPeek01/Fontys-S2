// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
function ReadPageSize() {
    var el = $(".example"),
        bgWidth = 20,
        bgHeight = 20;

    el.css({
        "background-position": (el.width() - bgWidth + 10) + "px " + (el.height() - bgHeight - 10) + "px"
    });
}