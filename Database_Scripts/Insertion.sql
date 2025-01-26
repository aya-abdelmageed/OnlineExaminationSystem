-- Insert data into Branch table
INSERT INTO Branch (Branch_Name, Phone, Location) 
VALUES 
('Cairo', '0123456789', 'Cairo'),
('Smart village', '0123456799', 'Giza'),
('Alexandria', '0123456788', 'Alexandria'),
('Assiut', '0123456787', 'Assiut'),
('Mansoura', '0123456786', 'Mansoura'),
('Zagazig', '0123456785', 'Zagazig'),
('Tanta', '0123456784', 'Tanta'),
('Ismailia', '0123456783', 'Ismailia'),
('Sohag', '0123456782', 'Sohag'),
('Luxor', '0123456781', 'Luxor'),
('Aswan', '0123456780', 'Aswan'),
-- Add 20 more branch records
('Fayoum', '0123456792', 'Fayoum'),
('Minya', '0123456793', 'Minya'),
('Qena', '0123456794', 'Qena'),
('Beni Suef', '0123456795', 'Beni Suef'),
('Matruh', '0123456796', 'Matruh'),
('North Sinai', '0123456797', 'North Sinai'),
('South Sinai', '0123456798', 'South Sinai'),
('New Valley', '0123456799', 'New Valley'),
('Red Sea', '0123456710', 'Red Sea'),
('Port Said', '0123456711', 'Port Said'),
('Suez', '0123456712', 'Suez'),
('Damietta', '0123456713', 'Damietta'),
('Kafr El Sheikh', '0123456714', 'Kafr El Sheikh'),
('Qalyubia', '0123456715', 'Qalyubia'),
('Sharqia', '0123456716', 'Sharqia'),
('Gharbia', '0123456717', 'Gharbia'),
('Dakhla', '0123456718', 'Dakhla'),
('Farafra', '0123456719', 'Farafra'),
('Marsa Alam', '0123456720', 'Marsa Alam');

-- Insert data into Track table
INSERT INTO Track (Track_Name, Department) 
VALUES 
('Web Development', 'Programming'),
('Data Science', 'Programming'),
('Mobile Development', 'Programming'),
('AI and Machine Learning', 'Programming'),
('Cyber Security', 'Programming'),
('Cloud Computing', 'Programming'),
('Blockchain Development', 'Programming'),
('Game Development', 'Programming'),
('DevOps', 'Programming'),
('Software Engineering', 'Programming'),
-- Add 20 more track records
('UI/UX Design', 'Design'),
('Project Management', 'Business'),
('Full Stack Development', 'Programming'),
('Big Data', 'Programming'),
('Digital Marketing', 'Business'),
('Embedded Systems', 'Engineering'),
('Networking', 'Engineering'),
('IOT', 'Engineering'),
('Quality Assurance', 'Programming'),
('Automation Testing', 'Programming'),
('Database Administration', 'Programming'),
('VR/AR Development', 'Programming'),
('SAP Programming', 'Programming'),
('IT Management', 'Business'),
('Entrepreneurship', 'Business'),
('HR Analytics', 'Business'),
('Salesforce Administration', 'Business'),
('Supply Chain Management', 'Business'),
('Operations Research', 'Business'),
('Energy Management', 'Business');

-- Insert data into Track_Branch table
INSERT INTO Track_Branch (Track_ID, Branch_ID)
SELECT t.Track_ID, b.Branch_ID 
FROM Track t, Branch b

-- Insert data into Course table
INSERT INTO Course (Course_Name)
VALUES 
('HTML & CSS'),
('JavaScript Basics'),
('Advanced JavaScript'),
('React Development'),
('Node.js'),
('Python for Data Science'),
('Machine Learning'),
('Deep Learning'),
('Cyber Security Basics'),
('Cloud Fundamentals'),
-- Add 20 more course records
('Blockchain Basics'),
('Solidity Development'),
('Game Design Basics'),
('Unity Development'),
('CI/CD Pipelines'),
('Microservices Architecture'),
('Agile Development'),
('Android Development'),
('iOS Development'),
('Cross-platform Mobile Development'),
('Database Fundamentals'),
('SQL for Beginners'),
('Data Warehousing'),
('Big Data Tools'),
('Intro to AWS'),
('Azure Cloud Computing'),
('Web Security Essentials'),
('PHP Development'),
('Ruby on Rails'),
('Advanced C++ Programming');

