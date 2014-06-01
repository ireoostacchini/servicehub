{
  "name": "durandal/amd/almond-custom",
  "inlineText": true,
  "stubModules": [
    "durandal/amd/text"
  ],
  "paths": {
    "text": "durandal/amd/text"
  },
  "baseUrl": "D:\\My Documents\\cromaticaSoftware\\Apps\\ServiceHub\\ServiceHub.Admin.UI.WebD\\App",
  "mainConfigFile": "D:\\My Documents\\cromaticaSoftware\\Apps\\ServiceHub\\ServiceHub.Admin.UI.WebD\\App\\main.js",
  "include": [
    "main-built",
    "main",
    "durandal/app",
    "durandal/composition",
    "durandal/events",
    "durandal/http",
    "text!durandal/messageBox.html",
    "durandal/messageBox",
    "durandal/modalDialog",
    "durandal/system",
    "durandal/viewEngine",
    "durandal/viewLocator",
    "durandal/viewModel",
    "durandal/viewModelBinder",
    "durandal/widget",
    "durandal/plugins/router",
    "durandal/transitions/entrance",
    "viewmodels/shell",
    "viewmodels/welcome",
    "text!views/detail.html",
    "text!views/shell.html",
    "text!views/welcome.html"
  ],
  "exclude": [],
  "keepBuildDir": true,
  "optimize": "uglify2",
  "out": "D:\\My Documents\\cromaticaSoftware\\Apps\\ServiceHub\\ServiceHub.Admin.UI.WebD\\App\\main-built.js",
  "pragmas": {
    "build": true
  },
  "wrap": true,
  "insertRequire": [
    "main"
  ]
}