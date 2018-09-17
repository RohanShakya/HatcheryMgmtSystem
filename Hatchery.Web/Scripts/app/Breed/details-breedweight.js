var chargetypeUpdateWindow;
var breedweightgrid;

function updateBreedWeight(e, link) {
    e.preventDefault();
    $.get(link.href, null, function (response) {
        chargetypeUpdateWindow.open();
        chargetypeUpdateWindow.center();
        chargetypeUpdateWindow.content(response);

    });

}
function deleteBreedWeight(e, element) {
    e.preventDefault();
    if (window.confirm("are you sure you want to permanently remove this record? ")) {

        $.ajax({
            type: "POST",
            url: element.action,
            data: null,
            success: function (data, statusCode, xhr) {
                if (data === 1) {
                    breedweightgrid.dataSource.read();
                    updateBillingDetail();
                }
            },
            error: function (xhr, errorType, exception) { //Triggered if an error communicating with server
                var errorMessage = exception || xhr.statusText; //If exception null, then default to xhr.statusText
                alert(xhr.statusText);
            }

        });

    };
}


$(function () {
    chargetypeUpdateWindow = $('#window-update-breedweight').data('kendoWindow');
    breedweightgrid = $('#BreedWeightId').data('kendoGrid');
    $('#btn-add-breedweight').click(function (e) {

        $.get($(this).attr('href'), null, function (response) {
            chargetypeUpdateWindow.content(response);
            chargetypeUpdateWindow.open();
            chargetypeUpdateWindow.center();
        });
        e.preventDefault();
    });

    $('body').on('submit', '#form-add-breedweight', function (e) {
        e.preventDefault();

        $.post($(this).attr('action'), $(this).serialize(), function (response) {
            if (response == 1) {
                chargetypeUpdateWindow.close();
                breedweightgrid.dataSource.read();
            } else {
                chargetypeUpdateWindow.content(response);

            }

        });

    });

})