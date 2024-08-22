"use strict";


// SLIDER

let leftIcon = document.querySelector(".slider .icons .left-icon");
let rightIcon = document.querySelector(".slider .icons .right-icon");


function rightSlider() {
  let activeImage = document.querySelector(".active-image");
  activeImage.classList.remove("active-image");
  if (activeImage.nextElementSibling != null) {
    activeImage.nextElementSibling.classList.add("active-image");
  } else {
    rightIcon.parentNode.nextElementSibling.firstElementChild.classList.add("active-image");
  }
}


function leftSlider() {
  let activeImage = document.querySelector(".active-image");
  activeImage.classList.remove("active-image");
  if (activeImage.previousElementSibling != null) {
    activeImage.previousElementSibling.classList.add("active-image");
  } else {
    this.parentNode.nextElementSibling.lastElementChild.classList.add("active-image");
  }
}

rightIcon.addEventListener("click", rightSlider);

leftIcon.addEventListener("click", leftSlider);

rightIcon.addEventListener("mouseover", rightSlider);
leftIcon.addEventListener("mouseover", leftSlider);


setInterval(() => {
  rightSlider();
}, 2000);


//#region sidebar
$(".bars").click(function (e) {
  e.preventDefault();
  $(".right-side-menu").addClass("opened");
  $(".right-side-menu").removeClass("closed");
});

$(".close").click(function (e) {
  e.preventDefault();
  $(".right-side-menu").removeClass("opened");
  $(".right-side-menu").addClass("closed");
});

//#endregion



var btn = document.getElementsByClassName("btn");
var slide = document.getElementById("slide-row");

btn[0].onclick = function () {
  slide.style.transform = "translateX(-0px)";
}
btn[1].onclick = function () {
  slide.style.transform = "translateX(-800px)";
}
btn[2].onclick = function () {
  slide.style.transform = "translateX(-1600px)";
}
btn[3].onclick = function () {
  slide.style.transform = "translateX(-2400px)";
}


//search

var searchBox = $(".box");
$('.icon-search, .icon-close').on("click", function(){
 searchBox.toggleClass("open");
 
})

$(document).ready(function () {
  $(".owl-carousel").owlCarousel();
});


//endregion

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
//user dropdown

let dropdowns = document.querySelector(".dropdown-menu")

// INSTAGRAM

$(document).ready(function () {
  $(".instagram").owlCarousel(
    {
      items: 4,
      loop: true,
      autoplay: true,
      responsive: {
        0: {
          items: 1
        },
        576: {
          items: 2
        },
        768: {
          items: 3
        },
        992: {
          items: 4
        }
      }
    }
  );


});


