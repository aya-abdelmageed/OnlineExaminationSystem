-- Exam
-- insertion
GO
CREATE PROC EXAM_INSERTION 
    @Instructor_id INT, 
    @Crs_id INT, 
    @Exam_Date DATE, 
    @Start_Time TIME, 
    @End_Time TIME, 
    @TF_NUM INT, 
    @MCQ_NUM INT,
    @Max_marks INT = NULL,
	@New_Exam_ID INT OUTPUT
WITH ENCRYPTION
AS
BEGIN
BEGIN TRY
    EXEC CheckRecordExists 'instructor',@Instructor_id,'ins_id'
	EXEC CheckRecordExists 'COURSE',@Crs_id,'COURSE_ID'
    INSERT INTO EXAM (Ins_ID, Course_ID, Exam_Date, StartTime, EndTime, No_TF, No_MCQ, Max_Marks)
    VALUES (@Instructor_id, @Crs_id, @Exam_Date, @Start_Time, @End_Time, @TF_NUM, @MCQ_NUM, @Max_marks)
    SET @New_Exam_ID = SCOPE_IDENTITY();
END TRY
BEGIN CATCH
DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT  @ErrorMessage = ERROR_MESSAGE()
        RAISERROR (@ErrorMessage,1,16);
END CATCH
END
-- Selection 
GO
CREATE PROC EXAM_SELECTION 
    @Exam_id INT = NULL
WITH ENCRYPTION 
AS
BEGIN
BEGIN TRY
   EXEC CheckRecordExists 'Exam', @Exam_ID, 'EXAM_ID';
   IF @Exam_id IS NULL
      SELECT * FROM Exam
    ELSE
	  SELECT * FROM EXAM WHERE EXAM.Exam_ID = @Exam_id
END TRY
BEGIN CATCH
 DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT  @ErrorMessage = ERROR_MESSAGE()
        RAISERROR (@ErrorMessage,1,16);
END CATCH
END
GO
-- TEST INSERTION
declare @res int 
EXEC EXAM_INSERTION
    @Instructor_id = 101, 
    @Crs_id = 1, 
    @Exam_Date = '2025-02-01', 
    @Start_Time = '10:00', 
    @End_Time = '12:00', 
    @TF_NUM = 5, 
    @MCQ_NUM = 10, 
    @Max_marks = 100,
	@New_Exam_ID = @res OUTPUT;

-- TEST SELECTION
EXEC EXAM_SELECTION @EXAM_ID = 3

-- UPDATE
GO
CREATE PROC EXAM_UPDATE 
    @Exam_ID INT, 
    @Instructor_id INT = NULL, 
    @Crs_id INT = NULL, 
    @Exam_Date DATE = NULL, 
    @Start_Time TIME = NULL, 
    @End_Time TIME = NULL, 
    @TF_NUM INT = NULL, 
    @MCQ_NUM INT = NULL,
    @Max_marks INT = NULL
WITH ENCRYPTION
AS
BEGIN
    BEGIN TRY
        EXEC CheckRecordExists 'Exam', @Exam_ID, 'EXAM_ID';
        
        IF @Instructor_id IS NOT NULL
            EXEC CheckRecordExists 'Instructor', @Instructor_id, 'INS_ID';
        
        IF @Crs_id IS NOT NULL
            EXEC CheckRecordExists 'Course', @Crs_id, 'COURSE_ID';

        UPDATE EXAM
        SET
            Ins_ID = COALESCE(@Instructor_id, Ins_ID),
            Course_ID = COALESCE(@Crs_id, Course_ID),
            Exam_Date = COALESCE(@Exam_Date, Exam_Date),
            StartTime = COALESCE(@Start_Time, StartTime),
            EndTime = COALESCE(@End_Time, EndTime),
            No_TF = COALESCE(@TF_NUM, No_TF),
            No_MCQ = COALESCE(@MCQ_NUM, No_MCQ),
            Max_Marks = COALESCE(@Max_marks, Max_Marks)
        WHERE Exam_ID = @Exam_ID;
    END TRY
    BEGIN CATCH
       DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT  @ErrorMessage = ERROR_MESSAGE()
        RAISERROR (@ErrorMessage,1,16);
    END CATCH
END


