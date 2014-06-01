define('snapshot',
[
        'config',
        'ko'

],
    function (config, ko) {

        //allows us to take a snapshot of a model, and revert the model back to the snapshot
        //long way to go before it's reuable though - it must work with:
        // observableArrays, nested observables + objects, non-validated observables


        var create = function (model) {

            var result = function () {

                var _model = model,

                    _snapshot = {},


                    //***********************************************
                    update = function (callback) {


                        var modelObservables = getModelObservables(_model);

                        ko.utils.arrayForEach(modelObservables, function (modelOb) {

                            var key = modelOb.key;
                            var observableFunction = modelOb.function;

                            _snapshot[key] = ko.utils.unwrapObservable(observableFunction);

                            console.log(key + ":" + observableFunction());

                        });

                        if (callback) callback();

                    },
                    
                    //***********************************************
                    revertModel = function (callback) {

                        var modelObservables = getModelObservables(_model);

                        ko.utils.arrayForEach(modelObservables, function (modelOb) {

                            var key = modelOb.key;
                            var observableFunction = modelOb.function;
                            var snapshotValue = _snapshot[key];

                            observableFunction(snapshotValue);


                            //  console.log(key + ":" + observableFunction());

                        });

                        if (callback) callback();

                    },

                    //***********************************************
                    getModelObservables = function () {
                        var result = [];

                        for (var key in _model) {


                            //filter out inherited prperties
                            if (!_model.hasOwnProperty(key)) continue;

                            //filter out non-functions
                            if (!_model[key].name) continue;

                            //filter out non-observables
                            if (!_model[key].name.toLowerCase().has("observable")) continue;

                            //filter out the 'errors' computed obsverable - caused by model being a validatedObservable
                            if (key == "errors") continue;


                            result.push({ "key": key, "function": _model[key] });

                        }
                        return result;
                    },
                    

                    //***********************************************
                    init = function () {

                        //set initial snapshot 
                        update();
                    };

                //***********************************************
                init();

                return {
                    update: update,
                    revertModel: revertModel
                };

            };


            //***********************************************
            var snapshot = result();

            return snapshot;
        };

        return {
            create: create

        };
    });