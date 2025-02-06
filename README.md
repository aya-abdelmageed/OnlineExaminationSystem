# Online Examination System - Database Documentation

## 📌 Team Members
- **Aliaa Mohammed**  
- **Aliaa Mamoon**  
- **Aya Abdelmageed**  
- **Aya Muhammed**  

## 📝 Project Overview
### 📖 Introduction
The **Online Examination System** is designed to streamline the examination process by automating exam creation, student management, and result processing. The system ensures **secure data handling**, **efficient query execution**, and **comprehensive reporting** for ITI admins and instructors.

### 🎯 Objectives
- ✅ Automate the examination process.
- ✅ Manage student registration, Exam attendance, and grading.
- ✅ Secure and optimize data storage and retrieval.
- ✅ Generate insightful reports for system administrators and instructors that can be export into Excel, word, or PDF files.

## 🛠 Technologies Used
- **📂 Database**: MS SQL Server
- **💻 Frontend**: Windows Forms (.NET Framework)
- **⚙️ Backend Tools**: Node.js & Python *(Used for web scraping to collect questions)*
- **📊 Diagramming Tools**:
  - 🖊️ *Draw.io*: Used for creating the **Entity-Relationship Diagram (ERD)**
  - 🎨 *Figma*: Used for mapping the **ERD**

## 🌟 Features of the System
- 👥 **User Management**: Manages students, instructors, and admins.
- 📜 **Exam Management**: Allows instructors to create and manage exams.
- 📚 **Question Bank**: Stores various types of questions for each course.
- 📊 **Student Tracking**: Monitors student enrollment in courses and exams.
- 🏆 **Grading & Results Processing**: Automatically calculates and stores results.
- 📑 **Reporting Module**: Generates reports related to student performance, exam details, and course information.

## 📊 Reporting Capabilities
The system can generate reports for:
- 📌 Students' details filtered by department.
- 📌 Students' grades for each enrolled course.
- 📌 Instructors' courses and the number of students enrolled in each.
- 📌 Course topics.
- 📌 Generated exam details, including questions and choices.
- 📌 Students' exam answers and grades.

## 🗃 Database Design
### 📁 Database Structure and Filegroups
To enhance **performance, scalability, and data management**, the Online Examination System database is structured with multiple **file groups** in MS SQL Server:
- 📂 **Exam**: Holds tables related to exams, including exam and question tables.
- 📂 **Student**: Stores student-related data.
- 📂 **Instructor**: Contains instructor-related tables.
- 📂 **Main**: Holds the remaining system tables.
## ERD
![ERD]((https://github.com/aya-abdelmageed/OnlineExaminationSystem/blob/main/diagrams/OnlineExaminationSystem.drawio.png))


### 🔄 Database Operations
- 🔹 Perform **CRUD (Create, Read, Update, Delete)** operations on all tables.
- 🔹 Use **stored procedures** for optimized data retrieval and encryption.

### :rocket: Demo
[🎥 Watch Demo Video](https://github.com/aya-abdelmageed/OnlineExaminationSystem/blob/main/Demo/ExaminationSystemDemo.mp4)

---
This documentation provides an overview of the **database structure** and **functionalities** of the Online Examination System. For more details, refer to the **Demo**, **code**, and additional **documentation files** in this repository.
