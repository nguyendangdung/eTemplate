$(document).ready(function () {
    //Initialize tooltips
    // $('.nav-tabs > li a[title]').tooltip();
    
    // //Wizard
    // $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

    //     var $target = $(e.target);

    //     if ($target.parent().hasClass('disabled')) {
    //         return false;
    //     }
    // });

    // $(".next-step").click(function (e) {

    //     var $active = $('.wizard .nav-tabs li.active');
    //     $active.next().removeClass('disabled');
    //     nextTab($active);

    // });
    // $(".prev-step").click(function (e) {
    //     console.log(e);
    //     var $active = $('.wizard .nav-tabs li.active');
    //     prevTab($active);

    // });
    
    // autoSize();
});
    
// $(window).resize(function(){
//         autoSize();
//     });

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}
function prevTab(elem) {
    console.log($(elem).prev());
    $(elem).prev().find('a[data-toggle="tab"]').click();
}

// if ($(window).width() > 768) {
    // function autoSize(){
    //     var pageHeight = window.innerHeight,
    //     headHeight = parseInt($('.header-content').height()),
    //     footHeight = $('.footer-content').height(),
    //     formContent = $('.main-content--container').height(),

    //     mainContent= pageHeight - headHeight - footHeight,
    //     pageContent = pageHeight - headHeight - footHeight- headwizard,
    //     marginTop = (pageContent - formContent)/2;
    //     if(marginTop<0) marginTop = 15;
    //     if($('.main-content').height() < pageHeight){
    //         $('.main-content').css({
    //             'margin-top': marginTop + 'px',
    //             'min-height': pageContent - marginTop - 1 + 'px'
    //         });
    //     }
    // }
// }