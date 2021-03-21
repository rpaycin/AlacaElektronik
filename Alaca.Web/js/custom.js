function blog()
    {
        var space = '';
                var fields = '';
                var blog = '';
                $.ajax({
                    url: 'https://www.esferasoft.com/blog/wp-json/wp/v2/posts?per_page=3&_embed',
                    dataType: 'json',
                    type: 'GET',
                    success: function (data) {
                                    console.log(data);                     
                        $.each(data, function (index, item) {
                            console.log();                            
                            var datfield = item.date_gmt;
                            var TodayDate = new Date(datfield);
                            var monthNames = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun',
                                'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'
                            ];
                            var d = TodayDate.getDate();
                            var m = monthNames[TodayDate.getMonth()];
                            var post_data =item.excerpt.rendered;
                            post_data = post_data.substr(3, 80);
                            if (item._embedded['wp:featuredmedia'] != undefined) {
                                   fpath =item.jetpack_featured_media_url;
                                // fpath = item._embedded["wp:featuredmedia"][0].source_url
                            } else {
                                fpath =
                                    "https://www.esferasoft.com/blog/wp-content/themes/blogtheme/assets/images/blog/blog_img1.jpg";
                            }
                            
                            fields +=
                                '<div class=" slick-slide"><div class="post-slide"><div class="post-img"><a href="/blog/' +
                                item.slug + '"><img class="img-responsive" src="' + fpath +
                                '" alt="' + item.title.rendered +
                                '" defer></a><div class="post-date"><span class="date">' +
                                d + '<br>' + m +
                                '</span></div></div><div class="post-content"><h4 class="post-title">' +
                                item.title.rendered + '</h4><a href="/blog/' + item.slug +
                                '" class="read-more text-danger"> <img class="read-more-img" src="/images/read-more-arrow-white.png" alt="read-more" defer> Read More..</a></div></div></div>';
                                 blog+='<div class="col-lg-4 col-md-12 wow zoomIn" data-wow-delay="0.5s">';
                    
                    blog+='<div class="entry entry-small">';
                     
                    blog+='<div class="thumbnail-attachment">';
                    blog+='<a href="/blog/' +
                                item.slug + '"><img width="100%"  alt="' + item.title.rendered +
                                '" src="' + fpath +
                                '"></a>';
                    // blog+='<div class="entry-label">Blockchain</div>';
                    blog+='</div>';
                      
                    blog+='<div class="entry-body">';
                    blog+='<h5 class="entry-title"><a href="/blog/' +
                                item.slug + '">' +
                                item.title.rendered + '</a></h5>';
                    blog+='<div class="entry-meta">';
                    blog+='<time class="entry-date" datetime="2018-12-21">'+ m +d+ '&nbsp; </time><span> </span>';
                    blog+='<a href="/blog/' +item.slug + '" class="entry-cat">' +post_data +' ...'+ '</a>';
                    blog+='<p class="country_link"><a href = "/blog/' +
                                item.slug + '" >Read More</a></p></div>';
                    blog+='</div>';
                    blog+='</div>';
                    blog+='</div>';
                        });
                       
                      
                        $('#all_blog_data').append(fields);
                        $('#blog_data').append(blog);

                        
                    }
                });
    }


