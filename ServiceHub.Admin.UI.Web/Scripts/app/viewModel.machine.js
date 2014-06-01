define('viewModel.machine',
[
    'config',
    'ko',
	'logger',
    'dataService',
    'messenger',
    'router',
    'sugar',
    'snapshot'

],
	function (config, ko, logger, dataService, messenger, router, sugar, snapshot) {

	    //********************************************
	    //**********static creator of viewModel object
	    var create = function (machineId, name, friendlyName, credentialsId, rowVersion) {

	        //0 for the id - otherwise ko.toJSON (in utils.getDto) strips the field out
	        if (!machineId) machineId = 0;

	        var result = function () {

	            var//we track this for changes using DirtyFlag & HasChanges
	                //and revert changes via modelSnapshot & takeModelSnapshot

	                model = ko.validatedObservable({
	                    Id: ko.observable(machineId),
	                    Name: ko.observable(name).extend({ required: true }),
	                    FriendlyName: ko.observable(friendlyName).extend({ required: true }),
	                    CredentialsId: ko.observable(credentialsId).extend({ number: true }),
	                    Version: ko.observable(rowVersion)
	                }),
	                
                    //inititalised in init() - keeps track of last saved state
	                //so  we can revert on hitting the Cancel button
                    modelSnapshot = null,
	                
	                isSelected = ko.observable(false),

                    isNew = ko.computed(function () {

	                    //if it has a zero Id, it's new
	                    return (model().Id()==0);

	                }),
	                url =  ko.computed(function () {

	                    return config.hashes.machines + "/" + model().Id();
	                }),
	                  

                    activate = function (routeData, callback) {

	                    this.isSelected(true); //so we know how to style each machine in the list

	                    messenger.publish.viewModelActivated({ canleaveCallback: canLeave });

	                    logger.info("machine " + model().Name() + " is activated");

	                },
	                //********************************************
	                //*************************************Credentials

	                //for now, this is statis lookup data, so we can cache it
	                credentialsList = null,
	                selectedCredentials = null,
	                getCredentialsList = function () {

	                    if (credentialsList == null) {

	                        //slice(0) creates a copy of the array
	                        credentialsList = dataService.credentials.data.slice(0);

	                        var zeroOption = { "CredentialsId": 0, "Username": "Choose..." };

	                        //unshift places an object at the start of an array
	                        credentialsList.unshift(zeroOption);
	                    }
	                    return credentialsList;
	                },
	                //**********************************************
	            //*************************************changes

	            //we monitor these properties for changes
	                dirtyFlag = new ko.DirtyFlag([model()]),
	                //called on leaving a page - if false, the move is stopped, and a message shown
	                canLeave = function () {

	                    //if it's a new machine, let the user leave - and ask for it to be deleted 
	                    if (isNew()) {

	                        //viewmodel.machines subscribes to this and removes the machine
	                        messenger.publish.machineDeleted({ "id": null });
	                        return true;

	                    }

	                    return !hasChanges() && model().isValid();
	                },
	                hasChanges = ko.computed(function () {

	                    return dirtyFlag().isDirty();

	                }),

	                
	                //********************************************
	                //*************************************Commands
	                saveCmd = ko.asyncCommand({
	                    execute: function (complete) {

	                        var self = this;

	                        var isAdding = isNew();


	                        //we must call this.isValid - just isValid() always returns true, for some reason
	                        if (!model().isValid()) {
	                            logger.error("Machine has invalid data - please amend before saving");
	                            return;
	                        }

	                        var saveFunc = isAdding ? dataService.machines.addMachine : dataService.machines.updateMachine;

	                        //update method is a promise - we can wait for it to complete
	                        //then act accordingly
	                        $.when(
	                            
                                saveFunc(self)
                	        ).
	                        done(
	                            function (x) {

	                                //we update the 'original state' - used for teh cancel button
	                                modelSnapshot.update();

	                                dirtyFlag().reset();

	                                if(isAdding) router.navigateTo(config.hashes.machines + "/" + model().Id());

	                            }
	                        ).always(
	                            function () {
	                                //have to call complete, or the button won't re-enable
	                                //even if it fails, we have a chance to resave
	                                complete();
	                            });


	                    },
	                    canExecute: function (isExecuting) {

	                        //return (!isExecuting) is the default behaviour
	                        //this stops the event firing twice on successive button presses
	                        //and also if the data is as originally loaded
	                        return (!isExecuting && hasChanges());
	                    }
	                }),


                    //****************************************
                    selectCancelCmd = function () {

                        //used in the machine template
                        //we use a differetn cancel method for a new machine
                        return isNew() ? cancelNewCmd : cancelCmd;
                    },

	                //****************************************
	                cancelCmd = ko.asyncCommand({



	                    execute: function (complete) {

	                        var callback = function () {
	                            complete();
	                            logger.success(logger.toasts.retreivedData);
	                        };


	                        modelSnapshot.revertModel(callback);

	                    },
	                    canExecute: function (isExecuting) {

	                        //only let it work if the data is changed
	                        return !isExecuting && hasChanges();
	                    }
	                }),


                    //****************************************used to cancel a new machine
                    cancelNewCmd = ko.asyncCommand({

                        execute: function () {

                            //viewmodel.machines subscribes to this and removes the machine
                            messenger.publish.machineDeleted({ "id": null });

                            router.navigateTo(config.hashes.machines);

                        }
                    }),



	                //****************************************
	                deleteCmd = ko.asyncCommand({
	                    execute: function (complete) {

	                        var self = this;

	                        $.when(
	                            dataService.machines.deleteMachine(self)
	                        ).done(
	                            function () {


	                                messenger.publish.machineDeleted({ "id": model().Id() });

	                                router.navigateTo(config.hashes.machines);
	                            }
	                        ).always(
	                            function () {

	                                complete();
	                            });
	                    }
	                }),


	                //****************************************
	                //***********************************init

	                init = function () {

	                    modelSnapshot = snapshot.create(model());

	                };

	            init();


	            //********************************************
	            //*************************************Public
	            return {
	                model: model(),

	                activate: activate,
	                isSelected: isSelected,
	                isNew: isNew,
	                url: url,

	                getCredentialsList: getCredentialsList,
	                selectedCredentials: selectedCredentials,

	                saveCmd: saveCmd,
	                cancelCmd: cancelCmd,
	                deleteCmd: deleteCmd,
	                selectCancelCmd: selectCancelCmd,

	                hasChanges: hasChanges,
	                canLeave: canLeave
	            };

	        };

	        //run the function to get the result - then we can add functions
	        //that require the vm itself to be referenced
	        var viewmodel = result();

	        return viewmodel;
	    };


	    //********************************************
	    //*************************************Public - create
	    return {
	        create: create
	    };


	});