//--------------------------------------------------------------------------
-- Insert data into Topic table
-- Assuming each course has 3 topics
INSERT INTO Topic (Topic_Name, Course_ID)
VALUES 
-- HTML & CSS
('Introduction to HTML', 1),
('CSS Styling Basics', 1),
('Responsive Design', 1),

-- JavaScript Basics
('Variables in JavaScript', 2),
('Loops and Functions', 2),
('DOM Manipulation', 2),

-- Advanced JavaScript
('ES6 Features', 3),
('Asynchronous JavaScript', 3),
('Error Handling', 3),

-- React Development
('Hooks in React', 4),
('State Management', 4),
('Redux Basics', 4),

-- Node.js
('Express.js Basics', 5),
('Working with Databases', 5),
('REST API Development', 5),

-- Python for Data Science
('Data Preprocessing', 6),
('Data Visualization', 6),
('Pandas Basics', 6);
//------------------------------------------------------------------
-- Insert data into Questions table
INSERT INTO Questions (Correct_Ans, Question, Type, Points, Course_ID)
VALUES
-- HTML & CSS
(2, 'You are designing a website layout using CSS. You want to ensure that the container of a section takes up 50% of the screen width, regardless of the user''s screen size. Which of the following is the correct CSS property to achieve this?', 'MCQ', 2, 1),
(2, 'Which HTML element is used to create a hyperlink?', 'MCQ', 1, 1),
(3, 'What CSS property is used to change the text color of an element?', 'MCQ', 1, 1),
(3, 'You want to create a form in HTML. Which of the following tags is used to group together form controls such as inputs and labels?', 'MCQ', 1, 1),
(1, 'In CSS, how would you center a block-level element horizontally within its parent container?', 'MCQ', 1, 1),
(1, 'Which of the following CSS properties will remove the default bullet points from an unordered list?', 'MCQ', 1, 1),
(2, 'Which HTML tag is used for the largest heading?', 'MCQ', 1, 1),
(3, 'How do you add a comment in CSS?', 'MCQ', 1, 1),
(3, 'Which HTML attribute is used to define inline styles directly on an element?', 'MCQ', 1, 1),
(1, 'What is the correct syntax for including an external CSS file in an HTML document?', 'MCQ', 1, 1),
(1, 'Which of the following is the correct HTML5 doctype declaration?', 'MCQ', 1, 1),
(4, 'What is the default value of the position property in CSS?', 'MCQ', 1, 1),
(1, 'Which CSS property is used to control the space between lines of text?', 'MCQ', 1, 1),
(2, 'In HTML, which attribute is used to specify that an input field must be filled out before submitting the form?', 'MCQ', 2, 1),
(1, 'Which CSS property specifies whether an element should be visible or hidden?', 'MCQ', 1, 1),
(1, 'What HTML attribute is used to define inline JavaScript?', 'MCQ', 2, 1),
(3, 'In CSS, what does the z-index property control?', 'MCQ', 1, 1),
(3, 'Which of the following is NOT a valid HTML tag?', 'MCQ', 1, 1),
(2, 'What is the default display value of an HTML <div> element?', 'MCQ', 1, 1),
(2, 'Which property is used to specify the background color of an element in CSS?', 'MCQ', 1, 1),
(1, 'How can you include a comment in HTML?', 'MCQ', 1, 1),
(1, 'Which CSS property is used to create space between the content of an element and its border?', 'MCQ', 1, 1),
(2, 'What is the result of the following CSS: p { color: blue; }?', 'MCQ', 1, 1),
(2, 'Which HTML element is used to define a division or a section in an HTML document?', 'MCQ', 1, 1),
(2, 'In CSS, what does opacity: 0.5; do to an element?', 'MCQ', 1, 1),
(1, 'Which HTML tag is used to embed an image in a web page?', 'MCQ', 1, 1),
(2, 'In CSS, what does float: left; do to an element?', 'MCQ', 1, 1),
(3, 'Which of the following units is relative to the size of the root element in CSS?', 'MCQ', 1, 1),
(2, 'Which CSS rule will select all elements with the class \"header\"?', 'MCQ', 1, 1),
(2, 'Which HTML attribute is used to define the path of an image file in the <img> tag?', 'MCQ', 1, 1),
(2, 'Which of the following CSS properties will make an element invisible but still take up space on the page?', 'MCQ', 1, 1),
(2, 'How do you create an ordered list in HTML?', 'MCQ', 1, 1),
(1, 'Which of the following values of the position property will position an element relative to its nearest positioned ancestor?', 'MCQ', 1, 1),
(1, 'What is the correct syntax for creating a table in HTML?', 'MCQ', 1, 1),
(1, 'Which of the following properties is used to specify the thickness of a border?', 'MCQ', 1, 1),
(1, 'Which HTML element is used to define metadata about an HTML document?', 'MCQ', 1, 1),
(2, 'In CSS, how would you select all <p> elements inside a <div>?', 'MCQ', 1, 1),
(2, 'Which of the following CSS properties is used to control the order of flexible items in a flex container?', 'MCQ', 1, 1),
(2, 'Which of the following is a valid HTML5 semantic element?', 'MCQ', 2, 1),
(2, 'Which property in CSS is used to define the space between a border and the surrounding elements?', 'MCQ', 1, 1),
(1, 'Which HTML tag is used to play a video file in a webpage?', 'MCQ', 1, 1),
(2, 'In CSS, what is the purpose of the calc() function?', 'MCQ', 1, 1),
(1, 'What is the correct way to reference an external JavaScript file in an HTML document?', 'MCQ', 1, 1),
(2, 'What does the CSS box-shadow property do?', 'MCQ', 1, 1),
(1, 'Which tag is used in HTML5 to define a footer for a document or section?', 'MCQ', 1, 1),
(1, 'What CSS property allows an element to expand in proportion to its sibling elements in a flex container?', 'MCQ', 1, 1),
(2, 'Which attribute is used in the <a> tag to specify the destination URL of a link?', 'MCQ', 1, 1),
(2, 'Which HTML element is used to display a clickable button?', 'MCQ', 1, 1),
(1, 'Which of the following properties is used to create rounded corners in CSS?', 'MCQ', 2, 1),
(1, 'In HTML5, which tag is used to represent the navigation links of a website?', 'MCQ', 1, 1),


