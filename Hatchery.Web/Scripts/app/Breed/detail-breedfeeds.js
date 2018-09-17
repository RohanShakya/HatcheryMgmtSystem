var breedfeedsupdatewindow;
var breedfeedsgrid;

function updatebreedfeeds(e, link) {
    e.preventDefault();
    $.get(link.href, null, function (response) {
        breedfeedsupdatewindow.open();
        breedfeedsupdatewindow.center();
        breedfeedsupdatewindow.content(response);




    });

}
function deletebreedfeeds(e, element) {
    e.preventDefault();
    if (window.confirm("are you sure you want to remove this record? ")) {

        $.ajax({
            type: "POST",
            url: element.action,
            data: null,
            success: function (data, statusCode, xhr) {
                if (data === 1) {
                    breedfeedsgrid.dataSource.read();
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
    breedfeedsupdatewindow = $('#window-update-breedfeeds').data('kendoWindow');
    breedfeedsgrid = $('#BreedFeedgrid ').data('kendoGrid');
    $('#btn-add-breedfeeds').click(function (e) {
      
        $.get($(this).attr('href'), null, function (response) {
            breedfeedsupdatewindow.content(response);
            breedfeedsupdatewindow.open();
            breedfeedsupdatewindow.center();
        });
        e.preventDefault();
    });

    $('body').on('submit', '#form-add-breedfeeds', function (e) {
        e.preventDefault();
       
        $.post($(this).attr('action'), $(this).serialize(), function (response) {
            if (response == 1) {
                breedfeedsupdatewindow.close();
                breedfeedsgrid.dataSource.read();
            } else {
                breedfeedsupdatewindow.content(response);

            }

        });


    });

    })


   
