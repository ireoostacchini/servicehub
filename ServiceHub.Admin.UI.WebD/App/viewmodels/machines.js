define(function (require) {

    var

        logger = require('modules/logger'),
        dataService = require('modules/dataService'),
        model = require('modules/model'),


        machines = ko.observableArray(),

            selected = ko.observable(),

	        addMachineData = function (machineDtoArray) {

	            var newItems = ko.utils.arrayMap(machineDtoArray, function (machineDto) {
	                return model.machine.create(machineDto.MachineId, machineDto.Name, machineDto.FriendlyName);
	            });
	            //take advantage of push accepting variable arguments
	            machines.push.apply(machines, newItems);
	        },


	        load = function () {
	            //reset
	            machines.removeAll();

	            addMachineData(dataService.machines.data);

	            logger.info(machines._latestValue.length + ' machines loaded');

	        },


	        activate = function () {

	            //clear all - if we return to machines after having selected one, then moved away, we need to clear up
//	            deselectAllMachines();

	            logger.debug("machines route activated");
	        },



	        //runs when a machine is selected from the nav list - REDUNDANT??
	        select = function (selectedMachine) {

	            alert("shouldn't see this...");

//	            deselectAllMachines();
//
//	            //selectedMachine is a sammy object - we need to get the model
//
//	            var machine = findMachineById(selectedMachine.id);
//
//
//	            machine.IsSelected(true);   //so we know how to style each machine in the list
//
//	            selected(machine);   //so we know what to bind the details template to
//
//	            logger.debug("machine " + machine.Id() + " has been selected");

	        },


            deselectAllMachines = function () {

                alert("shouldn't see this...");
                
                //we have to dig into the innards of the machines observable to get the model
//                _.each(ko.utils.unwrapObservable(machines), function (machine) {
//
//                    machine.IsSelected(false);
//
//                    selected(null);
//
//                });

            },

            findMachineById = function (id) {

                alert("shouldn't see this...");
                
//                var result = _.find(ko.utils.unwrapObservable(machines), function (machine) {
//
//                    return machine.Id() == id;
//
//                });

                return result;

            }

	    ;




	    return {
	        activate: activate,
	        machines: machines,
	        selected: selected,
	        load: load,
	        select: select

	    };
	});