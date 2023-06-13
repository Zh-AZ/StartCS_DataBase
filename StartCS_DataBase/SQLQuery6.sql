--Create table Clients
--(
--	id int not null,
--	clients nvarchar(50) not null,
--	[values] nvarchar(20) not null
--)

--Create table Managers
--(
--	id int not null,
--	managers nvarchar(90) not null,
--	[description] nvarchar(55) not null
--)

--SELECT * FROM Clients WHERE Clients.id > 0
--INSERT INTO Clients ([id],[clients], [values]) values (01, 'Client_01', 'Val_01')

--SELECT * FROM Managers
--INSERT INTO Managers([id],[managers], [description]) values (02, 'Manager_02', 'Des_02')

--SET IDENTITY_INSERT TempTable ON

--INSERT INTO TempTable ([id], [title], [values], [Description]) values (2, 'Field', 'Value', 'Description')

--SELECT * FROM TempTable

--DELETE FROM Clients WHERE Clients.id = 1

--UPDATE Clients SET Clients.clients = 'New Field 5' WHERE Clients.id = 1

--DROP TABLE Clients

SELECT 
Clients.clients,
Managers.managers,
TempTable.id as 'ID_Client'
FROM Clients, Managers, TempTable
WHERE Clients.id = TempTable.id or Managers.id = TempTable.id

