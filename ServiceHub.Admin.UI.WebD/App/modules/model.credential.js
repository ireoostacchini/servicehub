define(function (require) {


    var
        config = require('modules/config'),

        create = function (username, password) {

            var result =
				{
				    Username: ko.observable(username),
				    Password: ko.observable(password),
				};

            return result;


        };


    return {
        create: create
    };

});