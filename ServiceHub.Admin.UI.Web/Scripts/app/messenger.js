define('messenger',
['amplify', 'config'],
    function (amplify, config) {
        var
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

        //subscribed to by the router
        //passes the VM's canLeave function to the router
        //so it can check for changes before allowing a route 
        publish.viewModelActivated = function (options) {
            amplify.publish(config.messages.viewModelActivated, options);
        };
        
        publish.dataLoaded = function (options) {
            amplify.publish(config.messages.dataLoaded, options);
        };

        publish.machineDeleted = function (options) {
            amplify.publish(config.messages.machineDeleted, options);
        };


        return {
            publish: publish,
            subscribe: subscribe
        };
    });
