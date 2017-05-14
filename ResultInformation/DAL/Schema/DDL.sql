USE [Sims]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 5/15/2017 2:16:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nchar](100) NULL,
	[ProgramId] [int] NULL,
	[FirstName] [nvarchar](500) NOT NULL,
	[MiddleName] [nvarchar](500) NOT NULL,
	[LastName] [nvarchar](500) NOT NULL,
	[SystemId] [nvarchar](500) NULL,
	[RollNo] [nvarchar](500) NULL,
	[ResistrationNo] [nvarchar](500) NOT NULL,
	[CNIC] [nvarchar](500) NOT NULL,
	[FatherFirstName] [nvarchar](500) NULL,
	[FatherMiddleName] [nvarchar](500) NULL,
	[FatherLastName] [nvarchar](500) NULL,
	[FatherCNIC] [nvarchar](500) NULL,
 CONSTRAINT [PK__Student__3214EC070ABC5FFA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Program] FOREIGN KEY([ProgramId])
REFERENCES [dbo].[Program] ([Id])
GO

ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Program]
GO




CREATE TABLE AwardingBody
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE Institute
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE AcademicLevel
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE Semester
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE [dbo].[Program](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	PRIMARY KEY (Id)
) 

CREATE TABLE Shift
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE Course
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
Acro NVARCHAR(100)  NOT NULL,
CreditHours INT  NOT NULL,
LabCredits  NUMERIC  NOT NULL DEFAULT 0,
Code NVARCHAR(100)  NOT NULL,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)


CREATE TABLE Articles
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
[Summary] NVARCHAR(500)  NOT NULL,
[Contents] NTEXT  NOT NULL
)
CREATE TABLE AcademicSession
(
[Id] [int] IDENTITY(1,1) NOT NULL,
StartDate Date  NOT NULL,
EndDate Date  NOT NULL,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE Registration
(
[Id] [int] IDENTITY(1,1) NOT NULL,
CourseId INT , 
SessionId INT ,
ShiftId INT ,
SemesterId INT ,
StudentId INT ,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id),
FOREIGN KEY (CourseId) REFERENCES Course(Id),
FOREIGN KEY (SessionId) REFERENCES AcademicSession(Id),
FOREIGN KEY (ShiftId) REFERENCES Shift(Id),
FOREIGN KEY (SemesterId) REFERENCES Semester(Id),
FOREIGN KEY (StudentId) REFERENCES Person(Id)
)



CREATE TABLE Combination
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
--[AcademicLevelId] [int]  NOT NULL,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id),
--FOREIGN KEY (AcademicLevelId) REFERENCES AcademicLevel(Id)
)

CREATE TABLE AcademicHistory
(
[Id] [int] IDENTITY(1,1) NOT NULL,
Percentage int  check(Percentage between 0 and 101 ),
StartDate Date  NOT NULL,
EndDate Date  NOT NULL,
StudentId Int,
CombinationId int,
AwardingBodyId int,
InstituteId int,
AcademicLevelId int,
CreateDate DateTime default(GetDate()),
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id),
FOREIGN KEY (StudentId) REFERENCES Student(Id),
FOREIGN KEY (CombinationId) REFERENCES Combination(Id),
FOREIGN KEY (AwardingBodyId) REFERENCES AwardingBody(Id),
FOREIGN KEY (InstituteId) REFERENCES Institute(Id),
FOREIGN KEY (AcademicLevelId) REFERENCES AcademicLevel(Id),
)



CREATE TABLE Articles
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
[Summary] NVARCHAR(500)  NOT NULL,
[Contents] NTEXT  NOT NULL,
IsPublished  BIT   NULL   DEFAULT 0,
PRIMARY KEY (Id)
);


