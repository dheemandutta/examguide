
GO
CREATE PROCEDURE [dbo].[stpSaveUpdateChapterMaster]
(
@Id INT,
@ChapterName VARCHAR(500),
@SubjectId INT
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN	
			IF @Id IS NULL 
			BEGIN
					INSERT INTO ChapterMaster (ChapterName, SubjectId) VALUES (@ChapterName, @SubjectId)
					SET @Id=@@IDENTITY
				END
			ELSE
				BEGIN
					UPDATE ChapterMaster SET ChapterName=@ChapterName, SubjectId=@SubjectId WHERE Id=@Id
				END		
		COMMIT TRAN
	END TRY
	BEGIN CATCH 
		ROLLBACK TRAN
		SELECT ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END

GO
CREATE PROCEDURE [dbo].[stpDeleteChapterMasterByChapterID]
@Id INT
AS
BEGIN 
	BEGIN TRY
		BEGIN TRAN
			DELETE FROM ChapterMaster WHERE ID=@Id
		COMMIT TRAN
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ErrorMessage
	END CATCH
END

GO
CREATE PROCEDURE [dbo].[stpGetChapterDetailsByChapterID]
@Id INT
AS
BEGIN 
	SELECT C.Id, C.ChapterName, C.SubjectId, S.SubjectName, S.ClassId, CL.ClassName
	FROM ChapterMaster AS C
	INNER JOIN SubjectMaster AS S
	ON C.SubjectId = S.ID
	INNER JOIN ClassMaster AS CL
	ON S.ClassId = CL.ID
	WHERE C.Id=@Id
END

GO
CREATE PROCEDURE [dbo].[stpGetChapterDetailsPageWise]
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
            ORDER BY [ChapterName] ASC
      )AS RowNumber
      ,C.Id, C.ChapterName, C.SubjectId, S.SubjectName, S.ClassId, CL.ClassName
	INTO #Results
	FROM ChapterMaster AS C
	INNER JOIN SubjectMaster AS S
	ON C.SubjectId = S.ID
	INNER JOIN ClassMaster AS CL
	ON S.ClassId = CL.ID
 
	SELECT @RecordCount = COUNT(*)
	FROM #Results
	SELECT * FROM #Results
	WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1
	 -- ORDER BY [Order] ASC
	DROP TABLE #Results
END

GO
CREATE PROCEDURE [dbo].[stpGetChapterDetailsBySubjectID]
@SubjectID INT
AS
BEGIN 
	SELECT C.Id, C.ChapterName, C.SubjectId, S.SubjectName, S.ClassId, CL.ClassName
	FROM ChapterMaster AS C
	INNER JOIN SubjectMaster AS S
	ON C.SubjectId = S.ID
	INNER JOIN ClassMaster AS CL
	ON S.ClassId = CL.ID
	WHERE C.SubjectId = @SubjectID
END

GO
CREATE PROCEDURE [dbo].[stpGetChapterDetailsAll]
AS
BEGIN 
	SELECT C.Id, C.ChapterName, C.SubjectId, S.SubjectName, S.ClassId, CL.ClassName
	FROM ChapterMaster AS C
	INNER JOIN SubjectMaster AS S
	ON C.SubjectId = S.ID
	INNER JOIN ClassMaster AS CL
	ON S.ClassId = CL.ID
END

