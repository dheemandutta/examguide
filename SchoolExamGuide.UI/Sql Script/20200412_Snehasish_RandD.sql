CREATE PROCEDURE [dbo].[stpGetChapterDetailsSubjectPageWise]
(
      @PageIndex INT = 1,
      @PageSize INT = 15,
      @RecordCount INT OUTPUT,
      @SubjectId INT
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
	WHERE C.SubjectId = @SubjectID

     
      SELECT @RecordCount = COUNT(*)
      FROM #Results
      SELECT * FROM #Results
      WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1
	 -- ORDER BY [Order] ASC
      DROP TABLE #Results
END







