$(document).ready(function () {
  
});

var $sidetog = $('.tog');
$sidetog.click(function () {
    var $menu = $(this).parent("#sidemenu");
    var $menuli = $menu.find(".sidemenuli");
    console.log($menuli);
    $menuli.find("li").each(function () {
        if ($sidetog.find("a>i").hasClass("glyphicon-arrow-left")) {
            $(this).find('a>span').hide();
        }
        else {
            $(this).find('a>span').show();
        }

    })
    if ($sidetog.find("a>i").hasClass("glyphicon-arrow-left")) {
        $menu.css("min-width", "auto");
        $sidetog.find("a>i").removeClass("glyphicon-arrow-left").addClass("glyphicon-arrow-right");
    }
    else {
        $menu.css("min-width", "150px");
        $sidetog.find("a>i").removeClass("glyphicon-arrow-right").addClass("glyphicon-arrow-left");
    }
    

});