-- DELETE 
GO
CREATE PROC EXAM_DELETION @EXAM_ID INT 
WITH ENCRYPTION
AS
BEGIN
BEGIN TRY
    EXEC CheckRecordExists 'Exam', @Exam_ID, 'EXAM_ID';
    DELETE FROM EXAM WHERE Exam_ID = @Exam_ID
END TRY
BEGIN CATCH
 DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT  @ErrorMessage = ERROR_MESSAGE()
        RAISERROR (@ErrorMessage,1,16);
END CATCH
END
-- TEST UPDATE 

EXEC EXAM_UPDATE @EXAM_ID = 4 ,@Instructor_id = 5

-- TEST DELETE

EXEC EXAM_INSERTION 
    @Instructor_id = 1, 
    @Crs_id = 1, 
    @Exam_Date = '2025-02-01', 
    @Start_Time = '10:00', 
    @End_Time = '12:00', 
    @TF_NUM = 5, 
    @MCQ_NUM = 10, 
    @Max_marks = 100;

EXEC EXAM_DELETION @EXAM_ID = 8

SELECT * FROM EXAM
--------------------------------------------------------------------------------------------------------
-- EXAM QUESTIONS TABLE
-- inxsertion
GO
GO
CREATE PROC EXAM_QUESTIONS_INSERTION 
    @EXAM_ID INT, 
    @QUESTION_ID INT, 
    @POINTS_EDIT INT = NULL
WITH ENCRYPTION
AS
BEGIN
BEGIN TRY
    -- Use CheckRecordExists
    EXEC CheckRecordExists 'Exam', @EXAM_ID, 'Exam_ID';
    EXEC CheckRecordExists 'Questions', @QUESTION_ID, 'Question_ID';

    INSERT INTO Exam_Questions (Exam_ID, Question_ID, Points_Edit)
    VALUES(@EXAM_ID, @QUESTION_ID, @POINTS_EDIT);
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    SELECT @ErrorMessage = ERROR_MESSAGE();
    RAISERROR (@ErrorMessage, 1, 16);
END CATCH
END;
GO

-- selection 
GO
CREATE PROC Exam_QUESTIONS_SELECTION 
    @Exam_id INT
WITH ENCRYPTION 
AS
BEGIN
BEGIN TRY
    EXEC CheckRecordExists 'Exam', @Exam_id, 'Exam_ID'
	SELECT * FROM Exam_Questions WHERE Exam_Questions.Exam_ID = @Exam_id
END TRY
BEGIN CATCH
 DECLARE @ErrorMessage NVARCHAR(4000);
    SELECT @ErrorMessage = ERROR_MESSAGE();
    RAISERROR (@ErrorMessage, 1, 16);
END CATCH
END
GO
-- update 
GO
CREATE PROC EXAM_QUESTIONS_UPDATE 
    @EXAM_ID INT, 
    @Q_ID INT, 
    @POINTS_EDIT INT
WITH ENCRYPTION
AS
BEGIN
    BEGIN TRY
        EXEC CheckRecordExists 'Exam', @EXAM_ID, 'EXAM_ID';

        EXEC CheckRecordExists 'Question', @Q_ID, 'QUESTION_ID';

        IF EXISTS (SELECT 1 FROM Exam_Questions WHERE Exam_ID = @EXAM_ID AND Question_ID = @Q_ID)
        BEGIN
            UPDATE Exam_Questions
            SET Points_Edit = @POINTS_EDIT
            WHERE Exam_ID = @EXAM_ID AND Question_ID = @Q_ID;
        END
        ELSE
        BEGIN
            RAISERROR ('Invalid Exam_ID or Question_ID association.', 16, 1);
        END
    END TRY
    BEGIN CATCH
     DECLARE @ErrorMessage NVARCHAR(4000);
       SELECT @ErrorMessage = ERROR_MESSAGE();
       RAISERROR (@ErrorMessage, 1, 16);
    END CATCH
END

-- DELETION
GO
CREATE PROC EXAM_QUESTION_DELETION 
    @E_ID INT, 
    @Q_ID INT
WITH ENCRYPTION
AS
BEGIN
    BEGIN TRY
        EXEC CheckRecordExists 'Exam', @E_ID, 'EXAM_ID';

        EXEC CheckRecordExists 'Question', @Q_ID, 'QUESTION_ID';

        IF EXISTS (SELECT 1 FROM Exam_Questions WHERE Exam_ID = @E_ID AND Question_ID = @Q_ID)
        BEGIN
            DELETE FROM Exam_Questions 
            WHERE Exam_ID = @E_ID AND Question_ID = @Q_ID;
        END
        ELSE
        BEGIN
            RAISERROR ('Invalid Exam_ID or Question_ID association.', 16, 1);
        END
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT 
            @ErrorMessage = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage,1,16);
    END CATCH
