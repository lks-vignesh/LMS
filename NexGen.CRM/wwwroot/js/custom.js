$(document).ready(function () {
	
	/*accordion*/
		//hide the all of the element with class msg_body
		$(".msg_body").hide();
		//toggle the componenet with class msg_body
		$(".msg_head").click(function(){
			if ( $(this).next(".msg_body").is(":visible") ) {
				$(".msg_body").slideUp(300);
			} 
			else {
				$(".msg_body").slideUp(300);
				$(this).next(".msg_body").slideToggle(300);
			}
		});
	
	if ($(window).width() < 576) {
		//alert('Less than 576');
		var swiper = new Swiper(".mySwiper", {
			//margin : 10,
			loop: true,
			slidesPerView: 2,
			spaceBetween: 40,
        navigation: {
          nextEl: ".swiper-button-next",
          prevEl: ".swiper-button-prev",
        },
      });
	}
else {
   //alert('More than 576');
}
	/*sidemenu open and close*/
	
	$('.menu-btn').click(function(e){
		e.stopPropagation();
		$('.fluid-box nav').toggleClass('active');
	})
	$('.fluid-box nav').click(function(e){
		e.stopPropagation();
	})
	$('html,body').click(function(){
		$('.fluid-box nav').removeClass('active');
	})
	$('.close-menu').click(function(){
		$('.fluid-box nav').removeClass('active');
	})
	
	$(document).ready(function (){
    $('.nav-item1').click(function (event) {
        horizontalNavigation(0, event);
    });
    $('.nav-item2').click(function (event) {
        horizontalNavigation(100, event);
    });
    $('.nav-item3').click(function (event) {
        horizontalNavigation(300, event);
    });
});

function horizontalNavigation(position, event) {
    $('ul').animate({scrollLeft: position}, 800);
    event.preventDefault();
}


/*tab animation
function onTabClick(evt) {
  setLineStyle(evt.target)
}

function setLineStyle(tab) {
  let line = document.querySelector('.tabs2 > .line')
  line.style.left = tab.offsetLeft + "px";
  line.style.width = tab.clientWidth + "px";
}


window.onload = function() {
  const tabs = document.querySelectorAll('.tabs2 > .nav > .nav-item')
  tabs.forEach((tab, index) => {
    tab.onclick = onTabClick;
    
    if(index == 0) setLineStyle(tab);
  })
}

end of tab animation*/



	/*$('.nav-item').click(function(){
		$('.nav-item').removeClass('center-tab');
		$(this).addClass('center-tab').animate({scrollLeft: $(currentElement).offset().left}, 800);
		
	})*/
	
	
		$(".js-select2").select2({
			closeOnSelect : false,
			placeholder : "",
			allowHtml: true,
			allowClear: true,
			tags: true // создает новые опции на лету
		});

			$('.icons_select2').select2({
				width: "100%",
				templateSelection: iformat,
				templateResult: iformat,
				allowHtml: true,
				placeholder: "Placeholder",
				dropdownParent: $( '.select-icon' ),//обавили класс
				allowClear: true,
				multiple: false
			});
	

				function iformat(icon, badge,) {
					var originalOption = icon.element;
					var originalOptionBadge = $(originalOption).data('badge');
				 
					return $('<span><i class="fa ' + $(originalOption).data('icon') + '"></i> ' + icon.text + '<span class="badge">' + originalOptionBadge + '</span></span>');
				}


	$('.verifier-table').DataTable({
		"lengthMenu": [
			[6, 10, 25, -1],
			[6, 10, 25, "All"]
		],
		"paging": true,

		"info": false,
		bFilter: false,
		bInfo: false
	});
	$('.more-btn').click(function () {
		$(this).siblings('.show-download').fadeToggle();
	})
	$(".show-password, .hide-password").on('click', function () {
		var passwordId = $(this).parents('.form-group').find('#password').attr('id');
		if ($(this).hasClass('show-password')) {
			$("#" + passwordId).attr("type", "text");
			$(this).parent().find(".show-password").hide();
			$(this).parent().find(".hide-password").show();
		} else {
			$("#" + passwordId).attr("type", "password");
			$(this).parent().find(".hide-password").hide();
			$(this).parent().find(".show-password").show();
		}
	});

	$('.datepicker').datepicker({
		autoclose: true
	});


	$(".logout-dropdown").click(function () {
		$('.logout-menu').stop().slideToggle();
	});
	
	/*menu dropodwn*/
	$('.menudropdown .subDropodwn').click(function(e){
		e.stopPropagation();
	});
	$(".menudropdown").click(function () {
		$(".menudropdown").removeClass('active');
		$('.subDropodwn').stop().slideUp();
		
		$(this).find('.subDropodwn').stop().slideToggle();
		//$(this).toggleClass('active');
		if($(this).find('.subDropodwn').not(':visible')){
			$(this).removeClass('active')
		}
		
		
	});
	/*end of menu dropdown*/
	
	
	
	$(".infoText").click(function () {
		$('.info-popup').stop().fadeToggle();
		
	});
	$('html,body').click(function(){
		$('.info-popup').stop().fadeOut();
	})
	$('.infoText,.info-popup').click(function(e){
		e.stopPropagation();
	});
	Highcharts.setOptions({
		colors: ['#06283A', '#27B492', '#FF7272', '#FFA51E']
	});
	Highcharts.chart('container', {
		chart: {
			type: 'column'
		},
		exporting: {
			enabled: false
		},
		title: {
		text: null
		},
		//subtitle: {
		// text: 'Source: WorldClimate.com'
		//},
		xAxis: {
			categories: [
				'02/03/2021',
				'03/03/2021',
				'04/03/2021',
				'05/03/2021',
				'06/03/2021',
				'07/03/2021',
				'08/03/2021'
			],
			crosshair: true
		},
		yAxis: {
			min: 0,
			title: {
				text: null
			}
		},
		tooltip: {
			headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
			pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
				'<td style="padding:0"><b>{point.y:.1f} mm</b></td></tr>',
			footerFormat: '</table>',
			shared: true,
			useHTML: true
		},
		plotOptions: {
			column: {
				pointPadding: 0.1,
				borderWidth: 0,
				pointWidth: 12
			}
		},
		series: [{
			name: 'Total Uploaded',
			data: [49.9, 71.5, 106.4, 29.2, 44.0, 76.0, 35.6]

		}, {
			name: 'Approved',
			data: [83.6, 78.8, 98.5, 93.4, 106.0, 84.5, 105.0]

		}, {
			name: 'Rejected',
			data: [48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0]

		}, {
			name: 'Pending',
			data: [42.4, 33.2, 34.5, 39.7, 52.6, 75.5, 57.4]

		}]
	});


	//pie chart1

	Highcharts.setOptions({
		colors: ['#6458FF', '#13DFB5', '#0691DB', '#06283A']
	});
	Highcharts.chart('container2', {
		chart: {
			plotBackgroundColor: null,
			plotBorderWidth: null,
			plotShadow: false,
			type: 'pie'
		},
		title: {
			text: 'Total<br><b>120</b>',
			align: 'center',
			x: 0,
			verticalAlign: 'middle',
			y: 0,
			floating: true
		},
		legend: {
			enabled: true
		},
		exporting: {
			enabled: false
		},
		tooltip: {
			pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
		},
		plotOptions: {
			pie: {
            borderWidth: 0,
				allowPointSelect: true,
				cursor: 'pointer',
				dataLabels: {
					enabled: false,
					formatter: function () {
						return this.key + ': ' + this.y + '%';
					}
				},
				showInLegend: true
			}
		},
		series: [{
			name: 'Composition',
			colorByPoint: true,
			innerSize: '70%',
			data: [{
					name: 'Individual',
					// color: '#01BAF2',
					y: 20,
				}, {
					name: 'Sole Propretior',
					// color: '#71BF45',
					y: 25
				}, {
					name: 'Partnership',
					//color: '#FAA74B',
					y: 32
				},
				{
					name: 'Private Limited',
					// color: '#01BAF2',
					y: 23,
				}
			]
		}]
	});

	//pie chart2

	Highcharts.setOptions({
		colors: ['#CE5180', '#4A7AE9', '#FFA967', '#06283A']
	});
	Highcharts.chart('container3', {
		chart: {
			plotBackgroundColor: null,
			plotBorderWidth: null,
			plotShadow: false,
			type: 'pie'
		},
		title: {
			text: 'Total<br><b>120</b>',
			align: 'center',
			x: 0,
			verticalAlign: 'middle',
			y: 0,
			floating: true
		},
		legend: {
			enabled: false
		},
		exporting: {
			enabled: false
		},
		tooltip: {
			pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
		},
		plotOptions: {
			pie: {
				allowPointSelect: true,
				cursor: 'pointer',
				dataLabels: {
					enabled: false,
					formatter: function () {
						return this.key + ': ' + this.y + '%';
					}
				},
				showInLegend: true
			}
		},
		series: [{
			name: 'Composition',
			colorByPoint: true,
			innerSize: '90%',
			data: [{
				name: 'Individual',
				// color: '#01BAF2',
				y: 20,
			}, {
				name: 'Sole Propretior',
				// color: '#71BF45',
				y: 25
			}, {
				name: 'Partnership',
				//color: '#FAA74B',
				y: 32
			}]
		}]
	});
	
	

	//pie chart3

	Highcharts.setOptions({
		colors: ['#CE5180', '#4A7AE9', '#FFA967']
	});
	Highcharts.chart('container4', {
		chart: {
			plotBackgroundColor: null,
			plotBorderWidth: null,
			plotShadow: false,
			type: 'pie'
		},
		title: {
			text: 'Total<br><b>120</b>',
			align: 'center',
			x: 0,
			verticalAlign: 'middle',
			y: 0,
			floating: true
		},
		legend: {
			enabled: false
		},
		exporting: {
			enabled: false
		},
		tooltip: {
			pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
		},
		plotOptions: {
			pie: {
				allowPointSelect: true,
				cursor: 'pointer',
				dataLabels: {
					enabled: false,
					formatter: function () {
						return this.key + ': ' + this.y + '%';
					}
				},
				showInLegend: true
			}
		},
		series: [{
			name: 'Composition',
			colorByPoint: true,
			innerSize: '90%',
			data: [{
				name: 'Individual',
				// color: '#01BAF2',
				y: 20,
			}, {
				name: 'Sole Propretior',
				// color: '#71BF45',
				y: 25
			}, {
				name: 'Partnership',
				//color: '#FAA74B',
				y: 32
			}]
		}]
	});


	//pie chart4

	Highcharts.setOptions({
		colors: ['#CE5180', '#4A7AE9', '#FFA967']
	});
	Highcharts.chart('container5', {
		chart: {
			plotBackgroundColor: null,
			plotBorderWidth: null,
			plotShadow: false,
			type: 'pie'
		},
		title: {
			text: 'Total<br><b>120</b>',
			align: 'center',
			x: 0,
			verticalAlign: 'middle',
			y: 0,
			floating: true
		},
		legend: {
			enabled: false
		},
		exporting: {
			enabled: false
		},
		tooltip: {
			pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
		},
		plotOptions: {
			pie: {
				allowPointSelect: true,
				cursor: 'pointer',
				dataLabels: {
					enabled: false,
					formatter: function () {
						return this.key + ': ' + this.y + '%';
					}
				},
				showInLegend: true
			}
		},
		series: [{
			name: 'Composition',
			colorByPoint: true,
			innerSize: '90%',
			data: [{
				name: 'Individual',
				// color: '#01BAF2',
				y: 20,
			}, {
				name: 'Sole Propretior',
				// color: '#71BF45',
				y: 25
			}, {
				name: 'Partnership',
				//color: '#FAA74B',
				y: 32
			}]
		}]
	});

	//pie chart5

	Highcharts.setOptions({
		colors: ['#CE5180', '#4A7AE9', '#FFA967']
	});
	Highcharts.chart('container6', {
		chart: {
			plotBackgroundColor: null,
			plotBorderWidth: null,
			plotShadow: false,
			type: 'pie'
		},
		title: {
			text: 'Total<br><b>120</b>',
			align: 'center',
			x: 0,
			verticalAlign: 'middle',
			y: 0,
			floating: true
		},
		legend: {
			enabled: false
		},
		exporting: {
			enabled: false
		},
		tooltip: {
			pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
		},
		plotOptions: {
			pie: {
				allowPointSelect: true,
				cursor: 'pointer',
				dataLabels: {
					enabled: false,
					formatter: function () {
						return this.key + ': ' + this.y + '%';
					}
				},
				showInLegend: true
			}
		},
		series: [{
			name: 'Composition',
			colorByPoint: true,
			innerSize: '90%',
			data: [{
				name: 'Individual',
				// color: '#01BAF2',
				y: 20,
			}, {
				name: 'Sole Propretior',
				// color: '#71BF45',
				y: 25
			}, {
				name: 'Partnership',
				//color: '#FAA74B',
				y: 32
			}]
		}]
	});
	
	
	/*conatiner7*/
	
	$(function () {
    $('#container7').highcharts({
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: 1,//null,
            plotShadow: false,
        },
        title: {
            text: null
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer'
            }
        },
        series: [{
            type: 'pie',
            name: 'Browser share',
            center: [100, null],
            size: 100,
            innerSize: '90%',
            dataLabels: {
				enabled: false
			},
            showInLegend: true,
            data: [
                ['Firefox',   33.33],
                ['IE',       33.33],
                ['chrome',   33.33]
             
            ]
        },
                {
            type: 'pie',
            name: 'Browser share',
            center: [300, null],
            size: 100,
            innerSize: '90%',
            dataLabels: {
				enabled: false
			},
            data: [
                ['Firefox',   33.33],
                ['IE',       33.33],
                ['chrome',   33.33]
            ]
        }]
    },function(chart) {
            
        $(chart.series[0].data).each(function(i, e) {
            e.legendItem.on('click', function(event) {
                var legendItem=e.name;
                
                event.stopPropagation();
                
                $(chart.series).each(function(j,f){
                       $(this.data).each(function(k,z){
                           if(z.name==legendItem)
                           {
                               if(z.visible)
                               {
                                   z.setVisible(false);
                               }
                               else
                               {
                                   z.setVisible(true);
                               }
                           }
                       });
                });
                
            });
        });
    });
});


});