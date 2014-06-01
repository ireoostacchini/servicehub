define('viewModel.service',
[
    'config',
	'logger'
	
],
	function (config,logger) {


	    var create = function (serviceName, friendlyName, executableName) {

	        var result =
				{
				    ServiceName: ko.observable(serviceName),
				    FriendlyName: ko.observable(friendlyName),
				    ExecutableName: ko.observable(executableName)

				};

	        return result;


	    },
	        


			activate = function (routeData, callback) {
				//messenger.publish.viewModelActivated({ canleaveCallback: canLeave });
			    logger.info("service " + routeData.id + " is activated");
			    
			}
			
		;




		return {
		    activate: activate,
		    create:create

		};
	});