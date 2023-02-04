use SkiServicePA;
GO


CREATE VIEW Orders 
AS
Select Id, Name, EMail, Phone, CreateDate, PickupDate, Kommentar, ServiceName, PriorityName, StatusName  from Registration
INNER JOIN Priority
ON Registration.PriorityId = Priority.PriorityId
INNER JOIN Service
ON Registration.PriorityId = Service.ServiceId
INNER JOIN Status
ON Registration.StatusId = Status.StatusId;
GO

Select * from Orders
For JSON PATH,
		INCLUDE_NULL_VALUES;
		GO


-- this turns on advanced options and is needed to configure xp_cmdshell
EXEC sp_configure 'show advanced options', '1'
RECONFIGURE
-- erlauben des xp_cmdshell
EXEC sp_configure 'xp_cmdshell', '1' 
RECONFIGURE

-- OBCD driver muss aktualisiert sein und Connections haben zur DB
DECLARE @sql varchar(1000)
SET @sql = 'bcp "SELECT * FROM Orders ' + 
    'FOR JSON PATH, INCLUDE_NULL_VALUES" ' +
    'queryout  "D:\Temp\Registration.json" ' + 
    '-c -S MACWIN2 -d WideWorldImporters -T'
EXEC sys.XP_CMDSHELL @sql
GO
