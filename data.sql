DELETE FROM MachineService
DELETE FROM Machine
DELETE FROM Service
DELETE FROM Credentials

DBCC CHECKIDENT('MachineService', RESEED, 0)
DBCC CHECKIDENT('Machine', RESEED, 0)
DBCC CHECKIDENT('Service', RESEED, 0)
DBCC CHECKIDENT('Credentials', RESEED, 0)

SET IDENTITY_INSERT [dbo].[Service] ON
INSERT [dbo].[Service] ([ServiceId], [FriendlyName], [ServiceName], [ExecutableName]) VALUES (1, N'Adobe Acrobat Update Service', N'AdobeArmService', N'armsvc.exe')
INSERT [dbo].[Service] ([ServiceId], [FriendlyName], [ServiceName], [ExecutableName]) VALUES (2, N'Print Spooler', N'Spooler', N'spoolsv.exe')
INSERT [dbo].[Service] ([ServiceId], [FriendlyName], [ServiceName], [ExecutableName]) VALUES (3, N'SNMP Trap', N'SNMPTRAP', N'snmptrap.exe')
SET IDENTITY_INSERT [dbo].[Service] OFF



SET IDENTITY_INSERT [dbo].[Credentials] ON
INSERT [dbo].[Credentials] ([CredentialsId], [Username], [Password]) VALUES (1, N'ireo', N'sLQaJ9ozgtOcqbI7lQ3mlO6QiAw7eTz2GRrda2xglIk=')
INSERT [dbo].[Credentials] ([CredentialsId], [Username], [Password]) VALUES (2, N'ireo2', N'sLQaJ9ozgtOcqbI7lQ3mlO6QiAw7eTz2GRrda2xglIk=')

SET IDENTITY_INSERT [dbo].[Credentials] OFF

SET IDENTITY_INSERT [dbo].[Machine] ON
INSERT [dbo].[Machine] ([MachineId], [FriendlyName], [Name], [CredentialsId]) VALUES (1, N'My PC', N'PC8', 1)
INSERT [dbo].[Machine] ([MachineId], [FriendlyName], [Name], [CredentialsId]) VALUES (2, N'My local machine', N'localhost', NULL)
SET IDENTITY_INSERT [dbo].[Machine] OFF


SET IDENTITY_INSERT [dbo].[MachineService] ON
INSERT [dbo].[MachineService] ([MachineServiceId], [MachineId], [ServiceId]) VALUES (1, 1, 1)
INSERT [dbo].[MachineService] ([MachineServiceId], [MachineId], [ServiceId]) VALUES (2, 1, 2)
INSERT [dbo].[MachineService] ([MachineServiceId], [MachineId], [ServiceId]) VALUES (3, 2, 1)
INSERT [dbo].[MachineService] ([MachineServiceId], [MachineId], [ServiceId]) VALUES (4, 2, 3)
INSERT [dbo].[MachineService] ([MachineServiceId], [MachineId], [ServiceId]) VALUES (5, 2, 2)
SET IDENTITY_INSERT [dbo].[MachineService] OFF

