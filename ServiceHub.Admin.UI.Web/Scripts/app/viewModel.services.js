define('viewModel.services',
[
		'ko',
		'logger',
		'dataService',
		'messenger',
        'viewModel.service'
],
	function (ko, logger, dataService, messenger, vmService) {

	    var services = ko.observableArray(),
	        addData = function(serviceDtoArray) {

	            var newItems = ko.utils.arrayMap(serviceDtoArray, function(serviceDto) {
	                return vmService.create(serviceDto.Name, serviceDto.FriendlyName);
	            });

	            //take advantage of push accepting variable arguments
	            services.push.apply(services, newItems);
	        },
	        load = function() {

	            //reset
	            services.removeAll();

	            addData(dataService.services.data);

	            logger.info(services._latestValue.length + ' services loaded');

	        },
	        activate = function(routeData, callback) {

	            messenger.publish.viewModelActivated({ canleaveCallback: canLeave });
	            logger.debug("service route activated");

	        },
	        canLeave = function() {

	            return true;
	        };


	    return {
	        activate: activate,
	        services: services,
	        load: load,
	        canLeave: canLeave
	    };
	});