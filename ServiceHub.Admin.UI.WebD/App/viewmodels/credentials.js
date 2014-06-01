define(function (require) {

    var

        logger = require('modules/logger'),
        dataService = require('modules/dataService'),
        model = require('modules/model'),
        


        credentials = ko.observableArray(),
        

        addData = function (credentialsDtoArray) {

            var newItems = ko.utils.arrayMap(credentialsDtoArray, function (credentialDto) {
                return model.credential.create(credentialDto.Username, credentialDto.Password);
            });

            //take advantage of push accepting variable arguments
            credentials.push.apply(credentials, newItems);
        },
        

        load = function() {

            //reset
            credentials.removeAll();

            addData(dataService.credentials.data);

            logger.info(credentials._latestValue.length + ' credentials loaded');

        },
        
        activate = function(routeData, callback) {

            logger.debug("credential route activated");

        };



    return {
        activate: activate,
        credentials: credentials,
        load: load

    };
});