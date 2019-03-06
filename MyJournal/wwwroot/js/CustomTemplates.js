let templates = [];
$(document).ready(function () {

    //This selectes the select html element
    let select = $("#template");

    //This uses loads in the js script with the text
    $.getScript("../js/templates/templateA.js", function () { });
    $.getScript("../js/templates/templateB.js", function () { });
    $.getScript("../js/templates/templateC.js", function () { });
        
    //This waits for all the scripts to load then add an option html elemtent to the select element for each one
    setTimeout(function () {
        for (let i = 0; i < templates.length; ++i) {
            select.append(`<option value='${i}'>${templates[i].name}</option>`);
        }
        select.removeAttr("hidden");
    }, 500);

    $("select#template").change(function () {
        var template = $(this).children("option:selected").val();
        //detects a selected option then loops through till it finds the matching one
        let found = false;
        for (let i = 0; i < templates.length; ++i) {
            if (template == i) {
                $('#JournalText').val(templates[i].text);
                found = true;
            }
        }
        if (found != true) {
            $('#JournalText').val("");
        }
    });
});