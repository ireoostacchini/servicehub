define('logger',
    [
        'toastr',
        'config'
    ],
    function (toastr, config) {


        toastr.options.timeOut = 2000;

        var
            
            toasts = {
                changesPending: 'Please save or cancel your changes before leaving the page.',
                errorSavingData: 'Data could not be saved. Please check the logs.',
                errorGettingData: 'Could not retrieve data.  Please check the logs.',
                invalidRoute: 'Cannot navigate. Invalid route',
                retreivedData: 'Data retrieved successfully',
                savedData: 'Data saved successfully'
            };

        toastr.toasts = toasts;


        //extend 
        toastr.debug = function(message, title, optionsOverride) {

            if (config.debug) toastr.info(message, title, optionsOverride);
        };

        return toastr;


    });