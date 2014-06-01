define('dataService.credentials',
    [
        'jquery',
        'config',
        'logger'

    ],
    function ($, config, logger) {

        var

            getCredentials = "getCredentials",
             
            //filled later by dataService.getData
            data = null,
            resourceName = 'credentials',
            

            getData = function() {
                return amplify.request(getCredentials).promise();
            },
            


            init = function() {

                // GET: /machines
                amplify.request.define(getCredentials, 'ajax', {
                    url: config.serviceUrl + resourceName,
                    dataType: 'json',
                    type: 'GET',
                    decoder: "jSend"
                    //cache:
                });


            };


        init();

        ;


        return {
            getData: getData,
            data: data

        };
    });


