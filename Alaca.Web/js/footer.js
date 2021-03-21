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


     jQuery('.slider-for').slick({
       slidesToShow: 1,
       slidesToScroll: 1,
       arrows: false,
       fade: true,
       asNavFor: '.slider-nav'
       });
     jQuery('.slider-nav').slick({
       slidesToShow: 3,
       slidesToScroll: 1,
       asNavFor: '.slider-for',
       dots: true,
       centerMode: true,
       focusOnSelect: true
     });

     jQuery('.mobile-section-7-uber').on( 'click', function()
     {
       jQuery('.mobile-section-7-uber').removeClass('active');
     });
     var TxtRotate = function(el, toRotate, period) {
 this.toRotate = toRotate;
 this.el = el;
 this.loopNum = 0;
 this.period = parseInt(period, 0) || 500;
 this.txt = '';
 this.tick();
 this.isDeleting = false;
};

TxtRotate.prototype.tick = function() {
 var i = this.loopNum % this.toRotate.length;
 var fullTxt = this.toRotate[i];

 if (this.isDeleting) {
   this.txt = fullTxt.substring(0, this.txt.length - 1);
 } else {
   this.txt = fullTxt.substring(0, this.txt.length + 1);
 }

 this.el.innerHTML = '<span class="wrap">'+this.txt+'</span>';

 var that = this;
 var delta = 300 - Math.random() * 100;

 if (this.isDeleting) { delta /= 2; }

 if (!this.isDeleting && this.txt === fullTxt) {
   delta = this.period;
   this.isDeleting = true;
 } else if (this.isDeleting && this.txt === '') {
   this.isDeleting = false;
   this.loopNum++;
   delta = 500;
 }

 setTimeout(function() {
   that.tick();
 }, delta);
};

window.onload = function() {
 var elements = document.getElementsByClassName('txt-rotate');
 for (var i=0; i<elements.length; i++) {
   var toRotate = elements[i].getAttribute('data-rotate');
   var period = elements[i].getAttribute('data-period');
   if (toRotate) {
     new TxtRotate(elements[i], JSON.parse(toRotate), period);
   }
 }
 // INJECT CSS
 var css = document.createElement("style");
 css.type = "text/css";
 css.innerHTML = ".txt-rotate > .wrap { border-right: 0.08em solid #666 }";
 document.body.appendChild(css);
};