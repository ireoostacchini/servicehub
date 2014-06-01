requirejs.config({
    paths: {
        'text': 'durandal/amd/text'
    }
});

define(function(require) {
    var app = require('durandal/app'),
        viewLocator = require('durandal/viewLocator'),
        system = require('durandal/system'),
        router = require('durandal/plugins/router');
    
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'ServiceHub Admin';
    app.start().then(function () {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();
        
        //configure routing
        router.useConvention();
        
        router.mapNav('machines');
        router.mapRoute({ url: 'machines/:id', moduleId: 'viewmodels/machine', name: 'machine', visible: false });
        
        router.mapNav('services');
        
        router.mapNav('credentials');

        //map this last, or it'll activate for all urls. the routes are processed inthe order given here
        router.mapRoute({ url: '', moduleId: 'viewmodels/home', name: '', visible: false });

        app.adaptToDevice();
        
        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell', 'entrance');
    });
});