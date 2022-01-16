$(document).ready(function(){
	/*search*/
	$('.search input[type="text"]').on({
        focusin: function(){
            $('html, body, .search').addClass('searching');
            }, focusout: function(){
            $('html, body, .search').removeClass('searching');
             }
     });
	/*open menu*/
	$(".hamburger").click(function(){
	        $("body,html").addClass('menu-toggle');
	        $(".hamburger").addClass('active');
	    });
	    $(".m-overlay").click(function(){
	        $("body,html").removeClass('menu-toggle');
	        $(".hamburger").removeClass('active');
	    });
  
	$('#ticker').tickerme();
});
