var chickenmortalityUpdateWindow
var chickenmortalitygrid;

function updatechickenmortality(e, link) {
    e.preventDefault();
    $.get(link.href, null, function (response) {
        chickenmortalityUpdateWindow.open();
        chickenmortalityUpdateWindow.center();
        chickenmortalityUpdateWindow.content(response);

    });
    }
function deletechickenmortality(e, element) {
    e.preventDefault();
    if (window.confirm("are you sure you want to permanently remove payment Type ")) {

        $.ajax({
            type: "POST",
            url: element.action,
            data: null,
            success: function (data, statusCode, xhr) {
                if (data === 1) {
                   chickenmortalitygrid.dataSource.read();
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
    chickenmortalityUpdateWindow = $('#window-update-ChickenMortality').data('kendoWindow');
    chickenmortalitygrid = $('#chickenmortalityid').data('kendoGrid');
    //$('#btn-add-chickenmortality').click(function (e) {
    //    $.get($(this).attr('href'), null, function (response) {
    //        chickenmortalityUpdateWindow.content(response);
    //        chickenmortalityUpdateWindow.open();
    //        chickenmortalityUpdateWindow.center();
    //    });
    //    e.preventDefault();
    //});

    $('body').on('submit', '#form-add-chickenmortality', function (e) {
        e.preventDefault();

        $.post($(this).attr('action'), $(this).serialize(), function (response) {
            if (response == 1) {
                chickenmortalityUpdateWindow.close();
                chickenmortalitygrid.dataSource.read();
            } else {
                chickenmortalityUpdateWindow.content(response);

            }

        });


    });

})
