/*$('.dropdwn').click(function () {
    $('#options').toggleClass('showoptions');

    if ($('#options').hasClass('showoptions')) {
        alert('yes');
        $('#options').removeClass('showoptions');
    }
    else {
        $('#options').addClass('showoptions');
        alert('added');
    }
});*/

$(function () {
    $(".dropdwn").on("click", function (e) {
        $("#options").toggleClass("showoptions");
        $("#angle").toggleClass("rotate");
    });
    $(document).on("click", function (e) {
        if ($(e.target).is(".dropdwn, #options") === false) {
            $("#options").removeClass("showoptions");
            $("#angle").removeClass("rotate");
        }
    });
});

$(function () {
    $("#notifications").on("click", function (e) {
        $("#notificationContainer").toggleClass("showNotificationContainer");
    });


    $(document).on("click", function (e) {
        if ($(e.target).is("#notifications, #notificationContainer") === false) {
            $("#notificationContainer").removeClass("showNotificationContainer");
        }
    });
});


