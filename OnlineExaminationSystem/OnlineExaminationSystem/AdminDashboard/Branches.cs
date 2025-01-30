using BusinessLogi.Repositories;
using BusinessLogic.Repositories;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;
using UI.Properties;

namespace UI.AdminDashboard
{
    public partial class Branches : Form1
    {
        private readonly IServiceProvider _serviceProvider;
        private InstructorRepo instructorRepo;
        private DataGridView customGrid;

        public Branches(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
            instructorRepo = _serviceProvider.GetRequiredService<InstructorRepo>();

            InitializeComponent();
            InitializeCustomGrid();

            // Set form properties
        }
        private void InitializeCustomGrid()
        {
             customGrid = new DataGridView
            {
                Location = new Point((this.ClientSize.Width - 700) / 2, 250), // Center based on form width
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

            // Set column headers style
            customGrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(204, 8, 8),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            // Set alternating rows style
        

            // Add Columns
            customGrid.Columns.Add("ID", "ID");
            customGrid.Columns.Add("Name", "Name");
            customGrid.Columns.Add("Score", "Score");
            customGrid.RowTemplate.Height = 40;
            customGrid.DefaultCellStyle.Padding = new Padding(0, 0, 0, 0);

            // **Create Actions Column**
            DataGridViewImageColumn actionColumn = new DataGridViewImageColumn
            {
                Name = "Actions",
                HeaderText = "Actions",
                ImageLayout = DataGridViewImageCellLayout.Zoom, // Resize to fit
                Width = 100
            };
            customGrid.Columns.Add(actionColumn);

            // Load icons
            Image editIcon = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\..\Resources\1.png"));
            Image viewIcon = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\..\Resources\edit.png"));
            Image deleteIcon = Image.FromFile(Path.Combine(Application.StartupPath, @"..\..\..\Resources\trash.png"));

            // Add rows with images
            customGrid.Rows.Add(1, "Alice", 90);
            customGrid.Rows.Add(2, "Bob", 85);
            customGrid.Rows.Add(3, "Charlie", 78);
            customGrid.Rows.Add(1, "Alice", 90);
            customGrid.Rows.Add(2, "Bob", 85);
            customGrid.Rows.Add(3, "Charlie", 78);
            customGrid.Rows.Add(1, "Alice", 90);
            customGrid.Rows.Add(2, "Bob", 85);
            customGrid.Rows.Add(3, "Charlie", 78);
            customGrid.Rows.Add(1, "Alice", 90);
            customGrid.Rows.Add(2, "Bob", 85);
            customGrid.Rows.Add(3, "Charlie", 78);
            customGrid.Rows.Add(1, "Alice", 90);
            customGrid.Rows.Add(2, "Bob", 85);
            customGrid.Rows.Add(3, "Charlie", 78);
            customGrid.Rows.Add(1, "Alice", 90);
            customGrid.Rows.Add(2, "Bob", 85);
            customGrid.Rows.Add(3, "Charlie", 78);

            foreach (DataGridViewRow row in customGrid.Rows)
            {
                // Create a combined image
                Bitmap combinedImage = new Bitmap(130, 30);
                using (Graphics g = Graphics.FromImage(combinedImage))
                {
                    g.DrawImage(editIcon, new Rectangle(0, 0, 20, 20));
                    g.DrawImage(viewIcon, new Rectangle(40, 0, 20, 20));
                    g.DrawImage(deleteIcon, new Rectangle(80, 0, 20, 20));
                }

                row.Cells["Actions"].Value = combinedImage;
            }



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



            // Handle button clicks
            customGrid.CellClick += CustomGrid_CellClick;



            this.Controls.Add(customGrid);
        }

        // Handle button click events
        private void CustomGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 3 && e.RowIndex >= 0) // Action column
            {
                int clickX = ((DataGridView)sender).GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
                if (clickX < 30)
                {
                    MessageBox.Show("Edit clicked!");
                }
                else if (clickX < 65)
                {
                    MessageBox.Show("View clicked!");
                }
                else
                {
                    MessageBox.Show("Delete clicked!");
                }
            }
            DataGridViewRow clickedRow = customGrid.Rows[e.RowIndex];
            //clickedRow.DefaultCellStyle.BackColor = Color.Yellow; // Set the color to whatever you prefer
        }
        private void Branches_Load(object sender, EventArgs e)
        {
        }
    }
}