$(document).on('ready', function() {

  
	
 setTimeout(function() {
                blog();

              }, 5000);
   setTimeout(function() {
                
                new WOW().init();
              }, 2000);
  // const observer = lozad();
  // observer.observe();  
	$(".apps_slider").slick({
        lazyLoad: 'ondemand', // ondemand progressive anticipated
        infinite: true,
        dots: true,
        centerMode: false,
        arrows: true,
        prevArrow: "<button type='button' class='slick-prev pull-left'><img src='images/left-arrow.png' class='img-fluid' alt=''></button>",
        nextArrow: "<button type='button' class='slick-next pull-right'><img src='images/right-arrow.png' class='img-fluid' alt=''></button>"
    });

	$('.slider_main').slick({
		slidesToShow: 1,
	    // asNavFor: '.slider_thumb',
	    vertical: true,
	    autoplay: true,
	    verticalSwiping: true,
	    centerMode: false,
	    arrows: false
	});

	$('.gallery_slider').slick({
		dots: false,
		arrows: false,
		infinite: true,
		speed: 1500,
		autoplay: true,
		autoplaySpeed: 2000,
		fade: true,
		cssEase: 'ease',
		// pauseOnHover: false
	});

	$('.gallery_slider_02').slick({
		dots: false,
		arrows: false,
		infinite: true,
		speed: 1600,
		autoplay: true,
		autoplaySpeed: 2200,
		fade: true,
		cssEase: 'ease',
		// pauseOnHover: false
	});


	$('.appsrc').slick({
		dots: false,
		arrows: false,
		infinite: true,
		autoplay: true,
		speed: 400,
		autoplaySpeed: 1500,
		centerMode: true,
		slidesToShow: 5,
		responsive: [
		{
			breakpoint: 768,
			settings: {
				slidesToShow: 3
			}
		},
		{
			breakpoint: 480,
			settings: {
				slidesToShow: 1
			}
		}
		]
	});
    jQuery('.mobile-section-10-slider-web').slick({
        centerMode: true,
        centerPadding: 0,
        slidesToShow: 1,
  
        responsive: [
            {
                breakpoint: 768,
                settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '0px',
                slidesToShow: 1
            }
        },
        {  
        breakpoint: 480,
        settings: {
          arrows: false,
          centerMode: true,
          centerPadding: '0px',
          slidesToShow: 1
        }
      }
    ]
    });	
    $('.nav-border ul li').click(function(){
        $('.nav-border ul li').removeClass("acrtive_menu");
        $(this).addClass("acrtive_menu");
        
       
    });
    jQuery('.mobile-section-10-slider').slick({
          centerMode: true,
          centerPadding: 0,
          slidesToShow: 1,
        
          responsive: [
            {
              breakpoint: 768,
              settings: {
                arrows: false,
                centerMode: true,
                centerPadding: 0,
                slidesToShow: 1
              }
            },
            { 
              breakpoint: 480,
              settings: {
                arrows: false,
                centerMode: true,
                centerPadding: 0,
                slidesToShow: 1
              }
            }
          ]
        });
    jQuery('.slid').slick({
            centerMode: true,
            centerPadding: '0px',
            slidesToShow: 3,
        responsive: [
            {
                breakpoint: 768,
                settings: {
                    arrows: false,
                    centerMode: true,
                    centerPadding: '40px',
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 480,
                settings: {
                    arrows: false,
                    centerMode: true,
                    centerPadding: '40px',
                    slidesToShow: 1
                }
            }
        ]
    });

});
$(document).find('.view_f').click(function(){
      var tab_show = $(this).attr('href');    
      $(document).find(tab_show).click();
              
    });
$(document).find('.nav-border ul li a').click(function(){
    var tab_show = $(this).attr('href')
    $(document).find(".tab-content .tab-pane").css("display", "none");
    $(document).find(tab_show).css("display", "block");
});
$("body").scroll(function() {   
    var scroll = $("body").scrollTop(); 
    if (scroll >= 105) {
        $(document).find("#header").addClass("fix");
    } else 
    {
        $(document).find("#header").removeClass("fix");
    }
});


