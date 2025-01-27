-- stored procedure:
USE Online_Examination_System;


-- Student:

SELECT * FROM Student
SELECT * FROM Track



/*
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
*/

--Insert
CREATE PROC STUDENT_INSERTION
@first_name VARCHAR(50), 
@middle_name VARCHAR(50), 
@last_name VARCHAR(50), 
@gender VARCHAR(1), 
@birthday DATE , 
@phone_num VARCHAR(15), 
@track_id INT 

WITH ENCRYPTION
AS
BEGIN

	IF EXISTS  (select Track_ID  from Track where Track_ID = @track_id)
	BEGIN
        INSERT INTO Student(FName, MName, LName, Gender, Birthdate, Phone, Track_ID)
        VALUES(@first_name, @middle_name, @last_name, @gender, @birthday, @phone_num, @track_id);
    END
    ELSE
    BEGIN
        SELECT 'Invalid Track ID';
    END
END;



-- SELECT

CREATE PROC STUDENT_SELECTION
@student_id int

WITH ENCRYPTION

AS
BEGIN
IF EXISTS (SELECT Student_ID FROM Student WHERE Student_ID = @student_id)
BEGIN
SELECT 
            Student_ID AS [Student ID],
            FName AS [First Name],
            MName AS [Middle Name],
            LName AS [Last Name],
            Gender AS [Gender],
            Birthdate AS [Date of Birth],
            Phone AS [Phone Number],
            Track_ID AS [Track]
        FROM Student
		WHERE Student_ID = @student_id;
END

ELSE
	SELECT 'Student ID does not exist'

	END

-- UPDATE

create proc STUDENT_UPDATE
@student_id int,
@first_name VARCHAR(50) = NULL , 
@middle_name VARCHAR(50) = NULL, 
@last_name VARCHAR(50) = NULL, 
@gender VARCHAR(1) = NULL, 
@birthday date = NULL, 
@phone_num VARCHAR(15) = NULL, 
@track_id int = NULL

WITH ENCRYPTION

AS
BEGIN
IF EXISTS(SELECT Student_ID FROM Student WHERE Student_ID = @student_id)
BEGIN
	IF @track_id IS NOT NULL AND NOT EXISTS (SELECT Track_ID FROM Track WHERE Track_ID = @track_id)
        BEGIN
            SELECT 'Invalid Track ID';
            RETURN;
        END

	UPDATE Student
	SET
	FName = COALESCE(@first_name, FName),
	MName = COALESCE(@middle_name, MName),
	LName = COALESCE(@last_name, LName),
	Gender = COALESCE(@gender, Gender),
	Birthdate = COALESCE(@birthday, Birthdate),
    Phone = COALESCE(@phone_num, Phone),
	Track_ID = COALESCE(@track_id, Track_ID)

	WHERE Student_ID = @student_id

END
ELSE
	SELECT 'Student ID does not exist'

END


-- DELETION

CREATE PROC STUDENT_DELETION
@student_id INT -- Mandatory parameter for deletion
WITH ENCRYPTION
AS
BEGIN
    -- Check if the Student_ID exists
    IF EXISTS (SELECT Student_ID FROM Student WHERE Student_ID = @student_id)
    BEGIN
        DELETE FROM Student
        WHERE Student_ID = @student_id;

    END
    ELSE
    BEGIN
        SELECT 'Student ID does not exist';
    END
END;



--TESTING :

--INSERTION

EXEC STUDENT_INSERTION 
    @first_name = 'John',
    @middle_name = 'Michael',
    @last_name = 'Doe',
    @gender = 'M',
    @birthday = '2000-05-15',
    @phone_num = '1234567890',
    @track_id = 1;


--SELECTION
EXEC STUDENT_SELECTION @student_id = 1;

EXEC STUDENT_SELECTION @student_id = 99; -- Non-existent ID


--UPDATE

EXEC STUDENT_UPDATE 
    @student_id = 11,
    @phone_num = '1112223333';

EXEC STUDENT_UPDATE 
    @student_id = 1,
    @track_id = 99; -- Invalid Track_ID


EXEC STUDENT_UPDATE 
    @student_id = 99,
    @phone_num = '4445556666';



--DELETION

EXEC STUDENT_DELETION @student_id = 11;

EXEC STUDENT_DELETION @student_id = 99;


