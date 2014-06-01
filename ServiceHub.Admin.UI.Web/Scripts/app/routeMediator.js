define('route-mediator',
['messenger', 'config'],
    function (messenger, config) {

        var self = this,
            
            //holds a ref to the currently-activated VM's canLeave method
            //called by our (ie the mediator's) canLeave method just before a route is processed
            canleaveCallback,

            //ask the messenger to notify us when a VM is activated
            //activation passes us the VM's canLeave callback function
            //which we check in the 'before leaving' event handler
            //to see if a VM has pending changes
            subscribeToViewModelActivations = function () {

                messenger.subscribe({
                    topic: config.messages.viewModelActivated,
                    context: self,
                    callback: viewModelActivated
                });
            },


            //passed by subscribeToViewModelActivations to the messenger
            //called when a VM is activated
            //holds a ref to the VM's canLeave function
            viewModelActivated = function (options) {

                canleaveCallback = options && options.canleaveCallback;
            },


            // Check the active view model to see if we can leave it
            canLeave = function () {

                var result = canleaveCallback ? canleaveCallback() : true;

                return result;
            },


        init = function () {

            subscribeToViewModelActivations();
        };

        init();

        return {
            canLeave: canLeave
        };
    });
