$(function () {
	/*------------Slider------------*/
	if ($(".my-simple-slider").length > 0) {
		var slidesWrapperLi = $(".my-simple-slider li"),
			autoPlayId = {}, //her slider icin ayri gecis ozelliginin tutuldugu dizi
			ts,te,upDown = 0, //ts: tiklandiginde ve basili tutultugunda, te: tiklama, dokunma kaldirildiginde, upDown=1 ise tiklandi, upDown=0 ise birakildi
			autoPlayDelay = 5000; //gecis bekleme suresi
			
		setAutoplay(autoPlayDelay); //otomatik gecis
		
		$(".mys-slider-nav").on("click", "li", function(event){ //slider buton tiklanildiginde
			event.preventDefault();
			var selectedItem = $(this), //tiklanilan li etiketi
				sliderNav = selectedItem.closest(".mys-slider-nav"), //tiklanilan sliderin menu buton kapsayici div
				slidesWrapper = sliderNav.prev(), //tiklanilan slider
				slidesNumber = slidesWrapper.children("li").length; //tiklanilan sliderin sayfa sayisi
			if(!selectedItem.hasClass("selected")) { //tiklanilan sayfa selected olarak atanmadiysa, class i selected degil ise
				var selectedPosition = selectedItem.index(), //tiklanilan li etiketinin index numarasini al
					activePosition = slidesWrapper.find("li.selected").index(); //su an ki aktif slider sayfanin index id sini al
				if( activePosition < selectedPosition) { //tiklanilan sayfa id degeri su an ki aktif sayfa id degerinden buyuk ise
					nextSlide(slidesWrapper.find(".selected"), slidesWrapper, selectedPosition); //ileri efekti verilsin
				} else { //degil ise
					prevSlide(slidesWrapper.find(".selected"), slidesWrapper, selectedPosition); // geri efekti verilsin
				}

				updateSliderNavigation(sliderNav, selectedPosition); //slider menu guncellensin
				setAutoplay(autoPlayDelay,slidesWrapper); //otomatik gecis guncellensin
			}
		});
		
		function nextSlide(visibleSlide, container, n){ //sayfalar arasi sagdan sola gecis efekti
			visibleSlide.removeClass("selected").addClass("is-moving").one("webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend", function(){
				$(this).css("left","0px");
			}); //sayfalar arasi gecis efekti
			var selectedLi = container.children("li").eq(n); //tiklanilan sayfa
			selectedLi.addClass("selected").prevAll().addClass("move-left"); //secili, aktif hale getir, diger butun sayfalari pasif yap
		}

		function prevSlide(visibleSlide, container, n){ //sayfalar arasi soldan saga gecis efekti
			visibleSlide.removeClass("selected").addClass("is-moving").one("webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend", function(){
				$(this).css("left","0px");
			}); //sayfalar arasi gecis efekti
			var selectedLi = container.children("li").eq(n); //tiklanilan sayfa
			selectedLi.addClass("selected").removeClass("move-left").nextAll().removeClass("move-left"); //secili, aktif hale getir, diger butun sayfalari pasif yap
		}

		function setAutoplay(delay,slidesWrapper) { //class="mys-autoplay" degerine sahip slider elemanlara otomatik gecis ozelligi
			slidesWrapper = slidesWrapper?slidesWrapper:""; //ie hatasi cozumu
			/*
				slidesWrapper: Gecis yapmak istenilen, tiklanilan sayfanin  slider nesnesi 
				bu deger var ise sayfada tiklanarak veya dokunarak gecis yapilmak istenmis demektir.
			*/
			if ($(".mys-autoplay").length > 0 && !slidesWrapper){ //site ilk yuklendiginde
				var i=0;
				$(".mys-autoplay").each(function(){ //otomatik gecis istenen butun slider elemanlarini gez
					var slidesWrapper = $(this), //slideri al
						mysID = ''; //autoPlayID icin kullanilacak, her slider icin belirtec id
					if (!slidesWrapper.attr("id")){ //clearInterval isleminin basarili olmasi icin sliderlere id atamasi yapiyoruz, sadece sayfa yuklendiginde 1 kere calissin
						mysID = "mys-id-"+i;
						slidesWrapper.attr("id",mysID)
						i++;
					}
					var sliderElementLength = slidesWrapper.children("li").length; //slider sayfa sayisi
					/*
						her slider icin otomatik gecis dongu islemi ayri ayri uygulansin ve bu islem bir diziye aktarilsin
						slider menuye veya slidere tiklanilip sayfalar arasi gecis yapilmak istenir ise bu dizi degerleri uzerinden 
						erisim saglayip, o ssliderin slider gecis silecegiz ve tekrar olusturacagiz 
						yani her slider icin gecis efekti bekleme suresini guncelliyoruz. 
						Boylelikle gecis efekti hatasi olmayacak, sliderlar arasi gecis karisikligi olmayacak
					*/
					/*
						site acildiginde otomatik gecis guncellenir ve aktif olur
						autoPlayDelay degerine yazilan saniye kadar sonra otomatik olarak sayfa gecisleri baslar
					*/
					autoPlayId[mysID] = window.setInterval(function(){ //autoPlayDelay saniye de bir autoplaySlider fonksiyonu calisir
						autoplaySlider(slidesWrapper,sliderElementLength)
					}, autoPlayDelay); //autoPlayDelay deki saniye degeri kadar otomatik gecis bekleme suresi
				});
			}else if ($(".mys-autoplay").length > 0 && slidesWrapper && slidesWrapper.hasClass("mys-autoplay")){ //sayfaya tiklanildiginde
				var mysID = slidesWrapper.attr("id"),
					sliderElementLength = slidesWrapper.children("li").length;
				clearInterval(autoPlayId[mysID]); //sayfa gecisi yapilmak istenen slider uzerindeki gecis efekti sıfırlansin, silinsin
				/*
					sayfa tiklenilip gecis yapildiginde otomatik gecis guncellenir ve aktif olur
					autoPlayDelay degerine yazilan saniye kadar sonra otomatik olarak sayfa gecisleri baslar
				*/
				autoPlayId[mysID] = window.setInterval(function(){ //gecis efektini tekrar olusturalım
					autoplaySlider(slidesWrapper,sliderElementLength)
				}, autoPlayDelay);
			}
		}

		function autoplaySlider(slidesWrapper,length) {
			var selectedPosition = slidesWrapper.find(".selected").index();
			if( selectedPosition < length - 1) {
				selectedPosition +=1;
				nextSlide(slidesWrapper.find(".selected"), slidesWrapper, selectedPosition); //ileri efekti verilsin
			} else {
				selectedPosition = 0;
				prevSlide(slidesWrapper.find(".selected"), slidesWrapper, selectedPosition); //geri efekti verilsin
			}
			var sliderNav = slidesWrapper.next();
			updateSliderNavigation(sliderNav, selectedPosition); //slider menu guncelle
		}
		
		function updateSliderNavigation(pagination, n) { //slider menu buton
			var navigationDot = pagination.find(".selected"); //butonlarda secili, aktif, selected butonu bul
			navigationDot.removeClass("selected"); //selected classı sil
			pagination.find("li").eq(n).addClass("selected"); //gecis yapilan, yeni aktif olan slider sayfanin butonuna selected class ekle, aktif yap
		}
		
		/*------SürükleBırak------*/
		slidesWrapperLi.bind("touchstart mousedown", function (e){ //dokunulduğunda (touchstart:Mobil, mousedown:PC)
		   upDown = 1; //kaydirma baslandi, tiklandi
		   ts = e.pageX; //PC tiklama pozisyonu
			if (!ts){
				ts = e.originalEvent.touches[0].clientX; //Mobil dokunma pozisyonu
			}
		});

		slidesWrapperLi.bind("touchend mouseup", function (e){ //bırakıldığında (touchend:Mobil, mouseup:PC)
			upDown = 0; //kaydirma sonlandi
			te = e.pageX; //PC birakma pozisyonu
			if (!te){
				te = e.originalEvent.changedTouches[0].clientX; //Mobil birakma pozisyonu
			}
			var slidesWrapper = $(this).closest(".my-simple-slider"),
				sliderNav = slidesWrapper.next(),
				selectedPosition = slidesWrapper.children("li.selected").index(), //su an aktif slider sayfa
				notUpdatedPosition = selectedPosition,
				slidesNumber = slidesWrapper.children("li").length;
			if(ts > te+65){
				/*
					tıklanılan yer, bırakılan yerden en az 65 piksel daha sağda ise, 
					yani sağdan sola doğru sürükle bırak yapıldıysa ve 5 piksellik bir sürükleme söz konusu ise
				*/
				if( selectedPosition < slidesNumber - 1) { //su an aktif sayfa sliderin sonuncu sayfasi degil ise
					selectedPosition +=1;
					nextSlide(slidesWrapper.find(".selected"), slidesWrapper, selectedPosition);
				}else{ //sonuncu sayfa ise
					selectedPosition = 0;
					prevSlide(slidesWrapper.find(".selected"), slidesWrapper, selectedPosition);
				}
			}else if(ts < te-65){
				/*
					tıklanılan yer, bırakılan yerden en az 65 piksel daha solda ise
				*/
				if( selectedPosition > 0) { //su an aktif sayfa sliderin ilk sayfasi degil ise
					selectedPosition -=1;
					prevSlide(slidesWrapper.find(".selected"), slidesWrapper, selectedPosition);
				}else{ //ilk sayfa ise
					selectedPosition = slidesNumber - 1;
					nextSlide(slidesWrapper.find(".selected"), slidesWrapper, selectedPosition);
				}
			}else{ //gecis yapmak icin sayfa surukleme kuvveti yeterli degil
				$(this).animate({"left":"0px"}, 200); //sayfa suruklenmeden onceki eski haline yavasca kaysin
			}
			//sayfa gecisleri yumusak olsun
			if( notUpdatedPosition == slidesNumber - 1 && selectedPosition == 0) { //slider de tek sayfa varsa
				$(this).css("left","0px");
				$(this).next().css("left","0px");
				$(this).prev().css("left","0px");
			}else{
				$(this).next().animate({"left":"0px"}, 500);
				$(this).prev().animate({"left":"0px"}, 500);
			}
			updateSliderNavigation(sliderNav, selectedPosition); //surukle bırak yontemi ile sayfa gecisi yapildiginde slider butonlari guncelle
			setAutoplay(autoPlayDelay,slidesWrapper); //otomatik gecis guncelle
		});
		
		slidesWrapperLi.bind("touchmove mousemove", function (e){ //ekran üzerindeki dokunmayı ve fareyi izleme
			//tiklama ve birakma arasındaki fare hareketi, sayfayi saga yada sola surukleme hali
			if (upDown){ //slider sayfa uzerine tiklama yapildi ama birakilmadiysa
				te = e.pageX; //PC hareket halindeki fare pozisyonu
				if (!te){
					te = e.originalEvent.changedTouches[0].clientX; //Mobil hareket halindeki dokunma hareketi pozisyonu
				}
				//ekranda acik olan sayfa ile onun onundeki ve arkasındaki sayfalar suruklenme pozisyonu kadar saga yada sola hareketlensin, kaysin
				$(this).css("left",(te-ts)+"px"); 
				$(this).next().css("left",(te-ts)+"px");
				$(this).prev().css("left",(te-ts)+"px"); 
			}
		});
		
		slidesWrapperLi.bind("mouseleave", function (e){ //slider sayfa uzerinde dokunma, tiklama birakildiysa
			upDown = 0; //tiklama, dokunma birakildi
			//ekranda acik olan sayfa ile onun onundeki ve arkasındaki sayfalar eski haline yavasca hareketlensin, kaysin
			$(this).animate({"left":"0px"}, 200); //aktif olan sayfa eski hale gelsin
			$(this).next().animate({"left":"0px"}, 200);
			$(this).prev().animate({"left":"0px"}, 200);
		});
	}
});