-- JavaScript Basics
(2, 'Which of the following is not a valid JavaScript data type?', 'MCQ', 2, 2),
(1, 'What is the correct syntax to create a function in JavaScript?', 'MCQ', 2, 2),

--React Development
(2, 'How does state management work in React?', 'TF', 1, 4),

--Node.js
(2, 'What is the command to start a Node.js server?', 'MCQ', 1, 5),

--Python for Data Science
(1, 'What is the command to initialize a Git repository?', 'MCQ', 1, 6),

--Machine Learning
(4, 'Which library is used for deep learning in Python?', 'MCQ', 2, 7),

--Cloud Fundamentals
(3, 'What are the key components of a cloud architecture?', 'MCQ', 2, 10),

--Solidity Development
(2, 'What does SQL stand for?', 'MCQ', 2, 12);


-- Insert data into Choices table (choices for each question)
INSERT INTO  Questions_Choices (Question_ID, Choice)
VALUES
-- HTML & CSS
(1, 'width: 50px;'),
(1, 'width: 50%;'),
(1, 'max-width: 50%;'),
(1, 'min-width: 50%;'),

(2, '<link>'),
(2, '<a>'),
(2, '<href>'),
(2, '<button>'),

(3, 'font-size'),
(3, 'background-color'),
(3, 'color'),
(3, 'text-color'),

