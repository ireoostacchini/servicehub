define('dataService.services',
    [
        'config',
        'amplify'

    ],
    function (config, amplify) {

        var

            //filled later by dataService.getData
            data = null,
            
            dataName = 'services',
            
            init = function() {

                amplify.request.define(dataName, 'ajax', {
                    url: config.serviceUrl + dataName,
                    dataType: 'json',
                    type: 'GET',
                    decoder: "jSend"
                    //cache:
                });

            },
            
            //see dataService.Machines for explanation
            getData = function() {
                return amplify.request(dataName).promise();
            };


        init();

        return {
            getData: getData
        };
    });


