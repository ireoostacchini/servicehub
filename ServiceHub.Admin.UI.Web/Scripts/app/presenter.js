define('presenter',
    [
        'jquery',
        'config'
    ],
    function ($, config) {
        
        var
            transitionOptions = {
                ease: 'swing',
                fadeOut: 0,
                floatIn: 0,
                offsetLeft: '0px',
                offsetRight: '0px'
            },

            //this module governs the hiding / showing of top-level routes / views - those accessed via the top-level menu
            //the home route is also processed here (we simply deactivaye all the 

            //*********************************show a given view

            showView = function (view) {

                if (!view) return; //null can be passed - there's no view for home route

                $(view)
                    .css({
                        display: 'block',
                        visibility: 'visible'
                    }).addClass('view-active').animate({
                        marginRight: 0,
                        marginLeft: 0,
                        opacity: 1
                    }, transitionOptions.floatIn, transitionOptions.ease);
            },


            //*********************************highlight view name in the nav

            highlightActiveView = function (route, actualPath) {

                resetViewLinks();
                
                //if it's the home view, just quit
                if (route.path == config.hashes.home) return;
                

                // Highlight the selected link
                $('.route-top').has('a[href="' + actualPath + '"]').addClass('route-active');


            },
            
            //reset the links to views (top-level - subnav links are goverened by selected properties of the viewmodels)
            resetViewLinks = function() {
              
                $('.route-top').removeClass('route-active');
                
            },


            //*********************************reset all views
            resetViews = function () {
                $('.view').css({
                    marginLeft: transitionOptions.offsetLeft,
                    marginRight: transitionOptions.offsetRight,
                    opacity: 0
                });
            },

            //*********************************show / hide busy indicator
            toggleLoader = function (show) {
                $('#loader').activity(show);
            },

            //*********************************switch to a different view
            transitionTo = function (route, actualPath) {

                toggleLoader(true);

                var $activeViews = $('.view-active');


                //if any views are active, hide them, then show the selected view
                if ($activeViews.length) {

                    $activeViews.fadeOut(transitionOptions.fadeOut, function () {

                        resetViews();

                        $('.view').removeClass('view-active');

                        showView(route.view);
                    });



                } else {

                    resetViews();

                    showView(route.view);
                }

                highlightActiveView(route, actualPath);

                toggleLoader(false);
            };

        //*********************************public
        return {
            toggleLoader: toggleLoader,
            transitionOptions: transitionOptions,
            transitionTo: transitionTo
        };
    });