(4, '<div>'),
(4, '<form>'),
(4, '<fieldset>'),
(4, '<section>'),

(5, 'margin: auto;'),
(5, 'text-align: center;'),
(5, 'position: center;'),
(5, 'align: middle;'),

(6, 'list-style: none;'),
(6, 'display: block;'),
(6, 'text-decoration: none;'),
(6, 'remove-bullets: true;'),

(7, '<heading>'),
(7, '<h1>'),
(7, '<h6>'),
(7, '<head>'),

(8, '// This is a comment'),
(8, '<!-- This is a comment -->'),
(8, '/* This is a comment */'),
(8, '# This is a comment'),

(9, 'class'),
(9, 'id'),
(9, 'style'),
(9, 'css'),

(10, '<link rel="stylesheet" href="style.css">'),
(10, '<css href="style.css">'),
(10, '<style src="style.css">'),
(10, '<stylesheet link="style.css">'),

(11, '<!DOCTYPE html>'),
(11, '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN">'),
(11, '<!DOCTYPE h5>'),
(11, '<DOCTYPE html>'),

(12, 'relative'),
(12, 'absolute'),
(12, 'fixed'),
(12, 'static'),

(13, 'line-height'),
(13, 'text-indent'),
(13, 'font-spacing'),
(13, 'letter-spacing'),

(14, 'placeholder'),
(14, 'required'),
(14, 'value'),
(14, 'validate'),

(15, 'visibility'),
(15, 'display'),
(15, 'opacity'),
(15, 'hide'),

(16, 'onclick'),
(16, 'onload'),
(16, 'script'),
(16, 'href'),

(17, 'The transparency of an element'),
(17, 'The horizontal position of an element'),
(17, 'The stacking order of elements'),
(17, 'The width of an element'),

(18, '<em>'),
(18, '<strong>'),
(18, '<break>'),
(18, '<br>'),

(19, 'inline'),
(19, 'block'),
(19, 'inline-block'),
(19, 'flex'),

(20, 'color'),
(20, 'background-color'),
(20, 'bg-color'),
(20, 'fill'),

(21, '<!-- This is a comment -->'),
(21, '// This is a comment'),
(21, '/* This is a comment */'),
(21, '# This is a comment'),

(22, 'padding'),
(22, 'margin'),
(22, 'border-spacing'),
(22, 'spacing'),

(23, 'It sets the background color of all paragraphs to blue.'),
(23, 'It sets the font color of all paragraphs to blue.'),
(23, 'It sets the border color of all paragraphs to blue.'),
(23, 'It changes the link color in paragraphs to blue.'),

(24, '<section>'),
(24, '<div>'),
(24, '<article>'),
(24, '<span>'),

(25, 'It makes the element completely transparent.'),
(25, 'It makes the element 50% opaque.'),
(25, 'It makes the element 50% wider.'),
(25, 'It removes the element from the document flow.'),

(26, '<img>'),
(26, '<image>'),
(26, '<picture>'),
(26, '<src>'),

(27, 'It centers the element horizontally.'),
(27, 'It moves the element to the left of its container and allows text to wrap around it.'),
(27, 'It hides the element.'),
(27, 'It aligns the element to the top left corner of the page.'),

(28, 'em'),
(28, 'px'),
(28, 'rem'),
(28, '%'),

(29, '#header {}'),
(29, '.header {}'),
(29, 'header {}'),
(29, '*header {}'),

(30, 'href'),
(30, 'src'),
(30, 'alt'),
(30, 'link'),

(31, 'display: none;'),
(31, 'visibility: hidden;'),
(31, 'opacity: 0;'),
(31, 'float: none;'),

(32, '<ul>'),
(32, '<ol>'),
(32, '<li>'),
(32, '<list>'),

(33, 'absolute'),
(33, 'relative'),
(33, 'fixed'),
(33, 'static'),

(34, '<table><tr><td>Data</td></tr></table>'),
(34, '<table><row><data>Data</data></row></table>'),
(34, '<table><tr><th>Data</th></tr></table>'),
(34, '<table><tr><td><td>Data</td></tr></table>'),

