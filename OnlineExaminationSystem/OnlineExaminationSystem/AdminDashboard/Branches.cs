using BusinessLogi.Repositories;
using BusinessLogic.Repositories;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.AdminDashboard
{
    public partial class Branches : Form1
    {
        private readonly IServiceProvider _serviceProvider;
        private ExamRepo ExamRepo;


        public Branches(IServiceProvider serviceProvider) :base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
            ExamRepo = _serviceProvider.GetRequiredService<ExamRepo>(); 

            InitializeComponent();
            InitializeCustomGrid();
        }

        private void InitializeCustomGrid()
        {
            // Create a new DataGridView
            DataGridView customGrid = new DataGridView
            {
                Location = new Point(500, 300), // Set position: X = 50, Y = 50
                Size = new Size(700, 400),   // Set size: Width = 700, Height = 400
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                RowHeadersVisible = false // Hide the row header column with arrows


            };

            // Set column headers style
            customGrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(64, 156, 255), // Header Background
                ForeColor = Color.White, // Header Text Color
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };

            // Set alternating rows style
            customGrid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(240, 240, 240) // Alternate Row Background
            };

            // Set default cell style
            customGrid.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(200, 230, 255), // Selection Background
                SelectionForeColor = Color.Black
            };

            // Row hover effect
            customGrid.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    customGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(220, 240, 255);
                }
            };
            customGrid.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex % 2 == 0)
                {
                    customGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                }
                else if (e.RowIndex >= 0)
                {
                    customGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            };

            var data = ExamRepo.GetExams(3);   
            customGrid.DataSource = data;   

            // Hide the first column (ID)
            // Add grid to the form
            this.Controls.Add(customGrid);
        }

        private void Branches_Load(object sender, EventArgs e)
        {
            // Ensure form size is large enough to display the grid
            this.Size = new Size(800, 600);
        }
    }
}
