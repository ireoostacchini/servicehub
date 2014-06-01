define(function (require) {

    var

        logger = require('modules/logger'),
 

	        activate = function () {


	            logger.debug("machine activated");
	        }



	    

	    ;




	    return {
	        activate: activate
	    };
	});