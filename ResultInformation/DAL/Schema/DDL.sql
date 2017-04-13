CREATE TABLE Person
(
[Id] [int] IDENTITY(1,1) NOT NULL,
FirstName NVARCHAR(500)  NOT NULL,
MiddleName NVARCHAR(500)  NOT NULL,
LastName NVARCHAR(500)  NOT NULL,
SystemId NVARCHAR(500) NULL,
RollNo NVARCHAR(500)   NULL,
ResistrationNo NVARCHAR(500)  NOT NULL,
CNIC NVARCHAR(500)  NOT NULL,
FatherId INT NULL,
CreateDate TimeStamp,
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id),
FOREIGN KEY (FatherId) REFERENCES Person(Id)
)

CREATE TABLE AwardingBody
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate TimeStamp,
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE Institute
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate TimeStamp,
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE AcademicLevel
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate TimeStamp,
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE Semester
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate TimeStamp,
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)

CREATE TABLE Shift
(
[Id] [int] IDENTITY(1,1) NOT NULL,
[Name] NVARCHAR(500)  NOT NULL,
CreateDate TimeStamp,
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
CreateDate TimeStamp,
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id)
)


CREATE TABLE AcademicSession
(
[Id] [int] IDENTITY(1,1) NOT NULL,
StartDate Date  NOT NULL,
EndDate Date  NOT NULL,
CreateDate TimeStamp,
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
CreateDate TimeStamp,
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
[AcademicLevelId] [int]  NOT NULL,
CreateDate TimeStamp,
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id),
FOREIGN KEY (AcademicLevelId) REFERENCES AcademicLevel(Id)
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
CreateDate TimeStamp,
EditDate   DateTime default(GetDate()),
PRIMARY KEY (Id),
FOREIGN KEY (StudentId) REFERENCES Person(Id),
FOREIGN KEY (CombinationId) REFERENCES Combination(Id),
FOREIGN KEY (AwardingBodyId) REFERENCES AwardingBody(Id),
FOREIGN KEY (InstituteId) REFERENCES Institute(Id),
)






