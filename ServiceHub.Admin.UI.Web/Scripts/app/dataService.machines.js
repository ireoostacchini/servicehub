define('dataService.machines',
    [
        'jquery',
        'config',
        'amplify',
        'utils',
        'logger'

    ],
    function ($, config, amplify, utils, logger) {

        var

        getMachines = "getMachines",
        PUT = "put",

        //filled later by dataService.getData
        data = null,

        resourceName = 'machines',

        //we're using amplify.request.deferred, so requests are implemented using promises, 
        //rather than callbacks - makes for slightly simpler code
        getData = function () {
            return amplify.request(getMachines).promise();
        },

        //save an updated machine back to the data store
        //returns a promise - see http://joseoncode.com/2011/09/26/a-walkthrough-jquery-deferred-and-promise/
        updateMachine = function (machineVM) {

            var d = $.Deferred();

            var dto = utils.getDto(machineVM.model);

            //it's set to zero for the sake of the dropd-wn - clean up before we send it back
            if (dto.CredentialsId == 0) dto.CredentialsId = null;

            $.ajax({
                type: "PUT",
                url: config.serviceUrl + resourceName + "/" + dto.Id,
                data: dto,
                dataType: "json",
                cache: false,
            })
                //done won't do here - ti doesn't give us the response headers
              .success(function (data, textStatus, jqXHR) {

                  //update the version info - otherwise we can't save subsequently
                  var etag = jqXHR.getResponseHeader("ETag");

                  //but first get rid of the furniture that the webb puts around ETags
                  var version = utils.stripETagFurniture(etag);

                  machineVM.model.Version(version);

                  logger.info("machine updated successfully");

                  d.resolve();
              })
              .fail(function (data) {
                  logger.error("machine update failed: " + data.responseText);

                  d.reject();
              });

            return d.promise();
        },


                deleteMachine = function (machineVM) {

                    var d = $.Deferred();

                    var dto = utils.getDto(machineVM.model);

                    $.ajax({
                        type: "DELETE",
                        url: config.serviceUrl + resourceName + "/" + dto.Id,
                        data: dto,
                        dataType: "json",
                        cache: false,
                    })
                        .done(function () {
                            logger.info("machine deleted");
                            d.resolve();
                        })
                        .fail(function (data) {
                            logger.error("machine deletion failed: " + data.responseText);
                            d.reject();
                        });

                    return d.promise();
                },

                addMachine = function (machineVM) {

                    var d = $.Deferred();

                    var dto = utils.getDto(machineVM.model);

                    //it's set to zero for the sake of the dropd-wn - clean up before we send it back
                    if (dto.CredentialsId == 0) dto.CredentialsId = null;

                    $.ajax({
                        type: "POST",
                        url: config.serviceUrl + resourceName + "/",
                        data: dto,
                        dataType: "json",
                        cache: false,
                    })
                        .done(function (data, textStatus, jqXHR) {
                            
                            //update our model with values from the returned  data
                            machineVM.model.Id(data.MachineId);
                            machineVM.model.Version(data.RowVersion);
       
                            logger.info("machine added");
                            d.resolve();
                        })
                        .fail(function (data) {
                            logger.error("save failed: " + data.responseText);
                            d.reject();
                        });

                    return d.promise();
                },

        init = function () {

            // GET: /machines
            amplify.request.define(getMachines, 'ajax', {
                url: config.serviceUrl + resourceName,
                dataType: 'json',
                type: 'GET',
                decoder: "jSend"
                //cache:
            });



        };





        init();

        return {
            getData: getData,
            data: data,
            updateMachine: updateMachine,
            deleteMachine: deleteMachine,
            addMachine: addMachine

        };
    });


