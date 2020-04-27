--exec stpGetClassMasterByID 1

create PROCEDURE [dbo].[stpGetClassMasterByID]
(
	@ID int
)
AS
Begin
Select ID,ClassName
FROM ClassMaster 

WHERE ID = @ID
End
