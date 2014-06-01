define(function (require) {

        var
            config = require('modules/config'),
                
            //filled later by dataService.getData
            data = null,
            
            dataName = 'credentials',
            
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


