$(function () {
    $(document).on('click', '.add-product-basket', function (e) {
        e.preventDefault();
        let id = parseInt($(this).attr("data-id"));

        $.ajax({
            url: `Home/AddProductToBasket?id=${id}`,
            type: 'POST',
            success: function (response) {
                $(".product-count").text(response.count);
                toastr["success"]("Product added to basket")
                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
            },
            error: function (response) {
                toastr["error"]("Login to add product to basket")
                toastr.options = {
                    "closeButton": false,
                    "debug": false,
                    "newestOnTop": false,
                    "progressBar": false,
                    "positionClass": "toast-top-right",
                    "preventDuplicates": false,
                    "onclick": null,
                    "showDuration": "300",
                    "hideDuration": "1000",
                    "timeOut": "5000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                }
            }
        });
    })
})
//search

var searchBox = $(".box");
$('.icon-search, .icon-close').on("click", function () {
    searchBox.toggleClass("open");

})

var thumbs = $('.img-selection').find('img');
thumbs.click(function () {
    var src = $(this).attr('src');
    var dp = $('.display-img');
    var img = $('.zoom');
    dp.attr('src', src);
    img.attr('src', src);
});

$(".product-image").click(function () {
    $('.product-image').removeClass('selected');
    $(this).addClass('selected');
});


var zoom = $('.active-preview-image').find('img').attr('src');
$('.active-preview-image').append('<img class="zoom" src="' + zoom + '">');
$('.active-preview-image').mouseenter(function () {
    $(this).mousemove(function (event) {
        var offset = $(this).offset();
        var left = event.pageX - offset.left;
        var top = event.pageY - offset.top;

        $(this).find('.zoom').css({
            width: '200%',
            opacity: 1,
            left: -left,
            top: -top,
        });
    });
});

$('.active-preview-image').mouseleave(function () {
    $(this).find('.zoom').css({
        width: '100%',
        opacity: 0,
        left: 0,
        top: 0,
    });
});