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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace UI.AdminDashboard
{
    public partial class Instructors : Form1
    {
        private InstructorRepo instructorRepo;
        private DataGridView customGrid;
        private Button addbutton;
        private TextBox customSearch;

        public Instructors ()
        {

            instructorRepo = new InstructorRepo();

            //this.AutoScaleMode = AutoScaleMode.Dpi;
            //this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 600); // Set exact size (same as in the Designer
            customGrid = InitializeCustomGrid();
            customSearch = GenerateCustomSearch();
            addbutton = GenerateCustomButton();
            addbutton.Text = "Add Instructor";
            addbutton.Click += (s, e) =>
            {
                var newForm = new TrackForm((int)FormMode.Add, data: customGrid);


                newForm.Show();

            };
            LoadData();
            AddActions(customGrid);

            // **Handle Click Events with Dynamic Detection**

            // Handle Click Events with Dynamic Detection
            customGrid.CellMouseClick += (s, e) =>
            {
                HandleActionClick(customGrid, e);
            };

            // Placeholder text workaround
            customSearch.Text = "Search by ID, or First Name...";
            customSearch.ForeColor = Color.Gray;

            customSearch.GotFocus += (s, e) =>
            {
                if (customSearch.Text == "Search by ID, or First Name...")
                {
                    customSearch.Text = "";
                    customSearch.ForeColor = Color.Black;
                }
            };

            customSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(customSearch.Text))
                {
                    customSearch.Text = "Search by ID, or First Name...";
                    customSearch.ForeColor = Color.Gray;
                    LoadData();

                }
            };

            customSearch.TextChanged += (s, e) => SearchInstructors(customSearch.Text);

        }

        private void SearchInstructors(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadData();
                return;
            }

            int? instructorId = null;
            if (int.TryParse(searchText, out int parsedId))
            {
                instructorId = parsedId;
                customGrid.DataSource = instructorRepo.GetInstructors(instructorId);
                return;
            }

            var byName = instructorRepo.SearchInstructorByName(searchText);

            customGrid.DataSource = byName;
            customGrid.Refresh();
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

                    BindingList<InstructorDTO> instructors = new BindingList<InstructorDTO>(instructorRepo.GetInstructors(null));
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
            var data = instructorRepo.GetInstructors(null);
            customGrid.DataSource = data;
            customGrid.Refresh();
        }


    }
}