END


-- TEST
-- INSERTION 
EXEC EXAM_QUESTIONS_INSERTION @EXAM_ID = 3, @QUESTION_ID = 8, @POINTS_EDIT =5

SELECT * FROM Exam_Questions

-- SELECTION
EXEC EXAM_QUESTIONS_SELECTION @EXAM_ID = 3

-- UPDATE
EXEC EXAM_QUESTIONS_UPDATE @EXAM_ID = 3, @Q_ID = 84, @POINTS_EDIT = 5

--DELETION 
EXEC EXAM_QUESTION_DELETION @E_ID = 3, @Q_ID = 8

----------------------------------------------------------------------------------------------
-- STUDENT EXAM
-- INSERTION
GO
CREATE PROC STUDENT_EXAM_INSERTION 
    @Student_ID INT, 
    @Exam_ID INT
WITH ENCRYPTION
AS
BEGIN
    BEGIN TRY
        EXEC CheckRecordExists 'Student', @Student_ID, 'STUDENT_ID';

        EXEC CheckRecordExists 'Exam', @Exam_ID, 'EXAM_ID';

        DECLARE @Grade INT;
        SELECT @Grade = SUM(Score)
        FROM Exam_Question_Student
        WHERE Student_ID = @Student_ID AND Exam_ID = @Exam_ID;

        IF @Grade IS NULL
        BEGIN
            SET @Grade = 0;
        END
        INSERT INTO Student_Exam (Student_ID, Exam_ID, Grade)
        VALUES (@Student_ID, @Exam_ID, @Grade);
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT 
            @ErrorMessage = ERROR_MESSAGE();
        RAISERROR (@ErrorMessage, 1 , 16);
    END CATCH
END;
GO


-- SELECTION
CREATE PROC STUDENT_EXAM_SELECTION 
    @Student_ID INT = NULL, 
    @Exam_ID INT = NULL
WITH ENCRYPTION
AS
BEGIN
    BEGIN TRY
        IF @Student_ID IS NOT NULL
        BEGIN
            EXEC CheckRecordExists 'Student', @Student_ID, 'STUDENT_ID';
        END

        IF @Exam_ID IS NOT NULL
        BEGIN
            EXEC CheckRecordExists 'Exam', @Exam_ID, 'EXAM_ID';
        END

        SELECT Student_ID, Exam_ID, Grade
        FROM Student_Exam
        WHERE 
            (@Student_ID IS NULL OR Student_ID = @Student_ID)
            AND (@Exam_ID IS NULL OR Exam_ID = @Exam_ID);
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT 
            @ErrorMessage = ERROR_MESSAGE();

        RAISERROR (@ErrorMessage, 1 , 16);
    END CATCH
END;
GO


-- UPDATE 
GO
CREATE PROC STUDENT_EXAM_UPDATE 
    @Student_ID INT, 
    @Exam_ID INT, 
    @Grade INT
WITH ENCRYPTION
AS
BEGIN
    BEGIN TRY
        EXEC CheckRecordExists 'Student', @Student_ID, 'STUDENT_ID';

        EXEC CheckRecordExists 'Exam', @Exam_ID, 'EXAM_ID';

        IF NOT EXISTS (
            SELECT 1 
            FROM Student_Exam 
            WHERE Student_ID = @Student_ID AND Exam_ID = @Exam_ID
        )
        BEGIN
            RAISERROR('No matching record found in Student_Exam for the given Student_ID and Exam_ID.', 16, 1);
            RETURN;
        END

        UPDATE Student_Exam
        SET Grade = @Grade
        WHERE Student_ID = @Student_ID AND Exam_ID = @Exam_ID;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT 
            @ErrorMessage = ERROR_MESSAGE();

        RAISERROR (@ErrorMessage, 1 , 16);
    END CATCH
END;
GO

-- DELETION
CREATE PROC STUDENT_EXAM_DELETION 
    @Student_ID INT, 
    @Exam_ID INT
