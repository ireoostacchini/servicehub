define('dataService',
    [
        'logger',
        'messenger',
        'dataService.machines',
        'dataService.services',
        'dataService.credentials'
    ],
    function (logger, messenger, machines, services, credentials) {

        var getData = function () {

            $.when(
                
                //we get the data in parallel
                machines.getData(),
                services.getData(),
                credentials.getData()
            )
                .done(function (machinesData, servicesData, credentialsData) {
                    
                    machines.data = machinesData[0];
                    services.data = servicesData[0];
                    credentials.data = credentialsData[0];
                    
                    //notify teh bootstrapper (via pub/sub) that we've finished loading the data
                    messenger.publish.dataLoaded();

                })
                .fail(function() {
                    logger.error("dataService.getData failed");
                });
        };


        return {
            machines: machines,
            services: services,
            credentials:credentials,
            getData: getData
        };
    });


