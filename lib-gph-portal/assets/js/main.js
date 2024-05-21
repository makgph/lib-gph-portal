$(function() {
    
    "use strict";
    
    //===== Prealoder
    
    $(window).on('load', function(event) {
        $('.preloader').delay(500).fadeOut(500);
    });
    
    
    //===== Sticky

    $(window).on('scroll', function (event) {
        var scroll = $(window).scrollTop();
        if (scroll < 20) {
            $(".navbar-area").removeClass("sticky");
            $(".navbar-brand img").attr("src", "assets/images/logo.svg");
        } else {
            $(".navbar-area").addClass("sticky");
            $(".navbar-brand img").attr("src", "assets/images/logo.svg");
        }
    });

    
    //===== Section Menu Active

    var scrollLink = $('.page-scroll');
    // Active link switching
    $(window).scroll(function () {
        var scrollbarLocation = $(this).scrollTop();

        scrollLink.each(function () {

            var sectionOffset = $(this.hash).offset() - 73;

            if (sectionOffset <= scrollbarLocation) {
                $(this).parent().addClass('active');
                $(this).parent().siblings().removeClass('active');
            }
        });
    });
    
    
   

    
    //===== Sidebar

    $('[href="#side-menu-left"], .overlay-left').on('click', function (event) {
        $('.sidebar-left, .overlay-left').addClass('open');
    });

    $('[href="#close"], .overlay-left').on('click', function (event) {
        $('.sidebar-left, .overlay-left').removeClass('open');
    });
    
    
    //===== Slick

    $('.slider-items-active').slick({
        infinite: true,
        slidesToShow: 3,
        slidesToScroll: 1,
        speed: 800,
        arrows: true,
        prevArrow: '<span class="prev"><i class="lni lni-arrow-left"></i></span>',
        nextArrow: '<span class="next"><i class="lni lni-arrow-right"></i></span>',
        dots: false,
        autoplay: true,
        autoplaySpeed: 5000,
        responsive: [
            {
                breakpoint: 1200,
                settings: {
                    slidesToShow: 3,
                }
            },
            {
                breakpoint: 992,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 768,
                settings: {
                    slidesToShow: 2,
                }
            },
            {
                breakpoint: 576,
                settings: {
                    slidesToShow: 1,
                    arrows: false,
                }
            }
        ]
    });
    
    
    //===== Isotope Project 4

    $('.container').imagesLoaded(function () {
        var $grid = $('.grid').isotope({
            // options
            transitionDuration: '1s',
            originLeft: false,
            

        });
     


        // filter items on button click
        $('.portfolio-menu ul').on('click', 'li', function () {
            var filterValue = $(this).attr('data-filter');
            $grid.isotope({
                filter: filterValue,
               
            });
        });

        //for menu active class
        $('.portfolio-menu ul li').on('click', function (event) {
            $(this).siblings('.active').removeClass('active');
            $(this).addClass('active');
            event.preventDefault();
        });
    });
    
    
    //===== slick new-of-library Four
    
    $('.new-of-library-active').slick({
        dots: true,
        arrows: true,
        prevArrow: '<span class="prev"><i class="lni lni-chevron-left-circle"></i></span>',
        nextArrow: '<span class="next"><i class="lni lni-chevron-right-circle"></i></span>',
        infinite: true,
       autoplay: true,
        autoplaySpeed: 5000,
        speed: 800,
        slidesToShow:3,
        responsive: [
            {
              breakpoint: 478,
              settings: {
                slidesToShow: 1,
                slidesToScroll:1,
              }
            }
        ]
        
    });
    
    $('.goals-slider').slick({
      dots: true,
      arrows: true,
      prevArrow: '<span class="prev"><i class="lni  lni-arrow-left-circle"></i></span>',
      nextArrow: '<span class="next"><i class="lni lni-arrow-right-circle"></i></span>',
      infinite: true,
    
      rtl: true,
      slidesToShow:3,
      
      responsive: [
          {
            breakpoint: 478,
            settings: {
              slidesToShow: 1,
              slidesToScroll:1,
            }
          }
      ]
      
  });
  
    //====== Magnific Popup
    
    $('.video-popup').magnificPopup({
        type: 'iframe'
        // other options
    });
    
    
    //===== Magnific Popup
    
    $('.image-popup').magnificPopup({
      type: 'image',
      gallery:{
        enabled:true
      }
    });
    
    
    //===== Back to top
    
    // Show or hide the sticky footer button
    $(window).on('scroll', function(event) {
        if($(this).scrollTop() > 600){
            $('.back-to-top').fadeIn(200)
        } else{
            $('.back-to-top').fadeOut(200)
        }
    });
    
    
    //Animate the scroll to yop
    $('.back-to-top').on('click', function(event) {
        event.preventDefault();
        
        $('html, body').animate({
            scrollTop: 0,
        }, 1500);
    });
    
    
    //===== 
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
});
(function() {
  "use strict";

  /**
   * Easy selector helper function
   */
  const select = (el, all = false) => {
    el = el.trim()
    if (all) {
      return [...document.querySelectorAll(el)]
    } else {
      return document.querySelector(el)
    }
  }

  /**
   * Easy event listener function
   */
  const on = (type, el, listener, all = false) => {
    if (all) {
      select(el, all).forEach(e => e.addEventListener(type, listener))
    } else {
      select(el, all).addEventListener(type, listener)
    }
  }

  /**
   * Easy on scroll event listener 
   */
  const onscroll = (el, listener) => {
    el.addEventListener('scroll', listener)
  }

  /**
   * Navbar links active state on scroll
   */
  let navbarlinks = select('#navbar .scrollto', true)
  const navbarlinksActive = () => {
    let position = window.scrollY + 200
    navbarlinks.forEach(navbarlink => {
      if (!navbarlink.hash) return
      let section = select(navbarlink.hash)
      if (!section) return
      if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
        navbarlink.classList.add('active')
      } else {
        navbarlink.classList.remove('active')
      }
    })
  }
  window.addEventListener('load', navbarlinksActive)
  onscroll(document, navbarlinksActive)

  /**
   * Scrolls to an element with header offset
   */
  const scrollto = (el) => {
    let header = select('#header')
    let offset = header.offsetHeight

    if (!header.classList.contains('header-scrolled')) {
      offset -= 10
    }

    let elementPos = select(el).offsetTop
    window.scrollTo({
      top: elementPos - offset,
      behavior: 'smooth'
    })
  }

  /**
   * Toggle .header-scrolled class to #header when page is scrolled
   */
  let selectHeader = select('#header')
  if (selectHeader) {
    const headerScrolled = () => {
      if (window.scrollY > 100) {
        selectHeader.classList.add('header-scrolled')
      } else {
        selectHeader.classList.remove('header-scrolled')
      }
    }
    window.addEventListener('load', headerScrolled)
    onscroll(document, headerScrolled)
  }

  /**
   * Back to top button
   */
  let backtotop = select('.back-to-top')
  if (backtotop) {
    const toggleBacktotop = () => {
      if (window.scrollY > 100) {
        backtotop.classList.add('active')
      } else {
        backtotop.classList.remove('active')
      }
    }
    window.addEventListener('load', toggleBacktotop)
    onscroll(document, toggleBacktotop)
  }

  /**
   * Mobile nav toggle
   */
  on('click', '.mobile-nav-toggle', function(e) {
    select('#navbar').classList.toggle('navbar-mobile')
    this.classList.toggle('lni-list')
    this.classList.toggle('lni-close')
  })

  /**
   * Mobile nav dropdowns activate
   */
  on('click', '.navbar .dropdown > a', function(e) {
    if (select('#navbar').classList.contains('navbar-mobile')) {
      e.preventDefault()
      this.nextElementSibling.classList.toggle('dropdown-active')
    }
  }, true)

  /**
   * Scrool with ofset on links with a class name .scrollto
   */
  on('click', '.scrollto', function(e) {
    if (select(this.hash)) {
      e.preventDefault()

      let navbar = select('#navbar')
      if (navbar.classList.contains('navbar-mobile')) {
        navbar.classList.remove('navbar-mobile')
        let navbarToggle = select('.mobile-nav-toggle')
        navbarToggle.classList.toggle('lni-list')
        navbarToggle.classList.toggle('lni-close')
      }
      scrollto(this.hash)
    }
  }, true)

 







})();
$(".default_option").click(function(){
    $(".dropdown ul").addClass("active");
  });
  
  $(".dropdown ul li").click(function(){
    var text = $(this).text();
    $(".default_option").text(text);
    $(".dropdown ul").removeClass("active");
  });

      
  $(".regular").slick({
    dots: false,
    infinite: true,
    slidesToShow: 4,
    slidesToScroll:1,
   
    autoplaySpeed: 2000,
    responsive: [
        {
          breakpoint: 478,
          settings: {
            slidesToShow: 1,
            slidesToScroll:1,
          }
        }
    ]
  });
  
