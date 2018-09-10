var breedmortalityUpdateWindow;
var breedmortalitygrid;

function updatebreedmortality(e, link) {
    e.preventDefault();
    $.get(link.href, null, function (response) {
        breedmortalityUpdateWindow.open();
        breedmortalityUpdateWindow.center();
        breedmortalityUpdateWindow.content(response);

    });

}
function deletebreedmortality(e, element) {
    e.preventDefault();
    if (window.confirm("are you sure you want to permanently remove payment Type ")) {

        $.ajax({
            type: "POST",
            url: element.action,
            data: null,
            success: function (data, statusCode, xhr) {
                if (data === 1) {
                    breedmortalitygrid.dataSource.read();
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
    breedmortalityUpdateWindow = $('#window-update-breedmortality').data('kendoWindow');
    breedmortalitygrid = $('#grid').data('kendoGrid');
    $('#btn-add-BreedMortality').click(function (e) {
        $.get($(this).attr('href'), null, function (response) {
            breedmortalityUpdateWindow.content(response);
            breedmortalityUpdateWindow.open();
            breedmortalityUpdateWindow.center();
        });
        e.preventDefault();
    });

    $('body').on('submit', '#form-add-breedmortality', function (e) {
        e.preventDefault();

        $.post($(this).attr('action'), $(this).serialize(), function (response) {
            if (response == 1) {
                breedmortalityUpdateWindow.close();
                breedmortalitygrid.dataSource.read();
            } else {
                breedmortalityUpdateWindow.content(response);

            }

        });


    });

})
