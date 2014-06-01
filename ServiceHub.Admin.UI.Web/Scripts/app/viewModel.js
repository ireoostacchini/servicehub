define('viewModel',
[
        'config',
        'ko',
        'viewModel.machines',
        'viewModel.machine',
        'viewModel.services',
        'viewModel.shell'
],
    function (config, ko, machines, machine, services, shell) {

        var
            config = config,

            load = function () {
                services.load();
                machines.load();

        };

        return {
            config: config,
            machines: machines,
            machine: machine,
            services:services,
            load: load,
            shell: shell,
            vmName: "viewModel"
        };
    });