//   $(".news-headlines").slick({
    
//     autoplay: true,
//     arrows: false,
   
//     slidesToShow: 5,
//     centerPadding: "10px",
  
//     vertical: true,
//     speed: 1000,
//     autoplaySpeed: 2000,
   
 
// });
$(document).ready(function () {
  $(".video-gallery").magnificPopup({
    delegate: "a",
    type: "iframe",
    gallery: {
      enabled: true
    }
  });
});

  $(function () {
    "use strict";
  
    var          hl,
           newsList = $('.news-headlines'),
      newsListItems = $('.news-headlines li'),
      firstNewsItem = $('.news-headlines li:nth-child(1)'),
        newsPreview = $('.news-preview'),
            elCount = $('.news-headlines').children(':not(.highlight)').index(),
           vPadding = (parseInt(firstNewsItem.css('padding-top').replace('px', ''), 10)) +
                      (parseInt(firstNewsItem.css('padding-bottom').replace('px', ''), 10)),
            vMargin = (parseInt(firstNewsItem.css('margin-top').replace('px', ''), 10)) +
                      (parseInt(firstNewsItem.css('margin-bottom').replace('px', ''), 10)),
           cPadding = (parseInt($('.news-content').css('padding-top').replace('px', ''), 10)) +
                      (parseInt($('.news-content').css('padding-bottom').replace('px', ''), 10)),
              speed = 5000, // this is the speed of the switch
            myTimer = null,
           siblings = null,
        totalHeight = null,
            indexEl = 1,
                  i = null;
  
    // the css animation gets added dynamicallly so 
    // that the news item sizes are measured correctly
    // (i.e. not in mid-animation)
    // Also, appending the highlight item to keep HTML clean
    newsList.append('<li class="highlight nh-anim"></li>');
    hl = $('.highlight');
    newsListItems.addClass('nh-anim');
  
    function doEqualHeight(c) {
  
      if (newsPreview.height() < newsList.height()) {
        newsPreview.height(newsList.height());
      } else if ((newsList.height() < newsPreview.height()) && (newsList.height() > parseInt(newsPreview.css('min-height').replace('px', ''), 10))) {
        newsPreview.height(newsList.height());
      }
  
      if ($('.news-content:nth-child(' + c + ')').height() > newsPreview.height()) {
        newsPreview.height($('.news-content:nth-child(' + c + ')').height() + cPadding);
      }
    }
  
    function doTimedSwitch() {
  
      myTimer = setInterval(function () {
        if (($('.selected').prev().index() + 1) === elCount) {
          firstNewsItem.trigger('click');
        } else {
          $('.selected').next(':not(.highlight)').trigger('click');
        }
      }, speed);
  
    }
  
    $('.news-content').on('mouseover', function () {
      clearInterval(myTimer);
    });
  
    $('.news-content').on('mouseout', function () {
        doTimedSwitch();
    });
  
    function doClickItem() {
  
      newsListItems.on('click', function () {
  
        newsListItems.removeClass('selected');
        $(this).addClass('selected');
  
        siblings = $(this).prevAll();
        totalHeight = 0;
  
        // this loop calculates the height of individual elements, including margins/padding
        for (i = 0; i < siblings.length; i += 1) {
            totalHeight += $(siblings[i]).height();
            totalHeight += vPadding;
            totalHeight += vMargin;
        }
  
        // this moves the highlight vertically the distance calculated in the previous loop
        // and also corrects the height of the highlight to match the current selection
        hl.css({
          top: totalHeight,
          height: $(this).height() + vPadding
        });
  
        indexEl = $(this).index() + 1;
  
        $('.news-content:nth-child(' + indexEl + ')').siblings().removeClass('top-content');
        $('.news-content:nth-child(' + indexEl + ')').addClass('top-content');
        clearInterval(myTimer);
        doTimedSwitch();
        doEqualHeight(indexEl);
      });
    }
  
    function doWindowResize() {
      $(window).resize(function () {
        clearInterval(myTimer);
        // click is triggered to recalculate and fix the highlight position
        $('.selected').trigger('click');
      });
    }
  
    doClickItem();
    doWindowResize();
    $('.selected').trigger('click');
  });

  function appear() {
  document.getElementsByClassName("listening-to")[0].classList.add("on-screen");
}