<!--slider -->
jQuery(document).ready(function(){

  });

 var data = {
          labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
          series: [
            [0, 5000, 10000, 15000, 17000, 15000],
            [15000, 8000, 6000, 7000, 10000, 15000]
          ]
        };
        var options = {
          fullWidth: true,
          high: 20000,
          low: 1000,
          showArea: true,
          axisY: {
            labelInterpolationFnc: function (value) {
              return '$' + value;
            },
            scaleMinSpace: 45
          }
        };
        var responsiveOptions = [
          ['screen and (max-width: 769px)', {
            axisX: {
              labelInterpolationFnc: function (value) {
                return value[0];
              }
            }
          }]
        ];
        // new Chartist.Line('.ct-chart6', data, options, responsiveOptions);
        /*Line chart*/
        var data = {
          labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun'],
          series: [
            [0, 5000, 10000, 15000, 17000, 15000],
            [15000, 8000, 6000, 7000, 10000, 15000]
          ]
        };
        var options = {
          fullWidth: true,
          high: 20000,
          low: 1000,
          showArea: true,
          axisY: {
            labelInterpolationFnc: function (value) {
              return '$' + value;
            },
            scaleMinSpace: 45
          }
        };
        var responsiveOptions = [
          ['screen and (max-width: 769px)', {
            axisX: {
              labelInterpolationFnc: function (value) {
                return value[0];
              }
            }
          }]
        ];
        // new Chartist.Line('.ct-chart7', data, options, responsiveOptions);

   

   jQuery(document).ready(function(){
          
        });
        jQuery('.mobile-section-7-uber').on( 'click', function()
      {
        jQuery('.mobile-section-7-uber').removeClass('active');
      });


