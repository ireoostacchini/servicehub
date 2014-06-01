﻿define('viewModel.shell',
    ['ko', 'config'],
    function (ko, config) {
        var

            menuHashes = config.hashes,

            activate = function (routeData) {
                //No-Op for now
            },
            
            init = function () {
                activate();
            };

        init();

        return {
            activate: activate,
            menuHashes: menuHashes
        };
    });