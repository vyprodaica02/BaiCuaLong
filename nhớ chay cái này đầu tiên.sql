CREATE DATABASE QLSV
go
USE QLSV

CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE,
    Email NVARCHAR(100) UNIQUE
);
CREATE TABLE Courses (
    CourseId INT PRIMARY KEY IDENTITY,
    CourseName NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL
);
CREATE TABLE Enrollments (
    EnrollmentId INT PRIMARY KEY IDENTITY,
    StudentId INT FOREIGN KEY REFERENCES Students(StudentId),
    CourseId INT FOREIGN KEY REFERENCES Courses(CourseId),
    EnrollmentDate DATE NOT NULL,
    Grade INT -- Điểm số hoặc NULL nếu chưa có điểm
);


-- Chèn dữ liệu vào bảng Students
-- Cho bảng Students
SET IDENTITY_INSERT Students ON;

INSERT INTO Students (StudentId, FirstName, LastName, DateOfBirth, Email)
VALUES
    (1, 'John', 'Doe', '1990-01-15', 'john.doe@example.com'),
    (2, 'Jane', 'Smith', '1992-05-20', 'jane.smith@example.com'),
    (3, 'Bob', 'Johnson', '1988-09-08', 'bob.johnson@example.com');

SET IDENTITY_INSERT Students OFF;

-- Cho bảng Courses
SET IDENTITY_INSERT Courses ON;

INSERT INTO Courses (CourseId, CourseName, Credits)
VALUES
    (101, 'Introduction to Programming', 3),
    (102, 'Database Design', 4),
    (103, 'Web Development', 3);

SET IDENTITY_INSERT Courses OFF;

-- Cho bảng Enrollments
SET IDENTITY_INSERT Enrollments ON;

INSERT INTO Enrollments (EnrollmentId, StudentId, CourseId, EnrollmentDate, Grade)
VALUES
    (1, 1, 101, '2024-01-01', 85),
    (2, 2, 102, '2024-01-02', 90),
    (3, 3, 103, '2024-01-03', NULL);

SET IDENTITY_INSERT Enrollments OFF;

