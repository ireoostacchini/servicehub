define('utils',
['underscore', 'moment'],
    function (_, moment) {
        var

            //accepts a viewModel object (full of observables and functions)
            //and returns a simple js data object
            getDto = function (model) {

                var jsonData = ko.toJSON(model);

                var dto = JSON.parse(jsonData);

                return dto;
            },

            //http puts stuff around eTag strings - that are passed back after a PUT (update) call
            //we need to remove this, otherwise subsequent PUTs will fail
            //- the comparison with the stored value will fail, resulting in a concurrency exception
            stripETagFurniture = function (eTag) {

                //so W/"AAAAAAAAF5c=" becomes AAAAAAAAF5c=
                //we lose the W/" from the start and the " from the end

                var result = eTag.substring(3, eTag.length - 1);

                return result;
            },

            hasProperties = function (obj) {
                for (var prop in obj) {
                    if (obj.hasOwnProperty(prop)) {
                        return true;
                    }
                }
                return false;
            },
            invokeFunctionIfExists = function (callback) {
                if (_.isFunction(callback)) {
                    callback();
                }
            },
            mapMemoToArray = function (items) {
                var underlyingArray = [];
                for (var prop in items) {
                    if (items.hasOwnProperty(prop)) {
                        underlyingArray.push(items[prop]);
                    }
                }
                return underlyingArray;
            },
            regExEscape = function (text) {
                // Removes regEx characters from search filter boxes in our app
                return text.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, "\\$&");


            };

        return {
            getDto: getDto,
            stripETagFurniture:stripETagFurniture,
            hasProperties: hasProperties,
            invokeFunctionIfExists: invokeFunctionIfExists,
            mapMemoToArray: mapMemoToArray,
            regExEscape: regExEscape
        };
    });

