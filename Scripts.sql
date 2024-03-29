USE [ProjectDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/20/2019 1:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CatId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 12/20/2019 1:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evaluation](
	[EvalId] [int] IDENTITY(1,1) NOT NULL,
	[totalMarks] [float] NOT NULL,
	[obtainedMarks] [float] NOT NULL,
	[GId] [int] NOT NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED 
(
	[EvalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 12/20/2019 1:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[pid] [int] IDENTITY(1,1) NOT NULL,
	[pname] [varchar](50) NOT NULL,
	[contact] [varchar](50) NOT NULL,
	[regNum] [varchar](50) NULL,
	[degree] [varchar](50) NULL,
	[designation] [varchar](50) NULL,
	[rank] [varchar](50) NULL,
	[CatId] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 12/20/2019 1:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](50) NOT NULL,
	[pid] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectGroup]    Script Date: 12/20/2019 1:02:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectGroup](
	[GId] [int] IDENTITY(1,1) NOT NULL,
	[GNum] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[s1] [varchar](50) NOT NULL,
	[s2] [varchar](50) NULL,
	[s3] [varchar](50) NULL,
	[s4] [varchar](50) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[GId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CatId], [name]) VALUES (1, N'Advisor')
INSERT [dbo].[Category] ([CatId], [name]) VALUES (2, N'Student')
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Evaluation] ON 

INSERT [dbo].[Evaluation] ([EvalId], [totalMarks], [obtainedMarks], [GId]) VALUES (1, 100, 99, 11)
SET IDENTITY_INSERT [dbo].[Evaluation] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([pid], [pname], [contact], [regNum], [degree], [designation], [rank], [CatId]) VALUES (3, N'Samyan Wahla', N'0324426611', NULL, NULL, N'20', N'Professor ', 1)
INSERT [dbo].[Person] ([pid], [pname], [contact], [regNum], [degree], [designation], [rank], [CatId]) VALUES (4, N'Samyan Wahla', N'123456', NULL, NULL, N'18', N'Assistant Professor ', 1)
INSERT [dbo].[Person] ([pid], [pname], [contact], [regNum], [degree], [designation], [rank], [CatId]) VALUES (6, N'Maryam Khalid', N'0324426611', N'2017-CS-266', N'BSCS', NULL, NULL, 2)
INSERT [dbo].[Person] ([pid], [pname], [contact], [regNum], [degree], [designation], [rank], [CatId]) VALUES (7, N'Mahnoor ', N'0324426611', N'2017-CS-267', N'BSCS', NULL, NULL, 2)
INSERT [dbo].[Person] ([pid], [pname], [contact], [regNum], [degree], [designation], [rank], [CatId]) VALUES (8, N'Ahmad Awais', N'0324426611', NULL, NULL, N'20', N'Professor ', 1)
INSERT [dbo].[Person] ([pid], [pname], [contact], [regNum], [degree], [designation], [rank], [CatId]) VALUES (9, N'Ali', N'0324426611', NULL, NULL, N'18', N'Assistant Professor ', 1)
INSERT [dbo].[Person] ([pid], [pname], [contact], [regNum], [degree], [designation], [rank], [CatId]) VALUES (10, N'Laiba', N'03244266831', NULL, NULL, N'20', N'Professor ', 1)
INSERT [dbo].[Person] ([pid], [pname], [contact], [regNum], [degree], [designation], [rank], [CatId]) VALUES (11, N'Maleeha Khalid ', N'03244266831', NULL, NULL, N'18', N'Assistant Professor ', 1)
INSERT [dbo].[Person] ([pid], [pname], [contact], [regNum], [degree], [designation], [rank], [CatId]) VALUES (14, N'Laiba', N'0324426611', NULL, NULL, N'18', N'Assistant Professor ', 1)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([ProjectId], [name], [description], [pid]) VALUES (3, N'Visualization', N'Visualization of algorithms', 4)
INSERT [dbo].[Project] ([ProjectId], [name], [description], [pid]) VALUES (4, N'Project Management', N'Manage Projects', 8)
INSERT [dbo].[Project] ([ProjectId], [name], [description], [pid]) VALUES (5, N'Maleeha Khalid ', N'Visualization of algorithms', 3)
INSERT [dbo].[Project] ([ProjectId], [name], [description], [pid]) VALUES (6, N'Library', N'Manage Projects', 9)
INSERT [dbo].[Project] ([ProjectId], [name], [description], [pid]) VALUES (7, N'Pleasee', N'o la la', 11)
SET IDENTITY_INSERT [dbo].[Project] OFF
SET IDENTITY_INSERT [dbo].[ProjectGroup] ON 

INSERT [dbo].[ProjectGroup] ([GId], [GNum], [ProjectId], [s1], [s2], [s3], [s4]) VALUES (11, 13, 4, N'Maryam Khalid', N'Mahnoor ', N'', N'')
INSERT [dbo].[ProjectGroup] ([GId], [GNum], [ProjectId], [s1], [s2], [s3], [s4]) VALUES (12, 7, 4, N'Maryam Khalid', N'Mahnoor ', N'', N'')
INSERT [dbo].[ProjectGroup] ([GId], [GNum], [ProjectId], [s1], [s2], [s3], [s4]) VALUES (13, 9, 4, N'Mahnoor ', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[ProjectGroup] OFF
ALTER TABLE [dbo].[Evaluation]  WITH CHECK ADD  CONSTRAINT [FK_Evaluation_ProjectGroup] FOREIGN KEY([GId])
REFERENCES [dbo].[ProjectGroup] ([GId])
GO
ALTER TABLE [dbo].[Evaluation] CHECK CONSTRAINT [FK_Evaluation_ProjectGroup]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Category] FOREIGN KEY([CatId])
REFERENCES [dbo].[Category] ([CatId])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Category]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_Person] FOREIGN KEY([pid])
REFERENCES [dbo].[Person] ([pid])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_Person]
GO
ALTER TABLE [dbo].[ProjectGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGroup_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[ProjectGroup] CHECK CONSTRAINT [FK_ProjectGroup_Project]
GO
