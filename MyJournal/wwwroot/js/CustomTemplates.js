$(document).ready(function () {
    let select = $("#template");

    $.getScript("../js/templates/templateA.js", function () { });
    select.append('<option value="A">Template A</option>');

    $.getScript("../js/templates/templateB.js", function () { });
    select.append('<option value="B">Template B</option>');
    
    select.append('<option value="C">Template C</option>');
    $.getScript("../js/templates/templateC.js", function () { });

    $("select#template").change(function () {
        var template = $(this).children("option:selected").val();
        switch (template) {
            case "A":
                $('#JournalText').val(templateA);
                break;
            case "B":
                $('#JournalText').val(templateB);
                break;
            case "C":
                $('#JournalText').val(templateC);
                break;
            case "Blank":
                $('#JournalText').val('');
                break;
        }
    });
});