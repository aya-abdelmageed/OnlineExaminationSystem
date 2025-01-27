-- QUESTION STORED PROCEDURE

USE Online_Examination_System;

/*
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

*/




---CHOICES STORED PROCEDURES

--CHOICE INSERTION

CREATE PROC CHOICE_INSERTION
@question_id INT,
@choice VARCHAR(500)
WITH ENCRYPTION
AS
BEGIN
    IF EXISTS (SELECT Question_ID FROM Questions WHERE Question_ID = @question_id)
    BEGIN
        INSERT INTO Questions_Choices (Question_ID, Choice)
        VALUES (@question_id, @choice);
    END
    ELSE
    BEGIN
        SELECT 'Invalid Question ID' AS ErrorMessage;
    END
END;


--SELECTION

CREATE PROC CHOICE_SELECTION
@question_id INT

WITH ENCRYPTION 
AS
BEGIN
IF EXISTS (SELECT Question_ID FROM Questions WHERE Question_ID = @question_id)
BEGIN 
SELECT Choice AS [QUESTION_CHOICE]
FROM Questions_Choices
WHERE Question_ID = @question_id;
END
ELSE
SELECT 'Question ID does not exist' AS ErrorMessage;
END;



--UPDATE

CREATE PROC CHOICE_UPDATE
@question_id INT,
@old_choice VARCHAR(500),
@new_choice VARCHAR(500)

WITH ENCRYPTION
AS
BEGIN
IF EXISTS(SELECT Question_ID FROM Questions WHERE Question_ID = @question_id)
BEGIN

UPDATE Questions_Choices
SET Choice = @new_choice
WHERE Question_ID = @question_id AND Choice = @old_choice
END
ELSE
SELECT 'Invalid Question ID' AS ErrorMessage;
END;




--DELETION

CREATE PROC CHOICE_DELETION
@question_id INT,
@choice VARCHAR(500)

WITH ENCRYPTION
AS
BEGIN
IF EXISTS (SELECT Question_ID FROM Questions WHERE Question_ID = @question_id)
BEGIN
DELETE FROM Questions_Choices
WHERE Question_ID = @question_id AND Choice = @choice;
END
ELSE
SELECT 'Invalid Question ID' AS ErrorMessage;
END;

CREATE PROC ALL_QUESTION_CHOICES_DELETION
@question_id INT
WITH ENCRYPTION
AS
BEGIN
    -- Check if the Question exists
    IF EXISTS (SELECT Question_ID FROM Questions WHERE Question_ID = @question_id)
    BEGIN
        -- Delete choices related to the question
        DELETE FROM Questions_Choices
        WHERE Question_ID = @question_id;
    END
    ELSE
    BEGIN
        -- If the question doesn't exist, return an error message
        SELECT 'Invalid Question ID' AS ErrorMessage;
    END
END;




--QUESTION STORED PROCEDURES

-- INSERTION

CREATE PROC QUESTION_INSERTION
@correct_ans INT,
@question TEXT,
@type VARCHAR(50),
@points INT,
@course_id INT
WITH ENCRYPTION
AS
BEGIN
    IF EXISTS (SELECT Course_ID FROM Course WHERE Course_ID = @course_id)
    BEGIN
        INSERT INTO Questions (Correct_Ans, Question, Type, Points, Course_ID)
        VALUES (@correct_ans, @question, @type, @points, @course_id);
		
		DECLARE @new_question_id INT;
        SET @new_question_id = SCOPE_IDENTITY();

        -- Return the new Question_ID
        SELECT @new_question_id AS [New Question ID];
	END
    ELSE
    BEGIN
        SELECT 'Invalid Course ID' ;
    END
END;


--SELECTION

CREATE PROC QUESTION_SELECTION
@question_id INT,
@course_id INT
WITH ENCRYPTION
AS
BEGIN
    -- Check if the question exists and if it belongs to the given course
    IF EXISTS(SELECT Question_ID FROM Questions WHERE Question_ID = @question_id AND Course_ID = @course_id)
    BEGIN
        -- Select question details along with the course ID
        SELECT 
            Question_ID AS [QUESTION ID],
            Question AS [QUESTION],
            Correct_Ans AS [ANSWER],
            Type AS [QUESTION_TYPE], 
            Points AS [QUESTION_POINTS],
            Course_ID AS [COURSE ID]
        FROM Questions
        WHERE Question_ID = @question_id AND Course_ID = @course_id;
    END
    ELSE
    BEGIN
        -- Return an error message if the question doesn't exist or doesn't belong to the course
        SELECT 'Invalid Question ID or Course ID' AS ErrorMessage;
    END
END;




--GET ALL QUESTION BASED ON COURSE ID