function disappear() {
  setTimeout(func = () => {
               document
    .getElementsByClassName("listening-to")[0]
    .classList.remove("on-screen");
             
             },2000)

}



$('#hamburger').click(function() {
  $('#hamburger').toggleClass('show');
  $('#overlay').toggleClass('show');
  $('.nav').toggleClass('show');
});

$(document).ready(function(){
  $(".dropdown").hover(function(){
      var dropdownMenu = $(this).children(".dropdown-menu");
      if(dropdownMenu.is(":visible")){
          dropdownMenu.parent().toggleClass("open");
      }
  });

});
$('.dropdown').on('shown.bs.dropdown', function () {
  $( ".dropdown" ).removeClass( "show" );
$( ".dropdown-menu" ).removeClass( "show" );
})

var acc = document.getElementsByClassName("accordion-item");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function () {
    this.classList.toggle("active");
  });
}

    var height = document.getElementsByClassName("accordion-content").offsetHeight;
    console.log(height);


    $(".regular-news").slick({
    
      dots: true,
      infinite: true,
      autoplay: true,
    
      rtl: true,
      slidesToShow:2,
      slidesToScroll: 1,
      responsive: [
          {
            breakpoint: 478,
            settings: {
              slidesToShow: 1,
              slidesToScroll:1,
            }
          }
      ]
    });



    ////to close search dropdown
    $(document).click(function(event) {
      if ($(event.target).closest('.search_box').length) {
          
      }else{
          $(".ul-boxsearch").removeClass("active");
      }
  });

  //chatbot
  
  var element = $('.floating-chat');
  var myStorage = localStorage;
  
  if (!myStorage.getItem('chatID')) {
      myStorage.setItem('chatID', createUUID());
  }
  
  setTimeout(function() {
      element.addClass('enter');
  }, 1000);
  
  element.click(openElement);
  
  function openElement() {
      var messages = element.find('.messages');
      var textInput = element.find('.text-box');
      element.find('>i').hide();
      element.addClass('expand');
      element.find('.chat').addClass('enter');
      var strLength = textInput.val().length * 2;
      textInput.keydown(onMetaAndEnter).prop("disabled", false).focus();
      element.off('click', openElement);
      element.find('.header button').click(closeElement);
      element.find('#sendMessage').click(sendNewMessage);
      messages.scrollTop(messages.prop("scrollHeight"));
  }
  
  function closeElement() {
    element.find('.chat').removeClass('enter').hide();
    element.find('>i').show();
    element.removeClass('expand');
    element.find('.header button').off('click', closeElement);
    element.find('#sendMessage').off('click', sendNewMessage);
    element.find('.text-box').off('keydown', onMetaAndEnter).prop("disabled", true).blur();
    setTimeout(function() {
        element.find('.chat').removeClass('enter').show()
        element.click(openElement);
    }, 500);
}

