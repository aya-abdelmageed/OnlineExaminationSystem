using BusinessLogic.DTO;
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
    public partial class Instructors : Form1
    {
        private InstructorRepo instructorRepo;
        private DataGridView customGrid;
        private Button addbutton;

        public Instructors ()
        {

            instructorRepo = new InstructorRepo();

            //this.AutoScaleMode = AutoScaleMode.Dpi;
            //this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 600); // Set exact size (same as in the Designer
            customGrid = InitializeCustomGrid();
            GenerateCustomSearch();
            addbutton = GenerateCustomButton();
            addbutton.Text = "Add Instructor";
            addbutton.Click += (s, e) =>
            {
                var newForm = new InstructorForm((int)FormMode.Add,data:customGrid);
                newForm.Show();
            };
            LoadData();
            AddActions(customGrid);
            // Handle Click Events with Dynamic Detection
            customGrid.CellMouseClick += (s, e) =>
            {
                HandleActionClick(customGrid, e);
            };
        }


        private void HandleActionClick(DataGridView customGrid, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == customGrid.Columns["EditAction"].Index)
            {
                EditRow(customGrid.Rows[e.RowIndex]);
            }
            else if (e.ColumnIndex == customGrid.Columns["ViewAction"].Index)
            {
                ViewRow(customGrid.Rows[e.RowIndex]);
            }
            else if (e.ColumnIndex == customGrid.Columns["DeleteAction"].Index)
            {
                DeleteRow(customGrid, e.RowIndex);
            }
        }

        // **Functions to Perform Actions**
        private void EditRow(DataGridViewRow row)
        {
            InstructorDTO instructor = new InstructorDTO
            {
                age = (int)row.Cells["Age"].Value,
                Email = (string)row.Cells["Email"].Value,
                FirstName = (string)row.Cells["FirstName"].Value,
                Gender = (string)row.Cells["Gender"].Value,
                InstructorId = (int)row.Cells["InstructorID"].Value,
                LastName = (string)row.Cells["LastName"].Value,
                MName = (string)row.Cells["MName"].Value,
                Salary = (double)row.Cells["Salary"].Value,
            };
            var Form = new InstructorForm((int)FormMode.Edit,instructor,customGrid);
            Form.Show();
        }

        private void ViewRow(DataGridViewRow row)
        {
            InstructorDTO instructor = new InstructorDTO { 
                age = (int)row.Cells["Age"].Value,
                Email = (string)row.Cells["Email"].Value,
                FirstName = (string)row.Cells["FirstName"].Value,
                Gender = (string)row.Cells["Gender"].Value,
                InstructorId = (int)row.Cells["InstructorID"].Value,
                LastName = (string)row.Cells["LastName"].Value,
                MName = (string)row.Cells["MName"].Value,
                Salary = (double)row.Cells["Salary"].Value,
            };
            var Form = new InstructorForm((int)FormMode.View, instructor,customGrid);
            Form.Show();
        }

        private void DeleteRow(DataGridView grid, int rowIndex)
        {
            int ins_id = (int)grid.Rows[rowIndex].Cells["InstructorID"].Value;
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    instructorRepo.DeleteInstructor(ins_id);

                    BindingList<InstructorDTO> instructors = new BindingList<InstructorDTO>(instructorRepo.GetInstructors());
                    customGrid.DataSource = instructors;
                }
            }
            catch
            {
                MessageBox.Show("Sorry, you can't delete this row because it has dependent relationships.", "Failed");

            }

        }

        private void LoadData() // load viewing data 
        {
            var data = instructorRepo.GetInstructors();
            customGrid.DataSource = data;
        }


    }
}
