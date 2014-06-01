define(function (require) {
    
    //dependencies
     var system = require('durandal/system');
    
    toastr.options.timeOut = 2000;
    

    //internal variables
    var toasts = {
        changesPending: 'Please save or cancel your changes before leaving the page.',
        errorSavingData: 'Data could not be saved. Please check the logs.',
        errorGettingData: 'Could not retrieve data.  Please check the logs.',
        invalidRoute: 'Cannot navigate. Invalid route',
        retreivedData: 'Data retrieved successfully',
        savedData: 'Data saved successfully'
    };


    //extend toastr
    toastr.toasts = toasts;

    //no config yet...
    toastr.debug = function (message, title, optionsOverride) {

        if (system.debug()) toastr.info(message, title, optionsOverride);
    };

    return toastr;
    

  
});