function createUUID() {
    // http://www.ietf.org/rfc/rfc4122.txt
    var s = [];
    var hexDigits = "0123456789abcdef";
    for (var i = 0; i < 36; i++) {
        s[i] = hexDigits.substr(Math.floor(Math.random() * 0x10), 1);
    }
    s[14] = "4"; // bits 12-15 of the time_hi_and_version field to 0010
    s[19] = hexDigits.substr((s[19] & 0x3) | 0x8, 1); // bits 6-7 of the clock_seq_hi_and_reserved to 01
    s[8] = s[13] = s[18] = s[23] = "-";

    var uuid = s.join("");
    return uuid;
}

function sendNewMessage() {
    var userInput = $('.text-box');
    var newMessage = userInput.html().replace(/\<div\>|\<br.*?\>/ig, '\n').replace(/\<\/div\>/g, '').trim().replace(/\n/g, '<br>');

    if (!newMessage) return;

    var messagesContainer = $('.messages');

    messagesContainer.append([
        '<li class="self">',
        newMessage,
        '</li>'
    ].join(''));

    // clean out old message
    userInput.html('');
    // focus on input
    userInput.focus();

    messagesContainer.finish().animate({
        scrollTop: messagesContainer.prop("scrollHeight")
    }, 250);
}

function onMetaAndEnter(event) {
    if ((event.metaKey || event.ctrlKey) && event.keyCode == 13) {
        sendNewMessage();
    }
}
  