AS
BEGIN
BEGIN TRY
        EXEC CheckRecordExists 'Student', @Student_ID, 'STUDENT_ID';

        EXEC CheckRecordExists 'Exam', @Exam_ID, 'EXAM_ID';

        IF EXISTS (
            SELECT 1 
            FROM Student_Exam 
            WHERE Student_ID = @Student_ID AND Exam_ID = @Exam_ID
        )
		BEGIN 
                DELETE FROM Student_Exam
                WHERE Student_ID = @Student_ID AND Exam_ID = @Exam_ID;
		END
		ELSE
		  RAISERROR('NOT FOUND TO DELETE',16,1);
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT 
            @ErrorMessage = ERROR_MESSAGE();

        RAISERROR (@ErrorMessage, 1 , 16);
END CATCH
END;
GO

-- TEST
-- INSERTION

EXEC STUDENT_EXAM_INSERTION @Student_ID = 1, @Exam_ID = 2

-- SELECTION
EXEC STUDENT_EXAM_SELECTION @STUDENT_ID = 1, @Exam_ID = 2

-- DELETION
EXEC STUDENT_EXAM_DELETION @STUDENT_ID = 1, @Exam_ID = 2

-- UPDATE
EXEC STUDENT_EXAM_UPDATE @STUDENT_ID = 1, @Exam_ID = 2, @GRADE = 40



----------------------------------------------------------------------------------------------------
-- EXAM TRACK 
-- INSERTION

GO
CREATE PROC EXAM_TRACK_INSERTION
    @T_ID INT,
    @E_ID INT
AS
BEGIN
BEGIN TRY
    EXEC CheckRecordExists 'EXAM', @E_ID, 'EXAM_ID';
	EXEC CheckRecordExists 'TRACK', @T_ID, 'TRACK_ID';
    IF NOT EXISTS (SELECT 1 
                   FROM Exam_Track 
                   WHERE Track_ID = @T_ID AND Exam_ID = @E_ID)
    BEGIN
        INSERT INTO Exam_Track (Track_ID, Exam_ID)
        VALUES (@T_ID, @E_ID);
    END
    ELSE
    BEGIN
        RAISERROR('Record already exists. Insertion failed.',16,1);
    END
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    SELECT @ErrorMessage = ERROR_MESSAGE();
    RAISERROR (@ErrorMessage, 1, 16);
END CATCH
END;
GO

-- SELECTION
GO
CREATE PROC EXAM_TRACK_SELECTION
    @T_ID INT = NULL, 
    @E_ID INT = NULL
WITH ENCRYPTION
AS
BEGIN
BEGIN TRY
    EXEC CheckRecordExists 'TRACK', @T_ID, 'TRACK_ID';
	EXEC CheckRecordExists 'EXAM', @E_ID, 'EXAM_ID';
    SELECT 
        Track_ID, 
        Exam_ID
    FROM 
        Exam_Track
    WHERE 
        (@T_ID IS NULL OR Track_ID = @T_ID) 
        AND (@E_ID IS NULL OR Exam_ID = @E_ID);
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000);
    SELECT @ErrorMessage = ERROR_MESSAGE();
    RAISERROR (@ErrorMessage, 1, 16);
END CATCH
END;
GO

-- UPDATE 
CREATE PROC EXAM_TRACK_UPDATE
    @T_ID INT, 
    @E_ID INT,
	@NEW_E_ID INT
AS
BEGIN
BEGIN TRY
    EXEC CheckRecordExists 'TRACK', @T_ID, 'TRACK_ID';
    EXEC CheckRecordExists 'EXAM', @E_ID, 'EXAM_ID';
    IF EXISTS (SELECT 1 
               FROM Exam_Track 
               WHERE Track_ID = @T_ID AND Exam_ID = @E_ID)
    BEGIN
     IF EXISTS (SELECT 1 
                   FROM Exam_Track 
                   WHERE Track_ID = @T_ID AND Exam_ID = @NEW_E_ID)
        BEGIN
            RAISERROR('Update failed: A record with the new Exam_ID already exists for the given Track_ID.',16,1);
        END
        ELSE
        BEGIN
            UPDATE Exam_Track
            SET Exam_ID = @NEW_E_ID
            WHERE Track_ID = @T_ID AND Exam_ID = @E_ID;
			SELECT 'Record successfully updated.';
        END
    END
    ELSE
    BEGIN
        RAISERROR('Update failed: Record not found.',16,1);
    END
