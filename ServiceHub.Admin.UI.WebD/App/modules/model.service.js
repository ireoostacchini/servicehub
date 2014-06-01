define(function (require) {


    var
        config = require('modules/config'),

        create = function (serviceName, friendlyName, executableName) {

            var result =
				{
				    ServiceName: ko.observable(serviceName),
				    FriendlyName: ko.observable(friendlyName),
				    ExecutableName: ko.observable(executableName)

				};

            return result;


        };


    return {
        create: create
    };

});