GO

CREATE PROCEDURE [dbo].[stpSaveUpdateSubjectMaster]
@ID INT,
@SubjectName VARCHAR(500),
@ClassId INT
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN
			IF @ID IS NULL
				BEGIN
					INSERT INTO SubjectMaster (SubjectName, ClassId) VALUES (@SubjectName, @ClassId)
					SET @ID = @@IDENTITY
				END
			ELSE
				BEGIN
					UPDATE SubjectMaster SET SubjectName = @SubjectName, ClassId = @ClassId WHERE ID =@ID 
				END 
		COMMIT TRAN
	END TRY 

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END

GO
CREATE PROCEDURE [dbo].[stpDeleteSubjectMasterBySubjectID]
@Id INT
AS
BEGIN
	BEGIN TRY
	BEGIN TRAN 
	DELETE FROM SubjectMaster WHERE ID = @Id
	COMMIT TRAN
	END TRY

	BEGIN CATCH
		ROLLBACK TRAN
		SELECT ERROR_MESSAGE() AS ErrorMessage
	END CATCH
END

GO
CREATE PROCEDURE [dbo].[stpGetSubjectDetailsAll]
AS
BEGIN
SELECT S.ID, S.SubjectName, S.ClassID, C.ClassName
FROM SubjectMaster S
INNER JOIN ClassMaster C
ON C.ID = S.ClassId
END

GO
CREATE PROCEDURE [dbo].[stpGetSubjectDetailsBySubjectID]
@ID INT
AS
BEGIN
SELECT S.ID, S.SubjectName, S.ClassID, C.ClassName
FROM SubjectMaster S
INNER JOIN ClassMaster C
ON C.ID = S.ClassId
WHERE S.ID = @ID
END

GO
CREATE PROCEDURE [dbo].[stpGetSubjectDetailsPageWise]
(
      @PageIndex INT = 1,
      @PageSize INT = 15,
      @RecordCount INT OUTPUT
)
AS
BEGIN
      SET NOCOUNT ON;
      SELECT ROW_NUMBER() OVER
      (
            ORDER BY [SubjectName] ASC
      )AS RowNumber
      ,S.ID,S.SubjectName, S.ClassID, C.ClassName
	

     INTO #Results
    FROM SubjectMaster S
	INNER JOIN ClassMaster C
	ON C.ID = S.ClassId
      SELECT @RecordCount = COUNT(*)
      FROM #Results
      SELECT * FROM #Results
      WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1
	 -- ORDER BY [Order] ASC
      DROP TABLE #Results
END