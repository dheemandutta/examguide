CREATE PROCEDURE [dbo].[stpGetClassDetailsAll]
AS
BEGIN 
	SELECT ID, ClassName
	FROM ClassMaster 
END