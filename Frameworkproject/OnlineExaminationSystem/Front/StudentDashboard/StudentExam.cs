using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using Front.InstructorDashboard;
using Front.popUpForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Front.StudentDashboard
{
    public partial class StudentExam : Front.StudentDashboard.StudentDashboard
    {
        private StudentExamRepo repo;   
        private DataGridView customGrid;
        private Button addbutton;
        private int userId;

        public StudentExam(int userId, string userType) : base(userId, userType)
        {
            repo=  new StudentExamRepo();   
         
            this.userId = userId;

            InitializeComponent();
            GenerateCustomSearch();
            InitializeExamCards();
            this.Size = new Size(1150, 570);
        }
        private void InitializeExamCards()
        {
            Panel scrollPanel = new Panel
            {
                Location = new Point(230, 160),
                Size = new Size(750, 300),
                AutoScroll = true,
                BorderStyle = BorderStyle.None
            };

            this.Controls.Add(scrollPanel);

            List<StudentExamCardDTO> exams = repo.GetStudentExamsCard(1); // Assuming this gets exams dynamically

            int xOffset = 20;
            int xPosition = xOffset, yPosition = 20;
            int maxColumns = 2;
            int padding = 10;
            int cardWidth = 300;
            DateTime now = DateTime.Now;

            for (int i = 0; i < exams.Count; i++)
            {
                CustomCard card = new CustomCard();
                card.SetCardData(
                    title: exams[i].Course_Name,
                    description: exams[i].Track_Name,
                    examDate: exams[i].Exam_Date,
                    startTime: exams[i].StartTime,
                    endTime: exams[i].EndTime,
                    noTF: exams[i].No_TF,
                    noMCQ: exams[i].No_MCQ,
                    maxMarks: exams[i].Max_Marks,
                    examId: exams[i].Exam_ID
                );

                // Remove unnecessary buttons
                Control buttonToRemove = card.Controls["Details"];
                Control buttonToRemove2 = card.Controls["Assign"];

                if (buttonToRemove != null)
                {
                    card.Controls.Remove(buttonToRemove);
                }

                if (buttonToRemove2 != null)
                {
                    card.Controls.Remove(buttonToRemove2);
                }

                card.Width = cardWidth;
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Location = new Point(xPosition, yPosition);

                // Convert StartTime and EndTime to DateTime
                DateTime examStart, examEnd;

                // Safely parse StartTime and EndTime
                if (DateTime.TryParse(exams[i].StartTime, out var startTime) &&
                    DateTime.TryParse(exams[i].EndTime, out var endTime))
                {
                    examStart = exams[i].Exam_Date.Date.Add(startTime.TimeOfDay);
                    examEnd = exams[i].Exam_Date.Date.Add(endTime.TimeOfDay);
                }
                else
                {
                    // Handle invalid time format (e.g., log error, skip this exam, or show a message)
                    MessageBox.Show("Invalid time format for exam.");
                    return;
                }

                Button actionButton = null;

                // Capture the current Exam_ID in a local variable
                int currentExamId = exams[i].Exam_ID;

                if (now > examEnd) // Exam has ended, show "View Result" button
                {
                    actionButton = new Button
                    {
                        Text = "View Result",
                        Size = new Size(120, 30),
                        BackColor = Color.Green,
                        ForeColor = Color.White
                    };
                    actionButton.Click += (s, e) => ViewResult(userId, currentExamId); // Use the captured value
                }
                else if (now >= examStart && now <= examEnd) // Exam is happening now, show "Join" button
                {
                    actionButton = new Button
                    {
                        Text = "Join",
                        Size = new Size(120, 30),
                        BackColor = Color.Red,
                        ForeColor = Color.White
                    };
                    actionButton.Click += (s, e) => Join(1, currentExamId); // Use the captured value
                }
                else // Exam is in the future, show "Upcoming" button
                {
                    actionButton = new Button
                    {
                        Text = "Upcoming",
                        Size = new Size(120, 30),
                        BackColor = Color.Gray,
                        ForeColor = Color.White
                    };
                    actionButton.Click += (s, e) => MessageBox.Show("Soon...");
                }

                if (actionButton != null)
                {
                    actionButton.Location = new Point(10, card.Height - 40);
                    card.Controls.Add(actionButton);
                }

                // Adjust card positions
                if ((i + 1) % maxColumns == 0)
                {
                    xPosition = xOffset;
                    yPosition += card.Height + padding;
                }
                else
                {
                    xPosition += card.Width + padding;
                }

                scrollPanel.Controls.Add(card);
            }
        }


        private void Join(int studentId, int examId)
        {
            var form = new ExamView( studentId ,examId);
            form.Show();
        }

        private void ViewResult(int studentId, int examId)
        {
            var form = new StudentExamResult(studentId, examId);
            form.Show();
        }
        void Soon()
        {

        }
       

        public Button GenerateCustomButton()
        {
            // Create the Add New Item Button
            Button addButton = new Button
            {
                Text = "Add New Item",
                Location = new Point(850, 100), // Below the search bar
                Size = new Size(150, 30),
                BackColor = Color.FromArgb(204, 8, 8),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,  // Disable default button styling

            };

            // Add custom border to the button
            addButton.Paint += (s, e) =>
            {
                var rect = new Rectangle(0, 0, addButton.Width - 1, addButton.Height - 1);
                var radius = 10;  // Radius for rounded corners
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(Color.FromArgb(204, 8, 8)), path);  // Fill button color
                e.Graphics.DrawPath(new Pen(Color.Gray), path);  // Border color

                // Draw the text manually
                var textSize = e.Graphics.MeasureString(addButton.Text, addButton.Font);
                var textX = (addButton.Width - textSize.Width) / 2;
                var textY = (addButton.Height - textSize.Height) / 2;

                e.Graphics.DrawString(addButton.Text, addButton.Font, new SolidBrush(addButton.ForeColor), textX, textY);
            };


            // Add the add new item button to the form
            this.Controls.Add(addButton);
            return addButton;

        }
        public void GenerateCustomSearch()
        {

            // Create the Panel for search
            Panel searchPanel = new Panel
            {
                Location = new Point((this.ClientSize.Width - 1000), 100), // Below the grid
                Size = new Size(600, 30),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None, // Remove default border
                Padding = new Padding(5) // Padding to ensure the icon and text are not too close to the borders
            };

            // Handle the custom drawing for rounded corners of the Panel
            searchPanel.Paint += (s, e) =>
            {
                // Create a rounded rectangle path
                var rect = new Rectangle(0, 0, searchPanel.Width - 1, searchPanel.Height - 1);
                var radius = 10;  // Radius for the corners
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // Set the border color and fill color
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(Color.White), path); // Fill with white color
                e.Graphics.DrawPath(new Pen(Color.Gray), path); // Border color
            };

            // Create the Search TextBox with Rounded Corners
            TextBox searchTextBox = new TextBox
            {
                Location = new Point(30, 5), // Position inside the panel, leaving space for the icon
                Size = new Size(550, 20),
                BorderStyle = BorderStyle.None, // Remove default border
                BackColor = Color.White,
                ForeColor = Color.Black,
                Padding = new Padding(10, 0, 10, 0)  // Add padding to ensure the text isn't too close to the edges
            };

            // Handle the custom drawing for rounded corners of the TextBox
            searchTextBox.Paint += (s, e) =>
            {
                // Create a rounded rectangle path for TextBox
                var rect = new Rectangle(0, 0, searchTextBox.Width - 1, searchTextBox.Height - 1);
                var radius = 10;  // Radius for the corners
                var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.Left, rect.Top, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Top, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.Left, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // Set the border color and fill color
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(new SolidBrush(Color.White), path); // Fill with white color
                e.Graphics.DrawPath(new Pen(Color.Gray), path); // Border color
            };

            // Add TextBox to the Panel
            searchPanel.Controls.Add(searchTextBox);

            // Add the Search Icon (PictureBox) inside the Panel
            PictureBox searchIcon = new PictureBox
            {
                Image = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Resources\search.png")), // Replace with your icon path
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(5, 5),  // Position it to the left inside the Panel
                Size = new Size(20, 20)  // Icon size
            };

            // Add the icon to the panel
            searchPanel.Controls.Add(searchIcon);

            // Handle text change in search box for filtering
            searchTextBox.TextChanged += (s, e) =>
            {
                string searchQuery = searchTextBox.Text.ToLower();
                //foreach (DataGridViewRow row in customGrid.Rows)
                //{
                //    // Check if any column contains the search query
                //    bool isVisible = row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value.ToString().ToLower().Contains(searchQuery));
                //    row.Visible = isVisible;
                //}
            };

            // Add the search panel to the form
            this.Controls.Add(searchPanel);
        }
    }
}
