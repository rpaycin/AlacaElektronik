 $( function() {  
    jQuery.validator.addMethod("phoneno", function(phone_number, element) {
            phone_number = phone_number.replace(/\s+/g, "");
            return this.optional(element) || phone_number.length >= 6  && 
            phone_number.match(/^((\+[1-9]{1,4}[ \-]*)|(\([0-9]{2,3}\)[ \-]*)|([0-9]{2,4})[ \-]*)*?[0-9]{3,4}?[ \-]*[0-9]{3,4}?$/);
        }, "<br />Please specify a valid phone number");
   $.validator.addMethod('filesize', function(value, element, param) {
        return this.optional(element) || (element.files[0].size <= param) 
    }); 
// jQuery.noConflict();

     $("#contact1").validate({
        rules: {
           
            namehere: {
                required: true,
               
                
                 maxlength: 30,
            },
            
            email: {
                required: true,
                email: true
            },
            contactt: {
                maxlength: 15,
                required: true,
                 phoneno:true
            },
           
            interested:{
                required: true,
            },

            message_contact:{
                required: true,
            },
            file:{
               filesize: 3145728,

            },


        },
        messages: {
            namehere: {
                required: " Name is required.",
                 maxlength: "Sorry Only 30 Characters Allowed",
            },
            
            email: {
                required: "Email is required.",
            },
            contactt: {
                 required: "Phone number is required.",
                 maxlength: "Sorry Only 15 Characters Allowed",
            },
            file:"File must be less than 3mb",
        },

    });
    $("#apply_job_form").validate({
        rules: {
            namehere: {
                required: true,               
                 maxlength: 30,
            },
            email: {
                required: true,
                email: true
            },
            contactt: {
                maxlength: 15,
                required: true,
                 phoneno:true
            },
            message_contact:{
                required: true,
            },
            file:{
               filesize: 3145728,
            },
        },
        messages: {
            namehere: {
                required: " Name is required.",
                 maxlength: "Sorry Only 30 Characters Allowed",
            },  
            email: {
                required: "Email is required.",
            },
            contactt: {
                 required: "Phone number is required.",
                 maxlength: "Sorry Only 15 Characters Allowed",
            },
            file:"File must be less than 3mb",
        },
    }); 
 });
$(document).on("click","#send_carrer_data",function(){
    var form = $(document).find("#apply_job_form");
        var form = $(form)[0];
        var $form =  $(document).find("#apply_job_form");
        $form.validate();
        if(! $form.valid()) return false;
        var data = new FormData(form);   
        
        $.ajax({
        cache: false,
        url: "//www.esferasoft.com/api/career.php",
        type: 'POST',  
            contentType: false,
            processData: false, 
        data:data,
        success: function (response) {
            var obj = JSON.parse(response);
             console.log(obj.status);                                                  
            if(obj.status == "true")
            {
                console.log("edr");
                window.location.href = "/thanks-page";
                 
            }
            if(obj.status == false)
            {
                alert("Some thing Wrong, Please try Again");            
            }         
         }
    });     
});  

$(document).on("click",".send_btn_contact_form",function(){

    
     // $('#file').on('change', function() { 
     //        const size =  (this.files[0].size / 1024 / 1024).toFixed(2); 
     //        console.log(size)
     //        if (size > 5 ) {
     //            console.log("file size very large") 
     //            $("#file_up").show()
     //            return false;
     //        }      
     //    })
        var callingCode =  $(document).find(".iti__flag-container .iti__selected-flag").attr('title');
        console.log(callingCode);
        $(document).find("#calling_code").val(callingCode);
        var form = $(document).find("#contact1");
        var form = $(form)[0];
        var $form =  $(document).find("#contact1");
        $form.validate();
        if(! $form.valid()) return false;
        // var check_country_code = $(document).find( "#valid-msg" ).attr('class');
        // console.log(check_country_code);
        // if(check_country_code == "hide")
        // {
        //   console.log(check_country_code);
        //     return false; 
        // }
        console.log($form.valid()+"hgahaha"); 
          $(this).prop('disabled', true);
        

        var data = new FormData(form);   
        
        $.ajax({
        cache: false,
        url: "//www.esferasoft.com/api/email1.php",
        type: 'POST',  

            contentType: false,
            processData: false, 
        // dataType: "json",
        data:data,
        success: function (response) {
            var obj = JSON.parse(response);
             console.log(obj.status);                                                  
            if(obj.status == "true")
            {
                    console.log("edr");
                  window.location.href = "/thanks-page";
                 // window.location.href = "https://www.esferasoft.com/thanks-page/";
            }
            if(obj.status == false)
            {
                
                
                
            }
            
            
         }
      });

         });

$(document).ready(function () {
                    $(".tab").click(function () {
                        $(".tab").removeClass("active");
                        $(this).addClass("active");
                    });
                    history.pushState("", document.title, window.location.pathname + window.location.search);


                });
                $('#interested').on('change', function () { 

                    var interestedid = $(this).val();
                    if (interestedid == "Others") {
                        $("#otherList").css({
                            "display": "block"
                        });
                        $("#other").attr("required", true);
                    } else {
                        $('#other').removeAttr('required');
                        $("#otherList").css({
                            "display": "none"
                        });

                    }
                });

                function scrollToTop() {
                    $(window).scrollTop(0);
                }
$('#file').on('change', function(e) { 
    const size =  (this.files[0].size / 1024 / 1024).toFixed(2); 
    var fileName = e.target.files[0].name;
    $(document).find('.file_upload_detail').show();
    $(document).find('.file_upload_detail').text(fileName);
     
})
 $(".notifiation-close-icon").click(function(){
      $("#hide_noti").slideUp(800);
      $('#header').animate({'top': '0'}, 800);
     
  });
 $(document).on('click', '.redirect', function(){
  var location = $(this).attr("href");
  window.location.href = location;
  window.location(location);
});
if ($("#contact1").is(":visible")) {
var input = document.querySelector("#phone");
    window.intlTelInput(input, {
      // allowDropdown: false,
      // autoHideDialCode: false,
      // autoPlaceholder: "off",
      // dropdownContainer: document.body,
      // excludeCountries: ["us"],
      // formatOnDisplay: false,
      // geoIpLookup: function(callback) {
      //   $.get("http://ipinfo.io", function() {}, "jsonp").always(function(resp) {
      //     var countryCode = (resp && resp.country) ? resp.country : "";
      //     callback(countryCode);
      //   });
      // },
      // hiddenInput: "full_number",
      // initialCountry: "auto",
      // localizedCountries: { 'de': 'Deutschland' },
      // nationalMode: false,
      // onlyCountries: ['us', 'gb', 'ch', 'ca', 'do'],
      // placeholderNumberType: "MOBILE",
      // preferredCountries: ['cn', 'jp'],
      // separateDialCode: true,
      utilsScript: "js/utils.js",
    }); 
    
}

 $("#sixty_button,#ready_button"). on('click', function(event) 
        {
            var target = $(this. getAttribute('href')); 
            event. preventDefault();
            $('html, body').animate({
                scrollTop: $(target).offset().top
            }, 4000);
        });
		
