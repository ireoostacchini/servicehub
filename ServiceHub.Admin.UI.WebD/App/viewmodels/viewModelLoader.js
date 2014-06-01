define(function (require) {

        
        var

            machines = require('viewmodels/machines'),
            services = require('viewmodels/services'),
            credentials = require('viewmodels/credentials'),
            
            load = function () {
                services.load();
                machines.load();
                credentials.load();

        };

        return {
            load: load
        };
    });