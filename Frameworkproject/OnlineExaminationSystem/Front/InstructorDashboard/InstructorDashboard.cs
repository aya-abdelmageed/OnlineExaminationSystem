using Front.ReportsControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Front.InstructorDashboard
{
    public partial class InstructorDashboard : Form 
    {
        private int userId;
        private string userType;
        public InstructorDashboard(int userId, string userType)
        {
            InitializeComponent();
            this.userId = userId;
            this.userType = userType;
            MessageBox.Show($"Loading data for ID: {userId}");
        }

        public GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Top-left arc
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);

            // Top-right arc
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);

            // Bottom-right arc
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);

            // Bottom-left arc
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            // Close the path
            path.CloseFigure();
            return path;
        }

        public void DrawRoundedPanelBorder(PaintEventArgs e, Panel panel, int radius, Color borderColor, int borderWidth)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle panelRect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            using (GraphicsPath path = GetRoundedRectanglePath(panelRect, radius))
            {
                // Fill the panel background
                using (Brush brush = new SolidBrush(panel.BackColor))
                {
                    graphics.FillPath(brush, path);
                }

                // Draw the border
                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    graphics.DrawPath(pen, path);
                }
            }
        }
        public void ShowForm(Form form)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            this.Hide(); // Hide Form1 instead of closing it

            form.FormClosed += (sender, e) => this.Close(); // Close Form1 when the new form is closed
            form.Show();
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {

        }

      

        private void Questions_Click(object sender, EventArgs e)
        {
            QuestionBank questionBank = new QuestionBank(userId , userType);
            ShowForm(questionBank);
        }

        private void Exams_Click(object sender, EventArgs e)
        {
            ShowForm(new Exams(userId,userType));
        }


        public Button GenerateCustomButton()
        {
            // Create the Add New Item Button
            Button addButton = new Button
            {
                Text = "Add New Item",
                Location = new Point(1000, 150), // Below the search bar
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
                Location = new Point((this.ClientSize.Width - 600) / 2, 150), // Below the grid
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
        public DataGridView InitializeCustomGrid()
        {
            var customGrid = new DataGridView
            {
                Location = new Point((this.ClientSize.Width - 700) / 2, 200), // Center based on form width
                Size = new Size(this.ClientSize.Width - 500, 300),  // Width = Form width - 10px
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, // Adjust columns to fit width
                ScrollBars = ScrollBars.Vertical,


            };
            customGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(128, 128, 128);  // Custom color instead of blue
            customGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            // Set column headers style
            customGrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(204, 8, 8),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            // Set alternating rows style




            customGrid.RowTemplate.Height = 20;
            customGrid.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);







            // Hover effect (on mouse enter/leave)
            customGrid.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    customGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(211, 211, 211);  // Change hover color
                }
            };
            customGrid.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {

                    customGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;  // Normal row color

                }

            };




            this.Controls.Add(customGrid);
            return customGrid;
        }
        public void AddActions(DataGridView customGrid)
        {
            //Load icons once for performance optimization
            var editIcon = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Resources\edit.png"));
            var viewIcon = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Resources\1.png"));
            var deleteIcon = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\Resources\trash.png"));

            // *Create Edit Action Column*

            var editColumn = new DataGridViewImageColumn
            {
                Name = "EditAction",
                HeaderText = "Edit",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 20 // Adjust based on icon size
            };

            // *Create View Action Column*

            var viewColumn = new DataGridViewImageColumn
            {
                Name = "ViewAction",
                HeaderText = "View",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 20 // Adjust based on icon size
            };

            // *Create Delete Action Column*

            var deleteColumn = new DataGridViewImageColumn
            {
                Name = "DeleteAction",
                HeaderText = "Delete",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 20 // Adjust based on icon size
            };

            // Add the columns to the grid

            customGrid.Columns.Add(viewColumn);
            customGrid.Columns.Add(editColumn);
            customGrid.Columns.Add(deleteColumn);

            // *Set Cell Formatting to Display Icons*

            customGrid.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == customGrid.Columns["ViewAction"].Index)
                    {
                        e.Value = viewIcon;
                    }
                    else if (e.ColumnIndex == customGrid.Columns["EditAction"].Index)
                    {
                        e.Value = editIcon;
                    }
                    else if (e.ColumnIndex == customGrid.Columns["DeleteAction"].Index)
                    {
                        e.Value = deleteIcon;
                    }
                }
            };


            // *Set Column Width and Minimum Width*

            customGrid.Columns["EditAction"].MinimumWidth = 20;
            customGrid.Columns["ViewAction"].MinimumWidth = 20;
            customGrid.Columns["DeleteAction"].MinimumWidth = 20;
        }



        private void InstructorDashboard_Load(object sender, EventArgs e)
        {

        }

  

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel2, 20, Color.Black, 2);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel3, 20, Color.Black, 2);

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel4, 20, Color.Black, 2);

        }
        private void Reports_Click(object sender, EventArgs e)
        {
            ShowForm(new InstructorReports(userId , userType));

        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login loginForm = new Login();
            loginForm.ShowDialog();
        }
    }
}