END TRY
BEGIN CATCH
DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        
        RAISERROR (@ErrorMessage, 16, 1);
END CATCH
END;
GO

-- DELETE 
CREATE PROC EXAM_TRACK_DELETION
    @T_ID INT,
    @E_ID INT
AS
BEGIN
BEGIN TRY
    EXEC CheckRecordExists 'TRACK', @T_ID, 'TRACK_ID';
	EXEC CheckRecordExists 'EXAM', @E_ID, 'EXAM_ID';
  
    IF EXISTS (SELECT 1 
               FROM Exam_Track 
               WHERE Track_ID = @T_ID AND Exam_ID = @E_ID)
    BEGIN
        DELETE FROM Exam_Track
        WHERE Track_ID = @T_ID AND Exam_ID = @E_ID;
    END
    ELSE
    BEGIN
        RAISERROR('Record not found. Deletion failed.',16,1);
    END
END TRY
BEGIN CATCH
   DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
END CATCH
END;
GO
-- TEST
-- INSERTION
EXEC EXAM_TRACK_INSERTION @T_ID = 1, @E_ID = 3;

-- SELECTION
EXEC EXAM_TRACK_SELECTION @T_ID = 1 ;

-- UPDATE
EXEC EXAM_TRACK_UPDATE @T_ID = 1, @E_ID = 5, @NEW_E_ID = 2;

-- DELETION
EXEC EXAM_TRACK_DELETION @T_ID = 1, @E_ID = 3;


----------------------------------------------------------------------------------------------------
-- EXAM_QUESTION_STUDENT
-- INSERTION 
GO
CREATE PROC EXAM_QUESTION_STUDENT_INSERTION 
    @S_ID INT,
    @E_ID INT,
    @Q_ID INT,
    @ANS INT = NULL
WITH ENCRYPTION
AS 
BEGIN
    BEGIN TRY
        EXEC CheckRecordExists 'Student', @S_ID, 'Student_ID';

        EXEC CheckRecordExists 'Exam', @E_ID, 'Exam_ID';

        EXEC CheckRecordExists 'Questions', @Q_ID, 'Question_ID';

        DECLARE @Correct_Ans INT;
        DECLARE @Score INT = 0; -- Default score is 0

        IF (@ANS IS NOT NULL)
        BEGIN
            SELECT @Correct_Ans = Q.Correct_Ans
            FROM Questions Q
            WHERE Q.Question_ID = @Q_ID;

            IF (@Correct_Ans = @ANS)
            BEGIN
                SELECT @Score = Q.Points
                FROM Questions Q
                WHERE Q.Question_ID = @Q_ID;
            END
        END

        INSERT INTO Exam_Question_Student (Student_ID, Exam_ID, Question_ID, Answer, Score)
        VALUES (@S_ID, @E_ID, @Q_ID, @ANS, @Score);
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO
-- SELECTION
CREATE PROC EXAM_QUESTION_STUDENT_SELECTION
    @S_ID INT = NULL,
    @E_ID INT = NULL,
    @Q_ID INT = NULL
AS
BEGIN
    BEGIN TRY
        IF @S_ID IS NOT NULL
        BEGIN
            EXEC CheckRecordExists 'Student', @S_ID, 'Student_ID';
        END

        IF @E_ID IS NOT NULL
        BEGIN
            EXEC CheckRecordExists 'Exam', @E_ID, 'Exam_ID';
        END

        IF @Q_ID IS NOT NULL
        BEGIN
            EXEC CheckRecordExists 'Questions', @Q_ID, 'Question_ID';
        END

        SELECT 
            Student_ID, 
            Exam_ID, 
            Question_ID, 
            Answer, 
            Score
        FROM 
            Exam_Question_Student
        WHERE 
            (@S_ID IS NULL OR Student_ID = @S_ID)
            AND (@E_ID IS NULL OR Exam_ID = @E_ID)
            AND (@Q_ID IS NULL OR Question_ID = @Q_ID);
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO

-- UPDATE
GO
CREATE PROC EXAM_QUESTION_STUDENT_UPDATE
    @S_ID INT,
    @E_ID INT,
    @Q_ID INT,
    @ANS INT = NULL 