(35, 'border-width'),
(35, 'border-height'),
(35, 'border-thickness'),
(35, 'border-style'),

(36, '<meta>'),
(36, '<head>'),
(36, '<header>'),
(36, '<info>'),

(37, 'p div {}'),
(37, 'div p {}'),
(37, '.div p {}'),
(37, 'div + p {}'),

(38, 'flex-direction'),
(38, 'order'),
(38, 'align-items'),
(38, 'flex-grow'),

(39, '<span>'),
(39, '<article>'),
(39, '<div>'),
(39, '<section>'),

(40, 'padding'),
(40, 'border-spacing'),
(40, 'margin'),
(40, 'border-width'),

(41, '<media>'),
(41, '<video>'),
(41, '<embed>'),
(41, '<movie>'),

(42, 'To apply dynamic styling based on user input.'),
(42, 'To calculate mathematical expressions for property values.'),
(42, 'To animate elements based on time values.'),
(42, 'To control the order of execution in the browser.'),

(43, '<script src="script.js"></script>'),
(43, '<js href="script.js"></js>'),
(43, '<script link="script.js"></script>'),
(43, '<link rel="javascript" href="script.js">'),

(44, 'Adds a shadow inside the border of an element.'),
(44, 'Adds a shadow outside the border of an element.'),
(44, 'Increases the width of the border.'),
(44, 'Controls the visibility of the element.'),

(45, '<footer>'),
(45, '<bottom>'),
(45, '<section>'),
(45, '<end>'),

(46, 'flex-grow'),
(46, 'flex-wrap'),
(46, 'align-content'),
(46, 'justify-content'),

(47, 'target'),
(47, 'href'),
(47, 'rel'),
(47, 'src'),

(48, '<input>'),
(48, '<button>'),
(48, '<a>'),
(48, '<div>'),

(49, 'border-radius'),
(49, 'border-corner'),
(49, 'corner-radius'),
(49, 'border-style'),

(50, '<nav>'),
(50, '<header>'),
(50, '<aside>'),
(50, '<menu>'),


-- JavaScript Basics
(51, 'String'),
(51, 'Boolean'),
(51, 'Number'),
(51, 'Character'),

(52, 'function = myFunction()'),
(52, 'function:myFunction()'),
(52, 'function myFunction()'),
(52, 'func myFunction()');
//--------------------------------------------------------------------------------------
-- Insert data into Student table
INSERT INTO Student (Gender, FName, MName, LName, Phone, Birthdate, Track_ID)
VALUES
('M', 'Ahmed', 'Ali', 'Hassan', '0121112233', '1998-02-15', 1),
('F', 'Mona', 'Sami', 'Youssef', '0121223344', '1999-06-20', 2),
('M', 'Khaled', 'Omar', 'Nour', '0121334455', '1997-10-30', 3),
('F', 'Sara', 'Mahmoud', 'Ezzat', '0121445566', '1996-01-25', 4),
('M', 'Youssef', 'Adel', 'Gamal', '0121556677', '1995-09-12', 5),
('F', 'Hoda', 'Ashraf', 'Saad', '0121667788', '2000-11-05', 6),
('M', 'Amr', 'Magdy', 'Farid', '0121778899', '1998-04-14', 7),
('F', 'Nadia', 'Sameh', 'Fouad', '0121889900', '1994-07-22', 8),
('M', 'Omar', 'Hesham', 'Abdelrahman', '0121991011', '1993-03-17', 9),
('F', 'Dina', 'Mohamed', 'Saif', '0122002112', '1992-12-03', 10);

