$(document).ready(function() {
    $('.nav-toggle').click(function(){
    var collapse_content_selector = $(this).attr('href');		
    var toggle_switch = $(this);
      $('.btn-group').removeClass('selected');
      if($(collapse_content_selector).css('display')=='none'){
        $('.btn-group').hide();
       
      }
     
    $(collapse_content_selector).toggle(function(){
  
      if($(this).css('display')=='none'){
        toggle_switch.parent().parent().removeClass('selected');
     
      }else{
        toggle_switch.parent().parent().addClass('selected');
       $(this).css("display", "flex");
      
      }
    });
    });
  })
  // function hide id  collapse3 when click img
  
  function hideAll(){
      $('#collapse3').hide(); 
     }
     
    $('#switch-img1').click(function() {
      hideAll();
    
    })
  
    $('#switch-img2').click(function() {
      hideAll();
      
    })
    $('#switch-img3').click(function() {
      hideAll();
      
    })
  
  
    function hideAll(){
    $('#collapse3').hide();
    
    } 
  
    function imgSmile(){
      hideAll();
    } ;

    // // themecolors
document.body.classList.add(localStorage.getItem("pageColor") || "root");
var el = document.querySelectorAll('.color-switcher li');
var classesList = [];

 // loop on elements
  for (var i = 0 ; i < el.length; i++) {
   //get classes list
   classesList.push(el[i].getAttribute('data-color'));
   el[i].addEventListener("click",function(){
     //remove all old classes
     document.body.classList.remove(...classesList);
     document.body.classList.add(this.getAttribute("data-color"));
     //add data to local storage
     localStorage.setItem("pageColor",this.getAttribute("data-color"));
   },
   false
   );
 }
 var theInterval;

 $(document).ready(function() { 
  $.rvFontsize({
      targetSection: '.post',
      store: true, // store.min.js required!
      controllers: {
          appendTo: '.rvfs-controllers',
          showResetButton: true
      }
  }); 
});