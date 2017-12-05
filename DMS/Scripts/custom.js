//side nav  
$(document).ready(function() {

    $('#menu-toggle').click(function(e) {
      e.preventDefault();
      $('#wrapper').toggleClass('toggled');
	  $('body').toggleClass('lock');
	  $('#menu-toggle').toggleClass('close-nav');
      $('#overlay').fadeToggle( "slow", "swing" );
    });

    $('#overlay').click(function() {
      $('#overlay').fadeOut('slow');
      $('#wrapper').removeClass('toggled');
	  $('#menu-toggle').removeClass('close-nav');
	  $('body').removeClass('lock');
    });

  });


$(window).on("load",function(){
				
				$("#sidebar-wrapper").mCustomScrollbar({
					autoHideScrollbar:true,
					theme:"rounded"
				});
				
			});
$('.navbar-toggler').click(function(){
    $('.outer_box').toggleClass('show_bar');
});
$('.drop_down').click(function(){
    $(this).toggleClass('open_dropdown');
});