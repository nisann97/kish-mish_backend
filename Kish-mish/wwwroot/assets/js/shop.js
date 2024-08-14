    
  //#region header-sticky
   var headerSticky = $("#header-sticky");

   $(window).scroll(function () {
     if ($(window).scrollTop() > 200) {
       headerSticky.addClass("show");
     } else {
       headerSticky.removeClass("show");
     }
   });
   //#endregion


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