----------------
ServiceHub
----------------


ServiceHub is a single-form WPF application that monitors windows services across a network, and allows you to restart those services, either one at a time or in a batch.

The application is fully functional, but has not been tested against unresponsive windows services. 

It uses .NET objects to minotor service state, whereas it uses lower-level SysInternals tools (pskill and psservice) to start / stop services (.NET offers no way to kill a service process).

The UI allows you to select several services using Shift + click or Ctrl + click, and then hit the Restart selected services button.

----------------
Configuration
----------------

Service.UI -> App.config:

	- MonitorInterval: defines the interval (in seconds) between checks of windows service status
	
	- DataServiceBaseUrl: the location of the WebApi service that provides config data for the application 


	
----------------
Design
----------------

The application design is shown in the \Docs\ServiceHub.asta file (you'll need Astah (http://astah.net/editions/community ) to view this - although I've saved a PNG file there too).

It is somewhat over-engineered - I wanted to test out the patterns and technologies that I would use in a mroe serious project.


----------------
Technologies
----------------


	- WPF with MVVM pattern (in Service.UI)

	- Data for the WPF app provided via WebAPI data service (requires MVC4 to be installed an dev machine)

	- Dependency injection used throughout, via Ninject. (No Service Locator is used)
	
	- DataContracts - using the Dto / AutoMapper implementation also used in PublisherClient
	
	- Data access pattern - UnitOfWork + Generic Repository (code taken from John Papa's PluraslSight course on Single Web Applications)
	
	- Config data held in an SQL Server Express (generated via Entity Framework code-first, with one migration added)
	
	- An Infrastructure component provides logging throughout via interface + DI (the component encapsulates Log4Net)
	
	- Encryption - passwords are stored in encrypted form in the database - an Encryptor class (stolen from Dan Wahlin's blog) decrypts the data in the application. There's a also unit test that helps you to do the encrypting.