var breedeggproductionUpdateWindow
var breedeggproductiongrid

function updatebreedeggproduction(e, link) {
    e.preventDefault();
    $.get(link.href, null, function (response) {
        breedeggproductionUpdateWindow.open();
        breedeggproductionUpdateWindow.center();
        breedeggproductionUpdateWindow.content(response);

    });
    }
function deletebreedeggproduction(e, element) {
    e.preventDefault();
    if (window.confirm("are you sure you want to permanently remove this record? ")) {

        $.ajax({
            type: "POST",
            url: element.action,
            data: null,
            success: function (data, statusCode, xhr) {
                if (data === 1) {
                   breedeggproductiongrid.dataSource.read();
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
    breedeggproductionUpdateWindow = $('#window-update-breedeggproduction').data('kendoWindow');
    breedeggproductiongrid = $('#BreedEggProductionid').data('kendoGrid');
    $('#btn-add-breedeggproduction').click(function (e) {
        $.get($(this).attr('href'), null, function (response) {
            breedeggproductionUpdateWindow.content(response);
            breedeggproductionUpdateWindow.open();
            breedeggproductionUpdateWindow.center();
        });
        e.preventDefault();
    });

    $('body').on('submit', '#form-add-breedeggproduction', function (e) {
        e.preventDefault();
                $.post($(this).attr('action'), $(this).serialize(), function (response) {
            if (response == 1) {
                breedeggproductionUpdateWindow.close();
                breedeggproductiongrid.dataSource.read();
            } else {
                breedeggproductionUpdateWindow.content(response);

            }

        });


    });

})
