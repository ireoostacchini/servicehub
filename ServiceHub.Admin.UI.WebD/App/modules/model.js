define(function (require) {

    var machine = require("modules/model.machine"),
        service = require("modules/model.service"),
        credential = require("modules/model.credential")
        ;

    return {
        machine: machine,
        service: service,
        credential: credential
    };

    });