$(document).ready(function () {
    $(document).find('.fetch_potfolio').click(function(){
        var tableName = $(this).data("id") ;
        var divid =  $(this).children("a").attr("href");
        var data = {  category: tableName, action:"fetch_potfolio" };
        var i = 0;
              $.ajax({
                url:'Admin/lib/crud.php',
                data:data,
                type:'POST',
                dataType: 'JSON',
                success:function(data){
                    var total_pages = data[0].total_records;
                    var html = '<div id="'+divid+'" class="tab-pane active"><div class="row">';
                    $.each(data, function (index, item) {
                      var link = '';
                       if(item.url == null) {link = '#'} else{ link = item.url}
                       var img = ''; 
                       if(item.image == null) {img = 'images/port1.jpg'} else{ img = '/Admin/'+item.image;}
                      
                        html += '<div class="col-lg-6 col-md-6"><div class="sec-portfolio-pd-mb"><div class="port_img object_fit"><div class="overlay"></div><span class="port_tag">'+item.bannerText+'</span><a href="javascript:void(0)"><img width="100%" alt="image" src="'+img+'"></a></div><div id="port-img-btm" class="port_text"><h4>'+item.Heading+'</h4><a class="my_button" href="'+link+'">View More</a></div></div></div>';

                    })
                      html+= '</div> <div class="serch_box"><nav aria-label="Page navigation example"><ul class="pagination">';

                      if(total_pages != null){
                        for(i=1; i<=total_pages; i++){
                          if(i == 1)
                          {
                            html+= '<li class="page-item active pagination" id="'+i+'" data-category="'+tableName+'" data-div="'+divid+'"><button class="page-link btn btn-primary" data-id="'+i+'" >'+i+'</button></li>';
                          }
                          else
                          {
                             html+= '<li class="page-item pagination" id="'+i+'" data-category="'+tableName+'" data-div="'+divid+'"><button class="page-link btn btn-primary"  >'+i+'</button></li>'; 
                          }
                        }
                      }
                      html+= '</ul></nav></div>';
                    $(document).find(".tab-content").append(html);
                }
            });
            // swal("Deleted!", "Your imaginary file has been deleted.", "success");                     
    });    
   
    var portfolio =$(document).find(".fetch_potfolio").length;
    if(portfolio  > 0)
    {
          var tableName = 'webDevelopment' ;
        var divid =  '#cubix1';
        var data = {  category: tableName, action:"fetch_potfolio" };
        var i = 0;
              $.ajax({
                url:'Admin/lib/crud.php',
                data:data,
                type:'POST',
                dataType: 'JSON',
                success:function(data){
                  var total_pages = data[0].total_records;
                    var html = '<div id="'+divid+'" class="tab-pane active"><div class="row">';
                    $.each(data, function (index, item) {
                      var link = '';
                       if(item.url == null) {link = '#'} else{ link = item.url}
                        console.log(link);
                       var img = ''; 
                       if(item.image == null) {img = 'images/port1.jpg'} else{ img = '/Admin/'+item.image;}
                      
                        html += '<div class="col-lg-6 col-md-6"><div class="sec-portfolio-pd-mb"><div class="port_img object_fit"><div class="overlay"></div><span class="port_tag">'+item.bannerText+'</span><a href="javascript:void(0)"><img width="100%" alt="image" src="'+img+'"></a></div><div id="port-img-btm" class="port_text"><h4>'+item.Heading+'</h4><a class="my_button" href="'+link+'">View More</a></div></div></div>';

                    })
                    html+= '</div> <div class="serch_box"><nav aria-label="Page navigation example"><ul class="pagination">';

                      if(total_pages != null){
                        for(i=1; i<=total_pages; i++){
                          if(i == 1)
                          {
                            html+= '<li class="page-item active pagination" id="'+i+'"  data-category="'+tableName+'" data-div="'+divid+'"><button class="page-link btn btn-primary"   data-id="'+i+'">'+i+'</button></li>';
                          }
                          else
                          {
                             html+= '<li class="page-item pagination" id="'+i+'" data-category="'+tableName+'" data-div="'+divid+'"><button class="page-link btn btn-primary"  data-id="'+i+'">'+i+'</button></li>'; 
                          }
                        }
                      }
                      html+= '</ul></nav></div>';
                    $(document).find(".tab-content").append(html);
                }
            });
        
    }
      
    $(document).on('click','ul.pagination li',function(){ $(this).addClass('active').siblings().removeClass('active') 
       
        var tableName = $(this).data("category") ;
        var divid =  $(this).data("div");
        var id = $(this).attr("id");
        
        var data = {  category: tableName, action:"fetch_potfolio",page:id };
        var i = 0;
              $.ajax({
                url:'Admin/lib/crud.php',
                data:data,
                type:'POST',
                dataType: 'JSON',
                success:function(data){
                    var total_pages = data[0].total_records;
                    var html = '<div id="'+divid+'" class="tab-pane active"><div class="row">';
                    $.each(data, function (index, item) {
                      var link = '';
                       if(item.url == null) {link = '#'} else{ link = item.url}
                       var img = ''; 
                       if(item.image == null) {img = 'images/port1.jpg'} else{ img = '/Admin/'+item.image;}
                      
                        html += '<div class="col-lg-6 col-md-6"><div class="sec-portfolio-pd-mb"><div class="port_img object_fit"><div class="overlay"></div><span class="port_tag">'+item.bannerText+'</span><a href="javascript:void(0)"><img width="100%" alt="image" src="'+img+'"></a></div><div id="port-img-btm" class="port_text"><h4>'+item.Heading+'</h4><a class="my_button" href="'+link+'">View More</a></div></div></div>';

                    })
                      html+= '</div> <div class="serch_box"><nav aria-label="Page navigation example"><ul class="pagination">';

                      if(total_pages != null){
                        for(i=1; i<=total_pages; i++){
                          if(i == 1)
                          {
                            html+= '<li class="page-item  pagination" id="'+i+'"  data-category="'+tableName+'" data-div="'+divid+'"><button class="page-link btn btn-primary"  data-id="'+i+'" >'+i+'</button></li>';
                          }
                          else
                          {
                             html+= '<li class="page-item pagination" id="'+i+'" data-category="'+tableName+'" data-div="'+divid+'"><button class="page-link btn btn-primary"  data-id="'+i+'" >'+i+'</button></li>'; 
                          }
                        }
                      }
                      html+= '</ul></nav></div>';
                      $(document).find(".tab-content").html('');
                    $(document).find(".tab-content").append(html);
                }
            });
            // swal("Deleted!", "Your imaginary file has been deleted.", "success");                     
    });    
});

 // $(document).find('.page-link').on("click", function (e) {

