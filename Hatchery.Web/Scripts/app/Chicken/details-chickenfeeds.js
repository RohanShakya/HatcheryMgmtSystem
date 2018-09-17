var chickenfeedsupdatewindow;
var chickenfeedsgrid;

function updatechickenfeeds(e, link) {
    e.preventDefault();
    $.get(link.href, null, function (response) {
        chickenfeedsupdatewindow.open();
        chickenfeedsupdatewindow.center();
        chickenfeedsupdatewindow.content(response);

    });

}
function deletechickenfeeds(e, element) {
    e.preventDefault();
    if (window.confirm("are you sure you want to permanently remove this record? ")) {

        $.ajax({
            type: "POST",
            url: element.action,
            data: null,
            success: function (data, statusCode, xhr) {
                if (data === 1) {
                    chickenfeedsgrid.dataSource.read();
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
    chickenfeedsupdatewindow = $('#window-update-chickenfeeds').data('kendoWindow');
    chickenfeedsgrid = $('#ChickenFeedGrid ').data('kendoGrid');
    //$('#btn-add-chickenfeeds').click(function (e) {
      
    //    $.get($(this).attr('href'), null, function (response) {
    //        chickenfeedsupdatewindow.content(response);
    //        chickenfeedsupdatewindow.open();
    //        chickenfeedsupdatewindow.center();
    //    });
    //    e.preventDefault();
    //});

    $('body').on('submit', '#form-add-chickenfeeds', function (e) {
        e.preventDefault();
       
        $.post($(this).attr('action'), $(this).serialize(), function (response) {
            if (response == 1) {
                chickenfeedsupdatewindow.close();
                chickenfeedsgrid.dataSource.read();
            } else {
                chickenfeedsupdatewindow.content(response);

            }

        });


    });

})