CREATE PROC ALL_COURSE_QUESTION_SELECTION
@course_id INT
WITH ENCRYPTION
AS
BEGIN
    IF EXISTS( SELECT Course_ID FROM Course WHERE Course_ID = @course_id)
    BEGIN
        SELECT 
		Question_ID AS [QUESTION ID],
		Question AS [QUESTION],
		Correct_Ans AS [ANSWER],
		Type AS [QUESTION_TYPE], 
		Points AS [QEUESTION_POINTS]
        FROM Questions
		WHERE Course_ID = @course_id
    END
	ELSE
    BEGIN
        SELECT 'Invalid Course ID' AS ErrorMessage;
    END
    
END;


--UPDATE

CREATE PROC QUESTION_UPDATE
@question_id INT,
@correct_ans INT = NULL,
@question TEXT = NULL,
@type VARCHAR(50) = NULL,
@points INT = NULL,
@course_id INT = NULL
WITH ENCRYPTION
AS
BEGIN
    IF EXISTS (SELECT Question_ID FROM Questions WHERE Question_ID = @question_id)
    BEGIN
        IF @course_id IS NOT NULL AND NOT EXISTS (SELECT Course_ID FROM Course WHERE Course_ID = @course_id)
        BEGIN
            SELECT 'Invalid Course ID' AS ErrorMessage;
            RETURN;
        END

        UPDATE Questions
        SET
            Correct_Ans = COALESCE(@correct_ans, Correct_Ans),
            Question = COALESCE(@question, Question),
            Type = COALESCE(@type, Type),
            Points = COALESCE(@points, Points),
            Course_ID = COALESCE(@course_id, Course_ID)
        WHERE Question_ID = @question_id;
    END
    ELSE
    BEGIN
        SELECT 'Question ID does not exist' AS ErrorMessage;
    END
END;



--DELETION

CREATE PROC QUESTION_DELETION
@question_id INT
WITH ENCRYPTION
AS
BEGIN
    IF EXISTS (SELECT Question_ID FROM Questions WHERE Question_ID = @question_id)
    BEGIN
		EXEC ALL_QUESTION_CHOICES_DELETION  @question_id;

        DELETE FROM Questions
        WHERE Question_ID = @question_id;
    END
    ELSE
    BEGIN
        SELECT 'Question ID does not exist'AS ErrorMessage;
    END
END;


--TEST

SELECT * FROM Questions WHERE Course_ID = 1

-- Test: Inserting a valid question into the system
EXEC QUESTION_INSERTION  --REMEMBER THE RETURNED QUESTION'S ID
    @correct_ans = 1, 
    @question = 'What is the capital of Egypt?', 
    @type = 'MCQ', 
    @points = 10, 
    @course_id = 1;


-- Test: Select a question by Question_ID
EXEC QUESTION_SELECTION 
    @question_id = 59; -- ADD THE RETURNED QUESTION ID HERE 


-- Test: Select all questions for a given course
EXEC ALL_COURSE_QUESTION_SELECTION 
    @course_id = 1;


-- Test: Update an existing question
EXEC QUESTION_UPDATE 
    @question_id = 60, -- ADD THE RETURNED QUESTION ID HERE 
    @correct_ans = 2, 
    @question = 'What is the capital of France?', 
    @type = 'MCQ', 
    @points = 15, 
    @course_id = 1;


-- Test: Delete a question
EXEC QUESTION_DELETION 
    @question_id = 60; -- ADD THE RETURNED QUESTION ID HERE 


-- Test: Insert a choice for a specific question
EXEC CHOICE_INSERTION 
    @question_id =60, -- ADD THE RETURNED QUESTION ID HERE 
    @choice = 'London';

-- Test: Select all choices for a specific question
EXEC CHOICE_SELECTION 
    @question_id = 60; -- ADD THE RETURNED QUESTION ID HERE 


-- Test: Update an existing choice for a specific question
EXEC CHOICE_UPDATE 
    @question_id = 59, -- ADD THE RETURNED QUESTION ID HERE 
    @old_choice = 'Paris', 
    @new_choice = 'London';


-- Test: Delete a specific choice for a question
EXEC CHOICE_DELETION 
    @question_id = 59, -- ADD THE RETURNED QUESTION ID HERE 
    @choice = 'London';


-- Test: Attempt to insert a question with an invalid Course_ID
EXEC QUESTION_INSERTION 
    @correct_ans = 1, 
    @question = 'What is the capital of Egypt?', 
    @type = 'MCQ', 
    @points = 10, 
    @course_id = 999; -- Invalid Course_ID


-- Test: Attempt to select a question with an invalid Question_ID
EXEC QUESTION_SELECTION 
    @question_id = 999, --INVALID Question_ID
	@COURSE_ID = 1 


-- Test: Attempt to insert a choice for an invalid Question_ID
EXEC CHOICE_INSERTION 
    @question_id = 999, 
    @choice = 'Paris'; -- Invalid Question_ID


