use Online_Examination_System
-- Main File Group Tables
CREATE TABLE Branch (
    Branch_ID INT PRIMARY KEY IDENTITY(1,1),
    Branch_Name VARCHAR(255) NOT NULL,
    Phone VARCHAR(15),
    Location VARCHAR(255)
) ON Main;

CREATE TABLE Track (
    Track_ID INT PRIMARY KEY IDENTITY(1,1),
    Track_Name VARCHAR(255) NOT NULL,
    Department VARCHAR(255)
) ON Main;

CREATE TABLE Track_Branch (
    Track_ID INT,
    Branch_ID INT,
    PRIMARY KEY (Track_ID, Branch_ID),
    FOREIGN KEY ( Track_ID) REFERENCES Track( Track_ID),
    FOREIGN KEY (Branch_ID) REFERENCES Branch(Branch_ID)
) ON Main;

CREATE TABLE Course (
    Course_ID INT PRIMARY KEY IDENTITY(1,1),
    Course_Name VARCHAR(255) NOT NULL
) ON Main;

CREATE TABLE Topic (
    Topic_ID INT PRIMARY KEY IDENTITY(1,1),
    Topic_Name VARCHAR(255) NOT NULL,
    Course_ID INT NOT NULL,
    FOREIGN KEY (Course_ID) REFERENCES Course(Course_ID)
) ON Main;

CREATE TABLE Questions (
    Question_ID INT PRIMARY KEY IDENTITY(1,1),
    Correct_Ans INT,
    Question TEXT NOT NULL,
    Type VARCHAR(50),
    Points INT,
    Course_ID INT NOT NULL,
    FOREIGN KEY (Course_ID) REFERENCES Course(Course_ID)
) ON Main;

CREATE TABLE Questions_Choices (
    Question_ID INT,
	--Choice_ID INT PRIMARY KEY IDENTITY(1,1),
    Choice VARCHAR(500) NOT NULL,
	PRIMARY KEY (Question_ID, Choice),
    FOREIGN KEY (Question_ID) REFERENCES Questions(Question_ID)
) ON Main;

-- Student File Group Tables
CREATE TABLE Student (
    Student_ID INT PRIMARY KEY IDENTITY(1,1),
    Gender VARCHAR(1),
    FName VARCHAR(50) NOT NULL,
    MName VARCHAR(50),
    LName VARCHAR(50) NOT NULL,
    Phone VARCHAR(15),
    Birthdate DATE,
    Track_ID INT,
    FOREIGN KEY (Track_ID) REFERENCES Track(Track_ID)
) ON Student;

-- Instructor File Group Tables
CREATE TABLE Instructor (
    INS_ID INT PRIMARY KEY IDENTITY(1,1),
    FName VARCHAR(50) NOT NULL,
    MName VARCHAR(50),
    LName VARCHAR(50) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Gender VARCHAR(1) NOT NULL,
    Age INT,
    Salary DECIMAL(10, 2)
) ON Instructor;

CREATE TABLE Ins_Track_Course (
    Ins_ID INT,
    Track_ID INT,
    Course_ID INT,
    Course_Date DATE,
    PRIMARY KEY (Ins_ID, Track_ID, Course_ID),
    FOREIGN KEY (Ins_ID) REFERENCES Instructor(Ins_ID),
    FOREIGN KEY (Track_ID) REFERENCES Track(Track_ID),
    FOREIGN KEY (Course_ID) REFERENCES Course(Course_ID)
) ON Instructor;

-- Exam File Group Tables
CREATE TABLE Exam (
    Exam_ID INT PRIMARY KEY IDENTITY(1,1),
	Ins_ID INT,
	Course_ID INT,
    Exam_Date DATE NOT NULL,
    EndTime TIME NOT NULL,
    StartTime TIME NOT NULL,
    No_TF INT,
	No_MCQ INT,
    Max_Marks INT,
	FOREIGN KEY (Ins_ID) REFERENCES Instructor(Ins_ID),
	FOREIGN KEY (Course_ID) REFERENCES Course(Course_ID),
) ON Exam;

CREATE TABLE Exam_Questions (
    Exam_ID INT,
    Question_ID INT,
	Points_Edit INT,
    PRIMARY KEY (Exam_ID, Question_ID),
    FOREIGN KEY (Exam_ID) REFERENCES Exam(Exam_ID),
    FOREIGN KEY (Question_ID) REFERENCES Questions(Question_ID)
) ON Exam;

CREATE TABLE Exam_Question_Student (
    Student_ID INT,
    Exam_ID INT,
    Question_ID INT,
    Answer INT,
	Score INT,
    PRIMARY KEY (Student_ID, Exam_ID, Question_ID),
    FOREIGN KEY (Student_ID) REFERENCES Student(Student_ID),
    FOREIGN KEY (Exam_ID) REFERENCES Exam(Exam_ID),
    FOREIGN KEY (Question_ID) REFERENCES Questions(Question_ID)
) ON Exam;

CREATE TABLE STUDENT_EXAM
(
    Student_ID INT,
    Exam_ID INT,
	Grade INT,
	PRIMARY KEY(Student_ID,Exam_ID),
	FOREIGN KEY (Student_ID) REFERENCES Student(Student_ID),
    FOREIGN KEY (Exam_ID) REFERENCES Exam(Exam_ID)
) ON Exam

CREATE TABLE Exam_Track
(
     Track_ID INT,
	 Exam_ID INT,
	 PRIMARY KEY(Track_ID,Exam_ID),
     FOREIGN KEY (Track_ID) REFERENCES Track(Track_ID),
	 FOREIGN KEY (Exam_ID) REFERENCES Exam(Exam_ID)
) ON Exam