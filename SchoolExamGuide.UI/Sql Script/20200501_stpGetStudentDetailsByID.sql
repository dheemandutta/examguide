USE [SchoolExamDB]
GO
/****** Object:  StoredProcedure [dbo].[stpGetStudentDetailsByID]    Script Date: 01/05/2020 7:36:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec stpGetStudentDetailsByID 6

ALTER PROCEDURE [dbo].[stpGetStudentDetailsByID]
(
	@ID int
)
AS
Begin

Select ID, StudentId, StateId, DistrictId, ClassId, GuardiansName, GuardiansMob
 FROM StudentDetails

	WHERE ID = @ID



--Select SD.ID, S.Name, SM.[State], DM.District, CM.ClassName, SD.GuardiansName, SD.GuardiansMob
-- FROM StudentDetails SD

--	INNER JOIN Student S
--	ON S.ID = SD.StudentId

--	INNER JOIN StateMaster SM
--	ON SM.ID = SD.StateId

--	INNER JOIN DistrictMaster DM
--	ON DM.ID = SD.DistrictId

--	INNER JOIN ClassMaster CM
--	ON CM.ID = SD.ClassId

--	WHERE SD.ID = @ID

End