using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using Front.popUpForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using UI.AdminDashboard;

namespace Front.InstructorDashboard
{
    public partial class Exams : InstructorDashboard
    {
        private ExamRepo exam;
        private DataGridView customGrid;
        private Button addbutton;

            public Exams()
            {

                exam = new ExamRepo();
                this.Height = 600;
            
                InitializeComponent();
                addbutton = GenerateCustomButton();
                addbutton.Text = "Generate new Exam";
                addbutton.Click += (s, e) =>
                {
                    var form =  new GenerateExam();
                    form.Show();
                };
                GenerateCustomSearch();
                InitializeExamCards();
                
            }

        private void InitializeExamCards()
        {
            // Create a scrollable panel
            Panel scrollPanel = new Panel
            {
                Location = new Point(230, 160), // Adjust position as needed
                Size = new Size(750, 400), // Adjust size as needed
                AutoScroll = true, // Enable scrolling
                BorderStyle = BorderStyle.FixedSingle // Optional: Add a border
            };

            this.Controls.Add(scrollPanel); // Add the panel to the form

            List<ExamCardDTO> exams = new List<ExamCardDTO>
            {
                new ExamCardDTO { Title = "Mathematics Exam", Description = "Mathematics exam for 2025.", ExamDate = new DateTime(2025, 2, 2), StartTime = "9:00 AM", EndTime = "12:00 PM", NoTF = 10, NoMCQ = 20, MaxMarks = 100 },
                new ExamCardDTO { Title = "Physics Exam", Description = "Physics exam for 2025.", ExamDate = new DateTime(2025, 2, 5), StartTime = "10:00 AM", EndTime = "1:00 PM", NoTF = 15, NoMCQ = 25, MaxMarks = 120 },
                new ExamCardDTO { Title = "Chemistry Exam", Description = "Chemistry exam for 2025.", ExamDate = new DateTime(2025, 2, 7), StartTime = "8:00 AM", EndTime = "11:00 AM", NoTF = 12, NoMCQ = 18, MaxMarks = 90 },
                new ExamCardDTO { Title = "Biology Exam", Description = "Biology exam for 2025.", ExamDate = new DateTime(2025, 2, 10), StartTime = "9:30 AM", EndTime = "12:30 PM", NoTF = 14, NoMCQ = 22, MaxMarks = 110 },
                new ExamCardDTO { Title = "Mathematics Exam", Description = "Mathematics exam for 2025.", ExamDate = new DateTime(2025, 2, 2), StartTime = "9:00 AM", EndTime = "12:00 PM", NoTF = 10, NoMCQ = 20, MaxMarks = 100 },
                new ExamCardDTO { Title = "Physics Exam", Description = "Physics exam for 2025.", ExamDate = new DateTime(2025, 2, 5), StartTime = "10:00 AM", EndTime = "1:00 PM", NoTF = 15, NoMCQ = 25, MaxMarks = 120 },
                new ExamCardDTO { Title = "Chemistry Exam", Description = "Chemistry exam for 2025.", ExamDate = new DateTime(2025, 2, 7), StartTime = "8:00 AM", EndTime = "11:00 AM", NoTF = 12, NoMCQ = 18, MaxMarks = 90 },
                new ExamCardDTO { Title = "Biology Exam", Description = "Biology exam for 2025.", ExamDate = new DateTime(2025, 2, 10), StartTime = "9:30 AM", EndTime = "12:30 PM", NoTF = 14, NoMCQ = 22, MaxMarks = 110 }
            };

            int xOffset = 20; // Offset for the initial position
            int xPosition = xOffset, yPosition = 20; // Added offset to starting position
            int maxColumns = 2;
            int padding = 10;
            int cardWidth = 350;

            for (int i = 0; i < exams.Count; i++)
            {
                CustomCard card = new CustomCard();
                card.SetCardData(
                    title: exams[i].Title,
                    description: exams[i].Description,
                    examDate: exams[i].ExamDate,
                    startTime: exams[i].StartTime,
                    endTime: exams[i].EndTime,
                    noTF: exams[i].NoTF,
                    noMCQ: exams[i].NoMCQ,
                    maxMarks: exams[i].MaxMarks
                );

                card.Width = cardWidth;

                card.BorderStyle = BorderStyle.Fixed3D;

                card.Location = new Point(xPosition, yPosition);

                if ((i + 1) % maxColumns == 0)
                {
                    xPosition = xOffset; // Reset for the next row with offset
                    yPosition += card.Height + padding; // Move to the next row
                }
                else
                {
                    xPosition += card.Width + padding; // Move to the right for the next card
                }

                scrollPanel.Controls.Add(card);
            }
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
                Location = new Point((this.ClientSize.Width - 800), 100), // Below the grid
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

