$('button').click(function () {
    $(this).text(function (i, old) {
        return old == '+' ? '-' : '+';
    });
});