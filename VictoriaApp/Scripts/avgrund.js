(function ($) {
    'use strict';
    $(function () {
        /*$('#show').avgrund({
            height: 500,
            holderClass: 'custom',
            showClose: true,
            showCloseText: 'x',
            onBlurContainer: '.container-scroller',
            template: '<h2 class="text-center mt-4">' + sessionTitulo + '</h2>' +
            '<div class="text-justify mt-4">' +
                '<p>' + sessionDescripcion + '</p>' +
            '</div>'
        });*/
        

        $('#completado').avgrund({
            height: 500,
            holderClass: 'custom',
            showClose: true,
            showCloseText: 'x',
            onBlurContainer: '.container-scroller',
            template: '<p>Este modulo ya ha sido completado</p>'
            //'<div>' +
            //'<a href="http://twitter.com/voronianski" target="_blank" class="twitter btn btn-twitter btn-block">Twitter</a>' +
            //'<a href="http://dribbble.com/voronianski" target="_blank" class="dribble btn btn-dribbble btn-block">Dribbble</a>' +
            //'</div>' +
            //'<div class="text-center mt-4">' +
            //'<a href="#" target="_blank" class="btn btn-success mr-2">Great!</a>' +
            //'<a href="#" target="_blank" class="btn btn-light">Cancel</a>' +
            //'</div>'
        });
    })
})(jQuery);