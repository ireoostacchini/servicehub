define('viewModel.machines',
[
		'config',
		'ko',
		'logger',
		'dataService',
		'messenger',
        'router',
        'underscore',
        'amplify',
        'viewModel.machine'

],
	function (config, ko, logger, dataService, messenger, router, underscore, amplify, vmMachine) {

	    var
            self = this,

            machines = ko.observableArray(),

            selected = ko.observable(),


            //loads VM with data from dataService - done once at startup
	        load = function () {
	            //reset
	            machines.removeAll();


	            var newItems = ko.utils.arrayMap(dataService.machines.data, function (machineDto) {

	                return vmMachine.create(
                        machineDto.MachineId,
	                    machineDto.Name,
	                    machineDto.FriendlyName,
	                    machineDto.CredentialsId,
                        machineDto.Version
                    );

	            });

	            //take advantage of push accepting variable arguments
	            machines.push.apply(machines, newItems);


	            logger.info(machines._latestValue.length + ' machines loaded');

	        },


	        activate = function () {
	            messenger.publish.viewModelActivated({ canleaveCallback: canLeave });

	            //clear all - if we return to machines after having selected one, then moved away, we need to clear up
	            deselectAllMachines();

	            logger.debug("machines route activated");
	        },


	        canLeave = function () {

	            return true;
	        },

	        //runs when a machine is selected from the nav list
	        //selectedMachine is a sammy object - we get the viewModel
	        //set its properties, and call its activate method
	        select = function (selectedMachine) {

	            deselectAllMachines();

	            var machineVM = findMachineById(selectedMachine.id);


	            selected(machineVM);   //so we know what to bind the details template to

	            machineVM.activate();

	        },

        //called when loading the template - allows the loaded content to fade in
	    //not actually used - we use the fadeVisible bindingHandler instead
	    //but it's another way    
        showSelectedElement = function (elem) {
            $(elem).hide().fadeIn();
        },



            deselectAllMachines = function () {

                //we have to dig into the innards of the machines observable to get the model
                _.each(ko.utils.unwrapObservable(machines), function (machine) {

                    machine.isSelected(false);

                    selected(null);

                });

            },

            findMachineById = function (id) {

                //works for a null argument too - used when cancelling a new machine
                
                var result = _.find(ko.utils.unwrapObservable(machines), function (machineVM) {

                    return machineVM.model.Id() == id;

                });

                return result;

            },
            
            removeMachineById = function (data) {

                //called via our subscription to the machineDeleted messenger message
                //fires when a machine is deleted
                //also used when abandoning a new machine - null is passed as the id


                //otherwise the the form will stil show after the last machine is deleted !
                deselectAllMachines();
                
                var machine = findMachineById(data.id);

                machines.remove(machine);

            },

            

            //*******************************************
            addNewMachine = function () {

                //adds a new, empty machien to teh list - so we can add data to it in a form

                deselectAllMachines();

                //yes, we can create a new, null machine
                 var newMachineVM =  vmMachine.create();

                machines.push(newMachineVM);

                selected(newMachineVM);

                newMachineVM.activate();
            },
            
            init = function () {
                
                messenger.subscribe({
                    topic: config.messages.machineDeleted,
                    context: self,
                    callback: removeMachineById
                });
                

            }

	    ;


	    init();

	    return {
	        activate: activate,
	        machines: machines,
	        selected: selected,
	        load: load,
	        canLeave: canLeave,
	        select: select,
	        showSelectedElement: showSelectedElement,
	        //we have to expose config here - viewModel itself is not bound to (with applyBindings)
	        config: config,
	        addNewMachine: addNewMachine,
	        vmName: "viewModel.machines"
	    };
	});