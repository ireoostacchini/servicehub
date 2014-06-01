define(function (require) {


    var
        config = require('modules/config'),

        create = function (machineId, name, friendlyName) {

			var result =
				{
				    Id: ko.observable(machineId),
					Name: ko.observable(name),
					FriendlyName: ko.observable(friendlyName),
					IsSelected: ko.observable(false),
					SetIsSelected: function (isSelected) { this.IsSelected(isSelected) },
					Url: config.hashes.machines + "/" + machineId
				};

			return result;


		};


    return {
        create: create
    };

	});