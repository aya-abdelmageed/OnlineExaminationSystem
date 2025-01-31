using BusinessLogic.Repositories;
using Front.popUpForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.AdminDashboard
{
    public partial class Tracks : Form1
    {
        private InstructorRepo instructorRepo;
        private DataGridView customGrid;
        private Button addbutton;

        public Tracks()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 657); // Set exact size (same as in the Designer)
            customGrid = InitializeCustomGrid();
            GenerateCustomSearch();
            customGrid.CellClick += CustomGrid_CellClick;
            addbutton = GenerateCustomButton();
            addbutton.Text = "Add";
            addbutton.Click += (s, e) =>
            {
                ShowForm(new TrackForm());
            };



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
        private void Tracks_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData() // load viewing data 
        {
            // var data = _instructorRepo.GetInstructors();
            //  customGrid.DataSource = data;
        }
    }
}