AS
BEGIN
BEGIN TRY 
    EXEC CheckRecordExists 'Student', @S_ID, 'Student_ID';
    EXEC CheckRecordExists 'Exam', @E_ID, 'Exam_ID';
    EXEC CheckRecordExists 'Question', @Q_ID, 'Question_ID';
    DECLARE @Correct_Ans INT;
    DECLARE @Points INT;

    IF EXISTS (SELECT 1 
               FROM Exam_Question_Student 
               WHERE Student_ID = @S_ID AND Exam_ID = @E_ID AND Question_ID = @Q_ID)
    BEGIN
        SELECT @Correct_Ans = Q.Correct_Ans, 
               @Points = Q.Points
        FROM Questions Q
        WHERE Q.Question_ID = @Q_ID;

        IF @ANS IS NOT NULL
        BEGIN
            DECLARE @NewScore INT;
            IF @ANS = @Correct_Ans
                SET @NewScore = @Points;
            ELSE
                SET @NewScore = 0;

            UPDATE Exam_Question_Student
            SET Answer = @ANS,
                Score = @NewScore
            WHERE Student_ID = @S_ID AND Exam_ID = @E_ID AND Question_ID = @Q_ID;
        END
        ELSE
        BEGIN
            RAISERROR('No new answer provided. No update to score or answer.',16,1);
        END
    END
    ELSE
    BEGIN
        RAISERROR('Invalid Student_ID, Exam_ID, or Question_ID. Update failed.',16,1);
    END
END TRY
BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
END CATCH
END;
GO

-- DELETE 
GO
CREATE PROC EXAM_QUESTION_STUDENT_DELETION
    @S_ID INT,
    @E_ID INT,
    @Q_ID INT
AS
BEGIN
BEGIN TRY
    EXEC CheckRecordExists 'Student', @S_ID, 'Student_ID';
    EXEC CheckRecordExists 'Exam', @E_ID, 'Exam_ID';
    EXEC CheckRecordExists 'Question', @Q_ID, 'Question_ID';
    IF EXISTS (SELECT 1 
               FROM Exam_Question_Student 
               WHERE Student_ID = @S_ID AND Exam_ID = @E_ID AND Question_ID = @Q_ID)
    BEGIN
        DELETE FROM Exam_Question_Student
        WHERE Student_ID = @S_ID AND Exam_ID = @E_ID AND Question_ID = @Q_ID;

        RAISERROR('Record successfully deleted.',16,1);
    END
    ELSE
    BEGIN
        RAISERROR('Record not found. Deletion failed.',16,1);
    END
END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO


-- TEST
-- INSERTION 
INSERT INTO Exam_Question_Student (Student_ID, Exam_ID, Question_ID, Answer)
VALUES (1, 1, 5, 4)    

-- SELECTION
EXEC EXAM_QUESTION_STUDENT_SELECTION @S_ID = 1

-- UPDATE 
EXEC EXAM_QUESTION_STUDENT_UPDATE @S_ID = 1, @E_ID = 1, @Q_ID = 1, @ANS = 2;