-- Insert data into Instructor table
INSERT INTO Instructor (FName, MName, LName, Email, Gender, Age, Salary)
VALUES
('Hassan', 'Mohamed', 'Khalil', 'hassan.khalil@iti.edu', 'M', 35, 12000.00),
('Yasmine', 'Ali', 'Omar', 'yasmine.omar@iti.edu', 'F', 29, 10000.00),
('Karim', 'Said', 'Gad', 'karim.gad@iti.edu', 'M', 40, 15000.00),
('Nourhan', 'Ehab', 'Farid', 'nourhan.farid@iti.edu', 'F', 31, 11000.00),
('Tamer', 'Ashraf', 'Sami', 'tamer.sami@iti.edu', 'M', 45, 18000.00),
('Laila', 'Ahmed', 'Younis', 'laila.younis@iti.edu', 'F', 33, 12500.00),
('Sameh', 'Tarek', 'Zaki', 'sameh.zaki@iti.edu', 'M', 38, 14000.00),
('Mai', 'Hussein', 'Gamal', 'mai.gamal@iti.edu', 'F', 26, 9500.00),
('Hossam', 'Fouad', 'Elmasry', 'hossam.elmasry@iti.edu', 'M', 42, 17000.00),
('Alaa', 'Mostafa', 'Nabil', 'alaa.nabil@iti.edu', 'F', 37, 13500.00);

-- Insert data into Ins_Track_Course table
INSERT INTO Ins_Track_Course (Ins_ID, Track_ID, Course_ID, Course_Date)
VALUES
(1, 1, 1, '2025-01-01'),
(1, 2, 2, '2025-01-02'),
(2, 3, 3, '2025-01-03'),
(2, 4, 4, '2025-01-04'),
(3, 5, 5, '2025-01-05'),
(3, 6, 6, '2025-01-06'),
(4, 7, 7, '2025-01-07'),
(4, 8, 8, '2025-01-08'),
(5, 9, 9, '2025-01-09'),
(5, 10, 10, '2025-01-10');

-- Insert data into Exam table
INSERT INTO Exam (Ins_ID, Course_ID, Exam_Date, EndTime, StartTime, No_TF, No_MCQ, Max_Marks)
VALUES
(1, 1, '2025-01-30', '12:00:00', '10:00:00', 5, 10, 50),
(2, 2, '2025-02-01', '14:00:00', '12:00:00', 3, 7, 40),
(3, 3, '2025-02-05', '16:00:00', '14:00:00', 4, 8, 45),
(4, 4, '2025-02-10', '11:00:00', '09:00:00', 6, 12, 60),
(5, 5, '2025-02-15', '15:00:00', '13:00:00', 2, 6, 35);

-- Insert data into Exam_Questions table
INSERT INTO Exam_Questions (Exam_ID, Question_ID, Points_Edit)
VALUES
(1, 1, 5),
(1, 2, 5),
(1, 3, 5),

(2, 4, 5),
(2, 5, 5),

(3, 6, 5),
(3, 7, 5),
(3, 8, 5),

(4, 9, 5),
(4, 10, 5),

(5, 11, 5),
(5, 12, 5),
(5, 13, 5),
(5, 14, 5),
(5, 15, 5);

-- Insert data into Exam_Question_Student table
INSERT INTO Exam_Question_Student (Student_ID, Exam_ID, Question_ID, Answer, Score)
VALUES
(1, 1, 1, 1, 0),
(1, 1, 2, 3, 0),
(2, 1, 3, 1, 5),

(3, 2, 4, 1, 5),
(3, 2, 5, 2, 5),

(4, 3, 6, 3, 5),

(5, 4, 7, 2, 5),
(6, 4, 8, 1, 5),

(7, 5, 9, 2, 5),
(8, 5, 10, 1, 5);

-- Insert data into STUDENT_EXAM table
INSERT INTO STUDENT_EXAM (Student_ID, Exam_ID, Grade)
VALUES
(1, 1, 50),
(2, 1, 45),

(3, 2, 40),
(4, 2, 35),

(5, 3, 50),
(6, 3, 45),

(7, 4, 40),
(8, 4, 38),

(9, 5, 49),
(10, 5, 44);

-- Insert data into Exam_Track table
INSERT INTO Exam_Track (Track_ID, Exam_ID)
VALUES
(1, 1),
(2, 1),

(3, 2),
(4, 2),

(5, 3),
(6, 3),

(7, 4),
(8, 4),

(9, 5),
(10, 5);





