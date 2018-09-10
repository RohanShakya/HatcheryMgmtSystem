$(document).ready(function () {
    //navbar 
    var $activeLi = $('.nav').find(".active");
  
    var $attr = $activeLi.find('a').attr('aria-label');
    console.log($attr +" from topmenu");

    
    var $submenu = $('.sub').find('.' + $attr);
    $submenu.css("display", "block");


    //nabar dropdown
    //var $dropdown = $(".dropdown-toggle");

    //$dropdown.hover(function () {
    //    console.log($(this).parent(".dropdown").find(".dropdown-menu"));
    //    var $dropmenu = $(this).parent(".dropdown");
    //    $dropmenu.toggleClass("open");
    //    $dropmenu.find(".dropdown-toggle").attr("aria-expanded","true")
    //    })
    //navbar dropdwon
    //nabar
});

//making li active
$(".menu>li").each(function () {
    var navItem = $(this);
    if (navItem.find('a').attr('href') == location.pathname) {
        console.log("inside if");
        $(this).addClass("active");
    }

})

//drop on hover
$(".mainA").hover(
    function () {
    $(".menuLi .mainA").each(function () {
        var $has = $(this).hasClass("open");
        console.log($has);
    });
    var $parent = $(this).parent(".menuLi");
    $parent.addClass("open");
    $parent.find(".drop-menu").css("display", "block");
    console.log($parent.find(".drop-menu"))
    },

    function () {
    var $parent = $(this).parent(".menuLi");
    $parent.removeClass("open");
    var $dropmenu = $parent.find(".drop-menu");
    $dropmenu.css("display", "none");
    $dropmenu.hover(
        function () {
            $dropmenu.css("display", "block");
        },
        function () {
            $dropmenu.css("display", "none");
        })
    })

