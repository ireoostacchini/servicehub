define(function (require) {
    
    var
        self = this,
        
        router = require('durandal/plugins/router'),
        app = require('durandal/app'),

        //custom modules
        logger = require('modules/logger'),
        dataService = require('modules/dataService'),
        messenger = require('modules/messenger'),
        config = require('modules/config'),
        viewModelLoader = require('viewmodels/viewModelLoader'),

        //private functions


        //runs when view is activated
        activate = function () {


            messenger.subscribe({
                topic: config.messages.dataLoaded,
                context: self,
                callback: activatePart2
            });

            //we load the data - once that's done, the dataService publishes the dataLoaded event
            //which activatePart2 subscribes to
            dataService.getData();
  
            logger.debug("Shell activated");
        },

        //does not run until the data is all loaded up
        activatePart2 = function () {

            viewModelLoader.load();
            
            logger.debug("Viewmodel loaded");
            
            router.activate('home');
        }
    ;

    return {
        app:app,
        router: router,
        logger: logger,
        search: function () {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: activate
    };
});