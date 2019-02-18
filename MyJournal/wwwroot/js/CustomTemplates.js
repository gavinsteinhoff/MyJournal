$(document).ready(function () {
    //This selectes the select html element
    let select = $("#template");

    //This uses loads in the js script with the text
    $.getScript("../js/templates/templateA.js", function () { });
    //this adds an html option element to the select element
    select.append('<option value="A">Template A</option>');

    $.getScript("../js/templates/templateB.js", function () { });
    select.append('<option value="B">Template B</option>');
    
    $.getScript("../js/templates/templateC.js", function () { });
    select.append('<option value="C">Template C</option>');

    $("select#template").change(function () {
        var template = $(this).children("option:selected").val();
        switch (template) {
            //If seleected, this will be called
            //the case is the same as the option value defined above
            case "A":
                //This just gets the text from the template js file that was loaded above
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