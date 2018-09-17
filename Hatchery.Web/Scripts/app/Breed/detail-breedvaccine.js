var breedvaccineupdatewindow;
var breedvaccinegrid;

function updatebreedvaccine(e, link) {
    e.preventDefault();
    $.get(link.href, null, function (response) {
        breedvaccineupdatewindow.open();
        breedvaccineupdatewindow.center();
        breedvaccineupdatewindow.content(response);

    });

}
function deletebreedvaccine(e, element) {
    e.preventDefault();
    if (window.confirm("are you sure you want to permanently remove this record? ")) {

        $.ajax({
            type: "POST",
            url: element.action,
            data: null,
            success: function (data, statusCode, xhr) {
                if (data === 1) {
                    breedvaccinegrid.dataSource.read();
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
    breedvaccineupdatewindow = $('#window-update-breedvaccine').data('kendoWindow');
    breedvaccinegrid = $('#Breedvaccinegrid ').data('kendoGrid');
    $('#btn-add-breedvaccine').click(function (e) {
      
        $.get($(this).attr('href'), null, function (response) {
            breedvaccineupdatewindow.content(response);
            breedvaccineupdatewindow.open();
            breedvaccineupdatewindow.center();
        });
        e.preventDefault();
    });

    $('body').on('submit', '#form-add-breedvaccine', function (e) {
        e.preventDefault();
       
        $.post($(this).attr('action'), $(this).serialize(), function (response) {
            if (response == 1) {
                breedvaccineupdatewindow.close();
                breedvaccinegrid.dataSource.read();
            } else {
                breedvaccineupdatewindow.content(response);

            }

        });


    });

})


