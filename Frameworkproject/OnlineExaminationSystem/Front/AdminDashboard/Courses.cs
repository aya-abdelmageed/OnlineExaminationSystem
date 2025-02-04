using BusinessLogi.DTO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace UI.AdminDashboard
{
    public partial class Courses : Form1
    {
        private CourseRepo CourseRepo;
        private DataGridView customGrid;
        private Button addbutton;
        private TextBox customSearch;

        public Courses()
        {

            CourseRepo = new CourseRepo();

            //this.AutoScaleMode = AutoScaleMode.Dpi;
            //this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 600); // Set exact size (same as in the Designer
            customGrid = InitializeCustomGrid();
            customSearch = GenerateCustomSearch();
            addbutton = GenerateCustomButton();
            addbutton.Text = "Add Track";
            addbutton.Click += (s, e) =>
            {
                var newForm = new TrackForm((int)FormMode.Add, data: customGrid);


                newForm.Show();

            };
            LoadData();
            AddActions(customGrid);
            // Handle Click Events with Dynamic Detection
            customGrid.CellMouseClick += (s, e) =>
            {
                HandleActionClick(customGrid, e);
            };

            // Placeholder text workaround
            customSearch.Text = "Search by ID, or Name...";
            customSearch.ForeColor = Color.Gray;

            customSearch.GotFocus += (s, e) =>
            {
                if (customSearch.Text == "Search by ID, or Name...")
                {
                    customSearch.Text = "";
                    customSearch.ForeColor = Color.Black;
                }
            };

            customSearch.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(customSearch.Text))
                {
                    customSearch.Text = "Search by ID, or Name...";
                    customSearch.ForeColor = Color.Gray;
                    LoadData();

                }
            };

            customSearch.TextChanged += (s, e) => SearchCourses(customSearch.Text);
        }

        private void SearchCourses(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadData();
                return;
            }

            int? courseId = null;

            if (int.TryParse(searchText, out int parsedId))
            {
                courseId = parsedId;
                var data = CourseRepo.GetCourses(courseId);

                if (data == null || data.Count == 0)
                {
                    MessageBox.Show("No courses found for the provided Course ID.", "Search Result");
                    customGrid.DataSource = null;
                    return;
                }

                customGrid.DataSource = data;
                return;
            }

            var byName = CourseRepo.SearchCourseByName(searchText);
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
            CourseDTO course = new CourseDTO
            {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                Name = row.Cells["Name"].Value.ToString()
            };
            var Form = new CoursesForm((int)FormMode.Edit,course,customGrid);
            Form.Show();

            // Add edit logic here
        }

        private void ViewRow(DataGridViewRow row)
        {
            CourseDTO course = new CourseDTO
            {
                ID = Convert.ToInt32(row.Cells["ID"].Value),
                Name = row.Cells["Name"].Value.ToString()
            };
            var Form = new CoursesForm((int)FormMode.View, course, customGrid);
            Form.Show();
        }

        private void DeleteRow(DataGridView grid, int rowIndex)
        {
            int courseID = Convert.ToInt32(grid.Rows[rowIndex].Cells["ID"].Value);
           
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    CourseRepo.DeleteCourses(courseID);
                    BindingList<CourseDTO> courses = new BindingList<CourseDTO>(CourseRepo.GetCourses(null));
                    customGrid.DataSource = courses;
                }
            }
            catch
            {
                    MessageBox.Show("Sorry, you can't delete this row because it has dependent relationships.", "Failed");

               
            }
        }

        private void LoadData() // load viewing data 
        {
            var data = CourseRepo.GetCourses(null);
            customGrid.DataSource = data;
            customGrid.Refresh();
        }
    }
}
