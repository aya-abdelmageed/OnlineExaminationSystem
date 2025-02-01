using BusinessLogi.Repositories;
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
    public partial class Courses : Form1
    {
        private CourseRepo CourseRepo;
        private DataGridView customGrid;
        private Button addbutton;

        public Courses()
        {

            CourseRepo = new CourseRepo();      


            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 600); // Set exact size (same as in the Designer
            customGrid = InitializeCustomGrid();
            GenerateCustomSearch();
            addbutton = GenerateCustomButton();
            addbutton.Text = "Add Course";
            addbutton.Click += (s, e) =>
            {
                var newForm = new InstructorForm();
                newForm.Show();

            };
            LoadData();
            AddActions(customGrid);
            customGrid.CellClick += (s, e) => HandleActionClick(customGrid, e);

        }


        private void HandleActionClick(DataGridView customGrid, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked column is "Actions" and row is valid
            if (customGrid.Columns[e.ColumnIndex].Name != "Actions" || e.RowIndex < 0)
                return;

            // Get the click position inside the cell
            int clickX = customGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
            int mouseX = customGrid.PointToClient(Cursor.Position).X;
            int relativeX = mouseX - clickX;

            // Identify which icon was clicked
            if (relativeX >= 0 && relativeX < 30)
            {
                EditRow(customGrid.Rows[e.RowIndex]);
            }
            else if (relativeX >= 40 && relativeX < 70)
            {
                ViewRow(customGrid.Rows[e.RowIndex]);
            }
            else if (relativeX >= 80 && relativeX < 110)
            {
                DeleteRow(customGrid, e.RowIndex);
            }
        }

        // **Functions to Perform Actions**
        private void EditRow(DataGridViewRow row)
        {
            MessageBox.Show($"Edit clicked for row {row.Index}");
            // Add edit logic here
        }

        private void ViewRow(DataGridViewRow row)
        {
            MessageBox.Show($"View clicked for row {row.Index}");
            // Add view logic here
        }

        private void DeleteRow(DataGridView grid, int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                grid.Rows.RemoveAt(rowIndex);
                MessageBox.Show($"Row {rowIndex} deleted.");
            }
        }

        private void LoadData() // load viewing data 
        {
            var data = CourseRepo.GetCourses();
            customGrid.DataSource = data;
        }
    }
}