-- DELETION
EXEC EXAM_QUESTION_STUDENT_DELETION @S_ID = 1,@E_ID = 1,@Q_ID = 5
--------------------------------------------------------------------------------------------
-- Exam generation
GO
CREATE PROC EXAM_GENERATION @CRS_NAME VARCHAR(255),@TF_NUM INT,@MCQ_NUM INT,@DTE DATE,@ST TIME,@ET TIME,@INS_ID INT = NULL
WITH ENCRYPTION
AS
BEGIN
BEGIN TRY
   IF @INS_ID IS NOT NULL
        BEGIN
            EXEC CheckRecordExists 'Instructor', @INS_ID, 'Ins_ID';
        END
   DECLARE @Crs_ID INT;  
   IF EXISTS (SELECT * FROM Course WHERE @CRS_NAME = Course_Name)
   BEGIN
      SELECT @Crs_ID = Course_ID FROM Course WHERE Course_Name = @CRS_NAME;
	  DECLARE @Exam_ID INT;  
      EXEC EXAM_INSERTION @INS_ID, @Crs_ID, @DTE, @ST, @ET, @TF_NUM, @MCQ_NUM,@New_Exam_ID = @Exam_ID OUTPUT;
	  SELECT @Exam_ID
        DECLARE @TF_Questions TABLE (Question_ID INT);
		INSERT INTO @TF_Questions (Question_ID)
        SELECT TOP (@TF_NUM) Question_ID
        FROM Questions
        WHERE Type = 'TF' AND Course_ID = @Crs_ID
        ORDER BY NEWID();  

		 -- Insert selected True/False questions into Exam_Questions
        DECLARE @TF_QID INT;
        DECLARE TF_Cursor CURSOR FOR 
        SELECT Question_ID FROM @TF_Questions;
        OPEN TF_Cursor;
        FETCH NEXT FROM TF_Cursor INTO @TF_QID;
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Insert the question into Exam_Questions
            EXEC EXAM_QUESTIONS_INSERTION @Exam_ID, @TF_QID;
            FETCH NEXT FROM TF_Cursor INTO @TF_QID;
        END
        CLOSE TF_Cursor;
        DEALLOCATE TF_Cursor;
        -------------
		DECLARE @MCQ_QUESTIONS TABLE (Q_ID INT);
		INSERT INTO @MCQ_QUESTIONS (Q_ID)
		SELECT TOP (@MCQ_NUM) Question_ID
		FROM Questions
		WHERE TYPE = 'MCQ' AND Course_ID = @Crs_ID
		ORDER BY NEWID();

		-- CURSER
		DECLARE @MCQ_QID INT;
		DECLARE MCQ_CURSOR CURSOR FOR
		SELECT Q_ID FROM @MCQ_QUESTIONS;
		OPEN MCQ_CURSOR;
		FETCH NEXT FROM MCQ_CURSOR INTO @MCQ_QID;
		WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Insert the question into Exam_Questions
            EXEC EXAM_QUESTIONS_INSERTION @Exam_ID, @MCQ_QID;
            FETCH NEXT FROM MCQ_CURSOR INTO @MCQ_QID;
        END
        CLOSE MCQ_CURSOR;
        DEALLOCATE MCQ_CURSOR;
   END
END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END

-- TEST
EXEC EXAM_GENERATION @CRS_NAME = 'HTML & CSS',@TF_NUM = 0,@MCQ_NUM = 1,@DTE = '2025-02-01', @ST = '10:00', @ET = '12:00'
SELECT * FROM Exam_Questions
--------------------------------------------------------------------------------------------
--EXAM CORRECTION
GO
CREATE PROC EXAM_CORRECTION 
    @E_ID INT,
    @S_NAME VARCHAR(160)
WITH ENCRYPTION
AS
BEGIN
BEGIN TRY
    EXEC CheckRecordExists 'Exam', @E_ID, 'Exam_ID';
    DECLARE @S_ID INT;

    SELECT @S_ID = Student_ID 
    FROM Student 
    WHERE CONCAT(FNAME, ' ', MNAME, ' ', LNAME) = @S_NAME;

    IF @S_ID IS NULL
    BEGIN
        SELECT 'No student found with the provided name.';
        RETURN;
    END

    EXEC EXAM_QUESTION_STUDENT_SELECTION @S_ID, @E_ID;
	EXEC STUDENT_EXAM_INSERTION @S_ID,@E_ID;
	EXEC STUDENT_EXAM_SELECTION @S_ID,@E_ID;
END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        SELECT @ErrorMessage = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END;
GO

-- TEST
EXEC EXAM_CORRECTION @E_ID = 26,@S_NAME = 'Ahmed Ali Hassan';

--------------------------------------------------------------------------------------------
GO
CREATE PROCEDURE [dbo].[CheckRecordExists]
    @TableName NVARCHAR(128),     -- Table name input
    @value INT,                      --value input
    @ColumnName NVARCHAR(128)     -- Primary key column name (to handle different table structures)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);   -- To hold dynamic SQL
    DECLARE @Exists BIT;          -- To store existence check result

    -- Check if the record exists using the dynamic column name
    SET @SQL = N'SELECT @ExistsOut = CASE WHEN EXISTS (SELECT 1 FROM ' 
              + QUOTENAME(@TableName) 
              + N' WHERE ' + QUOTENAME(@ColumnName) + ' = @IdParam) THEN 1 ELSE 0 END';

    EXEC sp_executesql 
        @SQL,
        N'@IdParam INT, @ExistsOut BIT OUTPUT',
        @IdParam = @value,
        @ExistsOut = @Exists OUTPUT;

    -- If record does not exist, raise an error
    IF @Exists = 0
    BEGIN
        RAISERROR ('Record with value %d not found in table %s with column %s.', 16, 1, @value, @TableName, @ColumnName);
        RETURN;
    END

END
