define('binder',
    [
        'jquery',
        'ko',
        'config',
        'viewModel'
    ],
    function ($, ko, config, viewModel) {


        var

            bind = function () {

                ko.applyBindings(viewModel.machines, $(config.viewIds.machines).get(0));
                ko.applyBindings(viewModel.services, $(config.viewIds.services).get(0));
                ko.applyBindings(viewModel.shell, $(config.viewIds.shellTop).get(0));
            }



        return {
            bind: bind
        };
    });
