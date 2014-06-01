define('router',
    ['jquery',
        'underscore',
        'sugar',
        'sammy',
        'presenter',
        'config',
        'store',
        'logger',
        'messenger',
        'route-mediator'],
    function ($, _, sugar, Sammy, presenter, config, store, logger, messenger, routeMediator) {
        var

            //keep a track of the current url - we might need to reset it in registerBeforeLeaving
            currentHash = '',

            //if registerBeforeLeaving returns false, a redeirect happens
            //this variable ensures we only redirect once
            isRedirecting = false,

            sammy = new Sammy.Application(function () {

                if (Sammy.Title) {
                    this.use(Sammy.Title);
                    this.setTitle(config.title);
                }

            }),

            //fires before a routing event - gives us a chance to cancel it
            //we check for unsaved data - if it's so, canLeave = false

            registerBeforeLeaving = function () {

                sammy.before(/.*/, function () {


                    //can we leave the page? (ie are there outstanding changes?)
                    var canLeave = routeMediator.canLeave();


                    if (!canLeave && !isRedirecting) {

                        isRedirecting = true;
                        logger.warning(logger.toasts.changesPending);

                        // Keep hash url the same in address bar
                        //this is a reroute, and causes this method to fire again
                        //hence teh check on  isRedirecting
                        this.app.setLocation(currentHash);

                    }
                    else {
                        isRedirecting = false;
                        currentHash = this.app.getLocation();
                    }
                    return canLeave;
                });
            },


        //handles routing events
            register = function (route) {

                if (!route.callback) throw Error('callback must be specified.');


                //here we specify a generic handler covering all valid routes
                sammy.get(route.path, function (context) {


                    //context path goes back to the root of the app - can have extra directories
                    //if the application does not have its own web site in IIS
                    //eg context.path = /ServiceHubAdmin#/machines/3
                    //when we really want #/machines/3
                    var actualPathPostion = context.path.indexOf('#');

                    //if it's the home route withut the #/, we won't find a hash, so redirect to home
                    if (actualPathPostion == -1) {

                        navigateTo(config.hashes.home);
                        return;
                    }



                    var actualPath = context.path.substr(actualPathPostion);

                    //if it's not the invalid route, cache it
                    if (!_.contains(['Invalid'], route.title)) {
                        store.save(config.stateKeys.lastView, route.path);
                    }

                    // Activate the viewmodel
                    route.callback(context.params);


                    //each route (even lower-level ones) are associated with a top-level view - this loads that view
                    presenter.transitionTo(route, actualPath);

                    if (this.title) this.title(route.title);
                });


            },

        navigateBack = function () {
            window.history.back();
        },

        navigateTo = function (url) {
            sammy.setLocation(url);
        },




        //we pass routes into router, rather than adding a dependency, to avoid circular dependecies:
         //router > routes > viewModel > router
        run = function (routes) {

            //register all the routes in routes collection
            for (var i = 0; i < routes.length; i++) { register(routes[i]); }


            // 1) if i browse to a location, use it - sammy.getLocation() || - not actually required at present
            // 2) otherwise, use the url i grabbed from storage
            // 3) otherwise use the default route
            var url = store.fetch(config.stateKeys.lastView);

            var startupUrl = sammy.getLocation() || url || config.hashes.home;

            //register the event handler for pre-route events
            registerBeforeLeaving();



            sammy.run(startupUrl);



        };

        return {
            navigateTo: navigateTo,
            run: run

        };
    });