define(function (require) {

    var
        config = require('modules/config'),

        //filled later by dataService.getData
        data = null,

        dataName = 'machines',

        //we're using amplify.request.deferred, so requests are implemented using promises, 
        //rather than callbacks - makes for slightly simpler code
        getData = function () {
            return amplify.request(dataName).promise();
        },



        init = function () {

            amplify.request.define(dataName, 'ajax', {
                url: config.serviceUrl + dataName,
                dataType: 'json',
                type: 'GET',
                decoder: "jSend"
                //cache:
            });

        };





        init();

        return {
            getData: getData,
            data:data
            
        };
    });


