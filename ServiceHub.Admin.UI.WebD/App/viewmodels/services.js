define(function (require) {

    var

        logger = require('modules/logger'),
        dataService = require('modules/dataService'),
        model = require('modules/model'),
        


        services = ko.observableArray(),
        

        addData = function(serviceDtoArray) {

            var newItems = ko.utils.arrayMap(serviceDtoArray, function(serviceDto) {
                return model.service.create(serviceDto.Name, serviceDto.FriendlyName);
            });

            //take advantage of push accepting variable arguments
            services.push.apply(services, newItems);
        },
        

        load = function() {

            //reset
            services.removeAll();

            addData(dataService.services.data);

            logger.info(services._latestValue.length + ' services loaded');

        },
        
        activate = function(routeData, callback) {

            logger.debug("service route activated");

        };



    return {
        activate: activate,
        services: services,
        load: load

    };
});