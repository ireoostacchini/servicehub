define(function (require) {

        var
            //TODO: dependncies - mock



            // properties
            //-----------------

            debug = true;

            //********************dataServices
            serviceUrl = "http://localhost/ServiceHub/api/",


            //********************router

            title = 'ServiceHub Admin > ',

            routeGroups = {
              
                top: '.route-top'
            },

            hashes = {
                home: '#/',
                machines: '#/machines',
                machineServices: '#/machineServices',
                services: '#/services',
                credentials: '#/credentials'
            },


            //********************views
            viewIds = {
                shellTop: '#shell-top-view',
                machines: '#machines-view',
                machineServices: '#machineservices-view',
                services: '#services-view',
                credentials: '#credentials-view'
            },


            //********************messenger
            messages = {
                viewModelActivated: 'viewmodel-activation',
                dataLoaded: 'data-loaded'
            },


            //****************store
            stateKeys = {
                lastView: 'state.active-hash'
            },

            storeExpirationMs = (1000 * 60 * 60 * 24), // 1 day
            //storeExpirationMs = (1000 * 5), // 5 seconds



             //****************mocking

            _useMocks = false, // Set this to toggle mocks

            useMocks = function (val) {
                if (val) {
                    _useMocks = val;
                    init();
                }
                return _useMocks;
            },



            // methods
            //-----------------

            dataServiceInit = function () { },

            validationInit = function () {
                ko.validation.configure({
                    registerExtenders: true,    //default is true
                    messagesOnModified: true,   //default is true
                    insertMessages: true,       //default is true
                    parseInputAttributes: true, //default is false
                    writeInputAttributes: true, //default is false
                    messageTemplate: null,      //default is null
                    decorateElement: true       //default is false. Applies the .validationElement CSS class
                });
            },

            configureExternalTemplates = function () {
                infuser.defaults.templatePrefix = "_";
                infuser.defaults.templateSuffix = ".tmpl.html";
                infuser.defaults.templateUrl = "/ServiceHubAdmin/Tmpl";
            },

            init = function () {
                if (_useMocks) {
                    //dataServiceInit = mock.dataServiceInit;
                }
                dataServiceInit();


                configureExternalTemplates();
                validationInit();
            };

        init();

        return {
            debug: debug,
            serviceUrl: serviceUrl,
            dataServiceInit: dataServiceInit,
            hashes: hashes,
            messages: messages,
            stateKeys: stateKeys,
            storeExpirationMs: storeExpirationMs,
            title: title,
            routeGroups: routeGroups,
            useMocks: useMocks,
            viewIds: viewIds,
            window: window
        };
    });
