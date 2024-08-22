   

//search
$('.icon-search, .icon-close').on("click", function(){
  $('.box').toggleClass("open");
 
})

$(document).ready(function () {
  $(".owl-carousel").owlCarousel();
});


      //#region back-to-top-button
  var btn = $("#button");

  $(window).scroll(function () {
    if ($(window).scrollTop() > 300) {
      btn.addClass("show");
    } else {
      btn.removeClass("show");
    }
  });

  btn.on("click", function (e) {
    e.preventDefault();
    $("html, body").animate({ scrollTop: 0 }, "300");
  });

  //#endregion