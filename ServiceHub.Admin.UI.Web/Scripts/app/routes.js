define('routes',
    ['config', 'viewModel', 'logger'],
    function (config, viewModel, logger) {

        var routes = [

            //home
           {
               isDefault: true,
               view: null,
               path: config.hashes.home,
               title: 'Home',
               callback: function () { },   //logger.info("home");
               group: config.routeGroups.top
           },



            //machines
           {
               view: config.viewIds.machines,
               path: config.hashes.machines,
               title: 'Machines',
               callback: viewModel.machines.activate,
               group: config.routeGroups.top
           },

            {
                //this is a low-level route, but it still has a top-level view 
                //- so we know which view to transition to if we browse straight to this route
                
                //also, it must go before the :id route, otherwise it'll never get called
                //in js, they're all just strings...
                view: config.viewIds.machines,
                path: config.hashes.machinesAdd,
                title: 'Add Machine',
                callback: viewModel.machines.addNewMachine
            },
            {
                //again, a low-level route with a top-level view 
                view: config.viewIds.machines,
                path: config.hashes.machines + '/:id',
                title: 'Machine',
                callback: viewModel.machines.select
            },

           //services
            {
                view: config.viewIds.services,
                path: config.hashes.services,
                title: 'Services',
                callback: viewModel.services.activate,
                group: config.routeGroups.top
            },


            //empty route - we redirect this to home in the handler. 
            {
                view: '',
                path: /^$/,     //empty regex. '' won't do, matches everything
                title: 'Empty',
                callback: function () { logger.info("home"); }
            },



            // Invalid routes - put this last, as it matches everything not matched above
            {
                view: '',
                path: /.*/,
                title: 'Invalid',
                callback: function () {
                    logger.error(logger.toasts.invalidRoute);
                }
            }

        ];

        return routes;

    });