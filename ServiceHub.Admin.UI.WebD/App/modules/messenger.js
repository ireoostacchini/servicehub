define(function (require) {

    var
        
   // amplify = require('amplify') ,
    config = require('modules/config'),


            priority = 1,

            publish = function (topic, options) {
                amplify.publish(topic, options);
            },

            subscribe = function (options) {
                amplify.subscribe(
                    options.topic,
                    options.context,
                    options.callback,
                    priority);
            };

        publish.viewModelActivated = function (options) {
            amplify.publish(config.messages.viewModelActivated, options);
        };
        
        publish.dataLoaded = function (options) {
            amplify.publish(config.messages.dataLoaded, options);
        };

        return {
            publish: publish,
            subscribe: subscribe
        };
    });
