var chickeneggproductionUpdateWindow;
var chickenegggrid;

function updatechickeneggproduction(e, link) {
    e.preventDefault();
    $.get(link.href, null, function (response) {
        chickeneggproductionUpdateWindow.open();
        chickeneggproductionUpdateWindow.center();
        chickeneggproductionUpdateWindow.content(response);

    });

}
function deletechickeneggproduction(e, element) {
    e.preventDefault();
    if (window.confirm("are you sure you want to permanently remove payment Type ")) {

        $.ajax({
            type: "POST",
            url: element.action,
            data: null,
            success: function (data, statusCode, xhr) {
                if (data === 1) {
                    chickenegggrid.dataSource.read();
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
    chickeneggproductionUpdateWindow = $('#window-update-ChickenEggproduction').data('kendoWindow');
    chickenegggrid = $('#Egg').data('kendoGrid');
//    //$('#btn-add-chickeneggproduction').click(function (e) {
//    //    $.get($(this).attr('href'), null, function (response) {
//    //        chickeneggproductionUpdateWindow.content(response);
//    //        chickeneggproductionUpdateWindow.open();
//    //        chickeneggproductionUpdateWindow.center();
//    //    });
//    //    e.preventDefault();
//    //});

    $('body').on('submit', '#form-add-ChickenEggproduction', function (e) {
        e.preventDefault();

        $.post($(this).attr('action'), $(this).serialize(), function (response) {
            if (response == 1) {
                chickeneggproductionUpdateWindow.close();
                chickenegggrid.dataSource.read();
            } else {
                chickeneggproductionUpdateWindow.content(response);

            }

        });


    });

})
