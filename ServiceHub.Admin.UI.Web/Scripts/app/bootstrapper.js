define('bootstrapper',
    ['jquery', 'config', 'viewModel', 'binder', 'logger', 'router', 'routes', 'messenger', 'dataService'],
    function ($, config, viewModel, binder, logger, router, routes, messenger, dataService) {

        var self = this,
            //we load the data - once that's done, the dataService publishes the dataLoaded event
            //which runPart2 subscribes to
            run = function () {

                dataService.getData();

            },
            

            //does not run until the data is all loaded up
            runPart2 = function () {

                $.when(viewModel.load())
                
                    .done(binder.bind())
                
                    .done(router.run(routes));
            },


            init = function () {

                messenger.subscribe({
                    topic: config.messages.dataLoaded,
                    context: self,
                    callback: runPart2
                });

            };


        init();




        return {
            run: run
        };
    });
