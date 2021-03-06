USE [SchoolExamDB]
GO
/****** Object:  Table [dbo].[AnswerMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AnswerMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AnswerText] [varchar](5000) NOT NULL,
	[IsRightAnswer] [bit] NULL,
	[QuestionID] [int] NOT NULL,
 CONSTRAINT [PK_AnswerMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ChapterMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ChapterMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChapterName] [varchar](500) NOT NULL,
	[SubjectId] [int] NOT NULL,
 CONSTRAINT [PK_ChapterMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [varchar](500) NOT NULL,
 CONSTRAINT [PK_ClassMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DistrictMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DistrictMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[District] [varchar](500) NOT NULL,
	[StateID] [int] NOT NULL,
 CONSTRAINT [PK_DistrictMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExamMarks]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamMarks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[MarksObtained] [decimal](12, 2) NOT NULL,
	[TotalMarks] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_ExamMarks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExamTime]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExamTime](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExamTime] [datetime] NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_ExamTime] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FeesMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeesMaster](
	[ClassId] [int] NOT NULL,
	[Fees] [decimal](12, 2) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PageMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PageMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [varchar](500) NOT NULL,
 CONSTRAINT [PK_PageMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuestionMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [varchar](max) NOT NULL,
	[Marks] [decimal](12, 2) NOT NULL,
	[IsActive] [bit] NULL,
	[SubjectID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[ImagePath] [varchar](max) NULL,
 CONSTRAINT [PK_QuestionMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StateMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StateMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[State] [varchar](100) NOT NULL,
 CONSTRAINT [PK_StateMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[MobileNumber] [varchar](20) NULL,
	[FirstName] [varchar](500) NOT NULL,
	[LastName] [varchar](500) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentDetails]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentDetails](
	[StudentId] [int] NOT NULL,
	[GuardiansName] [varchar](500) NOT NULL,
	[GuardiansMob] [varchar](20) NULL,
	[StateId] [int] NOT NULL,
	[DistrictId] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_StudentDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentLog]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PageID] [int] NOT NULL,
	[AccessDate] [datetime] NOT NULL,
 CONSTRAINT [PK_StudentLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SubjectMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](500) NOT NULL,
	[ClassId] [int] NOT NULL,
 CONSTRAINT [PK_SubjectMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TempAnswer]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TempAnswer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionID] [int] NOT NULL,
	[ChoiceText] [varchar](2000) NOT NULL,
	[IsAnswer] [bit] NULL,
	[IsUsedAnswer] [bit] NULL,
	[StudentID] [int] NOT NULL,
	[ChoiceID] [int] NOT NULL,
 CONSTRAINT [PK_TempAnswer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TempQuestion]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TempQuestion](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[QuestionText] [varchar](max) NOT NULL,
	[Marks] [decimal](12, 2) NOT NULL,
	[RowNo] [decimal](12, 2) NOT NULL,
	[StudentID] [int] NOT NULL,
 CONSTRAINT [PK_TempQuestion] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ChapterMaster] ON 

INSERT [dbo].[ChapterMaster] ([Id], [ChapterName], [SubjectId]) VALUES (1, N'Tenali Rama', 2)
INSERT [dbo].[ChapterMaster] ([Id], [ChapterName], [SubjectId]) VALUES (3, N'zzzzzzzzzz 2', 2)
INSERT [dbo].[ChapterMaster] ([Id], [ChapterName], [SubjectId]) VALUES (4, N'test ok2', 2)
INSERT [dbo].[ChapterMaster] ([Id], [ChapterName], [SubjectId]) VALUES (5, N'test ok23', 2)
INSERT [dbo].[ChapterMaster] ([Id], [ChapterName], [SubjectId]) VALUES (8, N'eeeeee 2', 2)
SET IDENTITY_INSERT [dbo].[ChapterMaster] OFF
SET IDENTITY_INSERT [dbo].[ClassMaster] ON 

INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (1, N'i')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (2, N'ii')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (3, N'iii')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (4, N'iv')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (5, N'v')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (6, N'vi')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (7, N'vii')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (8, N'viii')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (9, N'ix')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (10, N'x')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (11, N'xi')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (12, N'xii')
INSERT [dbo].[ClassMaster] ([ID], [ClassName]) VALUES (21, N'fbhggvhn 2')
SET IDENTITY_INSERT [dbo].[ClassMaster] OFF
SET IDENTITY_INSERT [dbo].[DistrictMaster] ON 

INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (1, N'Alipurduar', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (2, N'Bankura', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (3, N'Birbhum', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (4, N'Cooch Behar', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (5, N'Dakshin Dinajpur', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (6, N'Darjeeling', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (7, N'Hooghly', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (8, N'Howrah', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (9, N'Jalpaiguri', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (10, N'Jhargram', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (11, N'Kalimpong', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (12, N'Kolkata', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (13, N'Malda', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (14, N'Murshidabad', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (15, N'Nadia', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (16, N'North 24 Parganas', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (17, N'Paschim Bardhaman', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (18, N'Paschim Medinipur', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (19, N'Purba Bardhaman', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (20, N'Purba Medinipur', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (21, N'Purulia', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (22, N'South 24 Parganas', 25)
INSERT [dbo].[DistrictMaster] ([ID], [District], [StateID]) VALUES (23, N'Uttar Dinajpur', 25)
SET IDENTITY_INSERT [dbo].[DistrictMaster] OFF
SET IDENTITY_INSERT [dbo].[StateMaster] ON 

INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (1, N'ANDHRA PRADESH')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (2, N'ASSAM')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (3, N'ARUNACHAL PRADESH')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (4, N'GUJRAT')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (5, N'BIHAR')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (6, N'HARYANA')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (7, N'HIMACHAL PRADESH')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (8, N'JAMMU & KASHMIR')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (9, N'KARNATAKA')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (10, N'KERALA')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (11, N'MADHYA PRADESH')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (12, N'MAHARASHTRA')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (13, N'Telangana')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (14, N'MANIPUR')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (15, N'MEGHALAYA')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (16, N'MIZORAM')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (17, N'NAGALAND')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (18, N'ORISSA')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (19, N'PUNJAB')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (20, N'RAJASTHAN')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (21, N'SIKKIM')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (22, N'TAMIL NADU')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (23, N'TRIPURA')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (24, N'UTTAR PRADESH')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (25, N'WEST BENGAL')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (26, N'GOA')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (27, N'PONDICHERY')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (28, N'LAKSHDWEEP')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (29, N'DAMAN & DIU')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (30, N'DADRA & NAGAR')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (31, N'CHANDIGARH')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (32, N'ANDAMAN & NICOBAR')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (33, N'UTTARANCHAL')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (34, N'JHARKHAND')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (35, N'CHATTISGARH')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (36, N'ASSAM')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (37, N'zzzzzz')
INSERT [dbo].[StateMaster] ([Id], [State]) VALUES (38, N'gfhghgjjh')
SET IDENTITY_INSERT [dbo].[StateMaster] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [Name], [MobileNumber], [FirstName], [LastName], [Password]) VALUES (1, N'Prasenjit Paul', N'9903263880', N'Prasenjit ', N'Paul', N'12345')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[StudentDetails] ON 

INSERT [dbo].[StudentDetails] ([StudentId], [GuardiansName], [GuardiansMob], [StateId], [DistrictId], [ID], [ClassId]) VALUES (1, N'P.Paul', N'9903263880', 1, 1, 6, 1)
SET IDENTITY_INSERT [dbo].[StudentDetails] OFF
SET IDENTITY_INSERT [dbo].[SubjectMaster] ON 

INSERT [dbo].[SubjectMaster] ([ID], [SubjectName], [ClassId]) VALUES (1, N'Bengali', 8)
INSERT [dbo].[SubjectMaster] ([ID], [SubjectName], [ClassId]) VALUES (2, N'English', 8)
SET IDENTITY_INSERT [dbo].[SubjectMaster] OFF
ALTER TABLE [dbo].[AnswerMaster]  WITH CHECK ADD  CONSTRAINT [FK_AnswerMaster_QuestionMaster] FOREIGN KEY([QuestionID])
REFERENCES [dbo].[QuestionMaster] ([Id])
GO
ALTER TABLE [dbo].[AnswerMaster] CHECK CONSTRAINT [FK_AnswerMaster_QuestionMaster]
GO
ALTER TABLE [dbo].[ChapterMaster]  WITH CHECK ADD  CONSTRAINT [FK_ChapterMaster_SubjectMaster] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[SubjectMaster] ([ID])
GO
ALTER TABLE [dbo].[ChapterMaster] CHECK CONSTRAINT [FK_ChapterMaster_SubjectMaster]
GO
ALTER TABLE [dbo].[DistrictMaster]  WITH CHECK ADD  CONSTRAINT [FK_DistrictMaster_StateMaster] FOREIGN KEY([StateID])
REFERENCES [dbo].[StateMaster] ([Id])
GO
ALTER TABLE [dbo].[DistrictMaster] CHECK CONSTRAINT [FK_DistrictMaster_StateMaster]
GO
ALTER TABLE [dbo].[ExamMarks]  WITH CHECK ADD  CONSTRAINT [FK_ExamMarks_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[ExamMarks] CHECK CONSTRAINT [FK_ExamMarks_Student]
GO
ALTER TABLE [dbo].[ExamTime]  WITH CHECK ADD  CONSTRAINT [FK_ExamTime_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[ExamTime] CHECK CONSTRAINT [FK_ExamTime_Student]
GO
ALTER TABLE [dbo].[QuestionMaster]  WITH CHECK ADD  CONSTRAINT [FK_QuestionMaster_ClassMaster] FOREIGN KEY([ClassID])
REFERENCES [dbo].[ClassMaster] ([ID])
GO
ALTER TABLE [dbo].[QuestionMaster] CHECK CONSTRAINT [FK_QuestionMaster_ClassMaster]
GO
ALTER TABLE [dbo].[QuestionMaster]  WITH CHECK ADD  CONSTRAINT [FK_QuestionMaster_SubjectMaster] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[SubjectMaster] ([ID])
GO
ALTER TABLE [dbo].[QuestionMaster] CHECK CONSTRAINT [FK_QuestionMaster_SubjectMaster]
GO
ALTER TABLE [dbo].[StudentDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentDetails_ClassMaster] FOREIGN KEY([ClassId])
REFERENCES [dbo].[ClassMaster] ([ID])
GO
ALTER TABLE [dbo].[StudentDetails] CHECK CONSTRAINT [FK_StudentDetails_ClassMaster]
GO
ALTER TABLE [dbo].[StudentDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentDetails_DistrictMaster] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[DistrictMaster] ([ID])
GO
ALTER TABLE [dbo].[StudentDetails] CHECK CONSTRAINT [FK_StudentDetails_DistrictMaster]
GO
ALTER TABLE [dbo].[StudentDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentDetails_StateMaster] FOREIGN KEY([StateId])
REFERENCES [dbo].[StateMaster] ([Id])
GO
ALTER TABLE [dbo].[StudentDetails] CHECK CONSTRAINT [FK_StudentDetails_StateMaster]
GO
ALTER TABLE [dbo].[StudentDetails]  WITH CHECK ADD  CONSTRAINT [FK_StudentDetails_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[StudentDetails] CHECK CONSTRAINT [FK_StudentDetails_Student]
GO
ALTER TABLE [dbo].[StudentLog]  WITH CHECK ADD  CONSTRAINT [FK_StudentLog_PageMaster] FOREIGN KEY([PageID])
REFERENCES [dbo].[PageMaster] ([Id])
GO
ALTER TABLE [dbo].[StudentLog] CHECK CONSTRAINT [FK_StudentLog_PageMaster]
GO
ALTER TABLE [dbo].[SubjectMaster]  WITH CHECK ADD  CONSTRAINT [FK_SubjectMaster_ClassMaster] FOREIGN KEY([ClassId])
REFERENCES [dbo].[ClassMaster] ([ID])
GO
ALTER TABLE [dbo].[SubjectMaster] CHECK CONSTRAINT [FK_SubjectMaster_ClassMaster]
GO
/****** Object:  StoredProcedure [dbo].[stpDeleteChapterMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec stpDeleteChapterMaster 2
create procedure [dbo].[stpDeleteChapterMaster] 
( 
@ID int
) 
AS 
BEGIN 

DELETE FROM ChapterMaster WHERE ID=@ID;
 
END
GO
/****** Object:  StoredProcedure [dbo].[stpDeleteChapterMasterByChapterID]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[stpDeleteClassMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec stpDeleteClassMaster 15
CREATE procedure [dbo].[stpDeleteClassMaster] 
( 
@ID int
) 
AS 
BEGIN 

DELETE FROM ClassMaster WHERE ID=@ID;
 
END






















GO
/****** Object:  StoredProcedure [dbo].[stpDeleteStateMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--exec stpDeleteStateMaster 18
create procedure [dbo].[stpDeleteStateMaster] 
( 
@ID int
) 
AS 
BEGIN 

DELETE FROM StateMaster WHERE ID=@ID;
 
END






















GO
/****** Object:  StoredProcedure [dbo].[stpDeleteStudentDetails]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec stpDeleteStudentDetails 5
create procedure [dbo].[stpDeleteStudentDetails] 
( 
@ID int
) 
AS 
BEGIN 

DELETE FROM StudentDetails WHERE ID=@ID;
 
END
GO
/****** Object:  StoredProcedure [dbo].[stpDeleteSubjectMasterBySubjectID]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[stpGetChapterDetailsAll]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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


GO
/****** Object:  StoredProcedure [dbo].[stpGetChapterDetailsByChapterID]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[stpGetChapterDetailsBySubjectID]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[stpGetChapterDetailsPageWise]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[stpGetChapterDetailsSubjectPageWise]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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








GO
/****** Object:  StoredProcedure [dbo].[stpGetClassDetailsAll]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpGetClassDetailsAll]
AS
BEGIN 
	SELECT ID, ClassName
	FROM ClassMaster 
END
GO
/****** Object:  StoredProcedure [dbo].[stpGetClassMasterByID]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec stpGetClassMasterByID 1004

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

GO
/****** Object:  StoredProcedure [dbo].[stpGetClassMasterPageWise]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--  declare @x int Exec stpGetClassMasterPageWise 1,15, @x out

CREATE PROCEDURE [dbo].[stpGetClassMasterPageWise]
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
            ORDER BY [ID] ASC
      )AS RowNumber
      ,ID
      ,ClassName

     INTO #Results
      FROM ClassMaster
     
	 --Where ID=@ID
	    --Where IsActive=1
		 
      SELECT @RecordCount = COUNT(*)
      FROM #Results
      SELECT * FROM #Results
      WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1
	 -- ORDER BY [Order] ASC
      DROP TABLE #Results
END
GO
/****** Object:  StoredProcedure [dbo].[stpGetStudentDetailsByID]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--exec stpGetStudentDetailsByID 5

CREATE PROCEDURE [dbo].[stpGetStudentDetailsByID]
(
	@ID int
)
AS
Begin
Select SD.ID, S.Name, SM.[State], DM.District, CM.ClassName, SD.GuardiansName, SD.GuardiansMob
 FROM StudentDetails SD

	INNER JOIN Student S
	ON S.ID = SD.StudentId

	INNER JOIN StateMaster SM
	ON SM.ID = SD.StateId

	INNER JOIN DistrictMaster DM
	ON DM.ID = SD.DistrictId

	INNER JOIN ClassMaster CM
	ON CM.ID = SD.ClassId

	WHERE SD.ID = @ID
End
GO
/****** Object:  StoredProcedure [dbo].[stpGetStudentDetailsPageWise]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- declare @x int Exec stpGetStudentDetailsPageWise 1,15, @x out
create PROCEDURE [dbo].[stpGetStudentDetailsPageWise]
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
            ORDER BY [GuardiansName] ASC
      )AS RowNumber
      ,SD.ID, S.Name, SM.[State], DM.District, CM.ClassName, SD.GuardiansName, SD.GuardiansMob
	

     INTO #Results
    FROM StudentDetails SD

	INNER JOIN Student S
	ON S.ID = SD.StudentId

	INNER JOIN StateMaster SM
	ON SM.ID = SD.StateId

	INNER JOIN DistrictMaster DM
	ON DM.ID = SD.DistrictId

	INNER JOIN ClassMaster CM
	ON CM.ID = SD.ClassId


      SELECT @RecordCount = COUNT(*)
      FROM #Results
      SELECT * FROM #Results
      WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 AND(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1
	 -- ORDER BY [Order] ASC
      DROP TABLE #Results
END


GO
/****** Object:  StoredProcedure [dbo].[stpGetSubjectDetailsAll]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[stpGetSubjectDetailsByClassID]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stpGetSubjectDetailsByClassID]
@ClassID INT
AS
BEGIN
SELECT S.ID, S.SubjectName, S.ClassID, C.ClassName
FROM SubjectMaster S
INNER JOIN ClassMaster C
ON C.ID = S.ClassId
WHERE S.ClassId = @ClassID
END


GO
/****** Object:  StoredProcedure [dbo].[stpGetSubjectDetailsBySubjectID]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[stpGetSubjectDetailsPageWise]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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


GO
/****** Object:  StoredProcedure [dbo].[stpSaveChapterMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- exec stpSaveChapterMaster 17,'test ok2', 2
create procedure [dbo].[stpSaveChapterMaster] 
( 
@ID int,
@ChapterName varchar(500),
@SubjectId int
) 
AS 
BEGIN 
--DECLARE @FleetID int
 BEGIN TRY
    BEGIN TRAN
 IF @ID IS NULL
BEGIN   
	 print 'INSERT'
	INSERT INTO ChapterMaster 
		   (ChapterName, SubjectId)
	Values(@ChapterName, @SubjectId)

	SET @ID = @@IDENTITY
	--SET @CompanyId  = @ID

END
ELSE
BEGIN
	print 'UPDATE'
	UPDATE ChapterMaster
	SET ChapterName=@ChapterName, SubjectId=@SubjectId
	Where ID=@ID
END
	COMMIT TRAN
 END TRY 

 BEGIN CATCH
	ROLLBACK TRAN
	SELECT ERROR_MESSAGE() AS ErrorMessage;  
 END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[stpSaveClassMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- exec stpSaveClassMaster 17,'test ok2'
CREATE procedure [dbo].[stpSaveClassMaster] 
( 
@ID int,
@ClassName varchar(500)
) 
AS 
BEGIN 
--DECLARE @FleetID int
 BEGIN TRY
    BEGIN TRAN
 IF @ID IS NULL
BEGIN   
	 print 'INSERT'
	INSERT INTO ClassMaster 
		   (ClassName)
	Values(@ClassName)

	SET @ID = @@IDENTITY
	--SET @CompanyId  = @ID

END
ELSE
BEGIN
	print 'UPDATE'
	UPDATE ClassMaster
	SET ClassName=@ClassName
	Where ID=@ID
END
	COMMIT TRAN
 END TRY 

 BEGIN CATCH
	ROLLBACK TRAN
	SELECT ERROR_MESSAGE() AS ErrorMessage;  
 END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[stpSaveStateMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- exec stpSaveStateMaster 17,'test ok2'
create procedure [dbo].[stpSaveStateMaster] 
( 
@ID int,
@State varchar(100)
) 
AS 
BEGIN 
--DECLARE @FleetID int
 BEGIN TRY
    BEGIN TRAN
 IF @ID IS NULL
BEGIN   
	 print 'INSERT'
	INSERT INTO StateMaster 
		   ([State])
	Values(@State)

	SET @ID = @@IDENTITY
	--SET @CompanyId  = @ID

END
ELSE
BEGIN
	print 'UPDATE'
	UPDATE StateMaster
	SET [State]= @State
	Where ID=@ID
END
	COMMIT TRAN
 END TRY 

 BEGIN CATCH
	ROLLBACK TRAN
	SELECT ERROR_MESSAGE() AS ErrorMessage;  
 END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[stpSaveUpdateChapterMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[stpSaveUpdateStudentDetails]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec stpSaveUpdateStudentDetails null,1,1,1,1,'P.Paul','9903263880'
create PROCEDURE [dbo].[stpSaveUpdateStudentDetails]
(
@ID INT,
@StudentId INT,
@StateId int,
@DistrictId int,
@ClassId int,
@GuardiansName VARCHAR(500),
@GuardiansMob VARCHAR(500)
)
AS
BEGIN
	BEGIN TRY
		BEGIN TRAN	
			IF @ID IS NULL 
			BEGIN
					INSERT INTO StudentDetails (StudentId, StateId, DistrictId, ClassId, GuardiansName, GuardiansMob)
					VALUES (@StudentId, @StateId, @DistrictId, @ClassId, @GuardiansName, @GuardiansMob)
					SET @ID=@@IDENTITY
				END
			ELSE
				BEGIN
					UPDATE StudentDetails SET StudentId=@StudentId, StateId=@StateId, DistrictId=@DistrictId,
					                          ClassId=@ClassId, GuardiansName=@GuardiansName, GuardiansMob=@GuardiansMob  
				WHERE ID=@ID
				END		
		COMMIT TRAN
	END TRY
	BEGIN CATCH 
		ROLLBACK TRAN
		SELECT ERROR_MESSAGE() AS ErrorMessage;
	END CATCH
END


GO
/****** Object:  StoredProcedure [dbo].[stpSaveUpdateSubjectMaster]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  StoredProcedure [dbo].[usp_GetClassMasterForDrp]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec usp_GetClassMasterForDrp
create PROCEDURE [dbo].[usp_GetClassMasterForDrp]
AS
BEGIN 
	SELECT ID, ClassName
	FROM ClassMaster 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetDistrictMasterForDrp]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec usp_GetDistrictMasterForDrp
create PROCEDURE [dbo].[usp_GetDistrictMasterForDrp]
AS
BEGIN 
	SELECT ID, District
	FROM DistrictMaster 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetStateMasterForDrp]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec usp_GetStateMasterForDrp
create PROCEDURE [dbo].[usp_GetStateMasterForDrp]
AS
BEGIN 
	SELECT ID, [State]
	FROM StateMaster 
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetStudentForDrp]    Script Date: 29/04/2020 1:37:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec usp_GetStudentForDrp
create PROCEDURE [dbo].[usp_GetStudentForDrp]
AS
BEGIN 
	SELECT ID, Name
	FROM Student 
END
GO
