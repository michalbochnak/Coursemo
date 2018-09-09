--
-- Michal Bochnak
-- UIC, Project #4 Part I
-- August 11, 2018
-- Prof. Joe Hummel 
--
CREATE TABLE Student(
    SID         INT IDENTITY(1, 1) PRIMARY KEY,
    LastName    NVARCHAR(64) NOT NULL,
    FirstName   NVARCHAR(64) NOT NULL,
    Email       NVARCHAR(64) NOT NULL
);

CREATE TABLE Course(
    CID             INT IDENTITY (1, 1) PRIMARY KEY,
    Department      NVARCHAR(64) NOT NULL,
    CourseNumber    SMALLINT CHECK (CourseNumber >= 0) NOT NULL,
    Semester        NVARCHAR(10) NOT NULL,
    AcademicYear    SMALLINT CHECK (AcademicYear >= 0) NOT NULL,
    CRN             INT CHECK (CRN >= 0) NOT NULL,
    CourseType      NVARCHAR(10) NOT NULL,
    CourseDay       NVARCHAR(10) NOT NULL,
    CourseTime      NVARCHAR(20) NOT NULL,
    ClassSize       SMALLINT CHECK (ClassSize >= 0) NOT NULL
);

CREATE TABLE Registration(
    RID         INT IDENTITY(1, 1) PRIMARY KEY,
    SID         INT NOT NULL FOREIGN KEY REFERENCES Student(SID),
    CID         INT NOT NULL FOREIGN KEY REFERENCES Course(CID)
);

CREATE TABLE Waitlist(
    WID         INT IDENTITY (1, 1) PRIMARY KEY,
    SID         INT NOT NULL FOREIGN KEY REFERENCES Student(SID),
    CID         INT NOT NULL FOREIGN KEY REFERENCES Course(CID)
);




CREATE PROCEDURE RegisterStudent
    (@studentId INT, @courseId INT)
AS
    INSERT INTO Registration(SID, CID)
    VALUES((SELECT Student.SID FROM Student WHERE Student.SID = @studentId), 
            (SELECT Course.CID FROM Course WHERE Course.CID = @courseId));


CREATE PROCEDURE WaitlistStudent
    (@studentId INT, @courseId INT)
AS
    INSERT INTO Waitlist(SID, CID)
    VALUES((SELECT Student.SID FROM Student WHERE Student.SID = @studentId), 
            (SELECT Course.CID FROM Course WHERE Course.CID = @courseId));


CREATE PROCEDURE UnregisterStudent
    (@studentId INT, @courseId INT)
AS
    DELETE FROM Registration
    WHERE SID = @studentId 
    AND CID = @courseId;


CREATE PROCEDURE UnwaitlistStudent
    (@studentId INT, @courseId INT)
AS
    DELETE FROM Waitlist
    WHERE SID = @studentId 
    AND CID = @courseId;



