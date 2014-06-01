define(function (require) {

    var
        
        logger = require('modules/logger'),
          

        title = 'Home page',
        
        activate = function() {

            logger.debug("home route activated");
        };


 
    return {
        activate: activate,
        title:title
    };
});