$(".stat").click(function () {
    $('.stat').not(this).each(function () {
        $(this).removeClass("active");
    });
    $(this).addClass("active");
});