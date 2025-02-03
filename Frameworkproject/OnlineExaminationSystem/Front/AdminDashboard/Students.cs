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
    public partial class Students : Form1
    {
        private StudentRepo studentRepo;
        private DataGridView customGrid;
        private Button addbutton;

        public Students()
        {
            studentRepo = new StudentRepo();    
            //this.AutoScaleMode = AutoScaleMode.Dpi;
            //this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 600); // Set exact size (same as in the Designer
            customGrid = InitializeCustomGrid();
            GenerateCustomSearch();
            addbutton = GenerateCustomButton();
            addbutton.Text = "Add Student";
            addbutton.Click += (s, e) =>
            {
                var newForm = new StudentesForm((int)FormMode.Add,data:customGrid);
                newForm.Show();

            };
            LoadData();
            AddActions(customGrid);
            customGrid.CellMouseClick += (s, e) => { HandleActionClick(customGrid, e); };



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
            StudentDTO studentDTO = new StudentDTO
            {
                StudentID = (int)row.Cells["StudentID"].Value,
                trackID = (int)row.Cells["TrackID"].Value,
                FName = (string)row.Cells["FName"].Value,
                MName = (string)row.Cells["MName"].Value,
                LName = (string)row.Cells["LName"].Value,
                Birthdate = (DateTime)row.Cells["Birthdate"].Value,
                Gender = (string)row.Cells["Gender"].Value,
                Phone = (string)row.Cells["Phone"].Value
            };
            var Form = new  StudentesForm((int)FormMode.Edit,studentDTO,customGrid) ;
            Form.Show();
        }

        private void ViewRow(DataGridViewRow row)
        {
            StudentDTO studentDTO = (StudentDTO)row.DataBoundItem;
            var Form = new StudentesForm((int)FormMode.View, studentDTO, customGrid);
            Form.Show();
        }

        private void DeleteRow(DataGridView grid, int rowIndex)
        {
            int id = (int)grid.Rows[rowIndex].Cells["StudentID"].Value;
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    studentRepo.DeleteStudent(id);
                    BindingList<StudentDTO> students = new BindingList<StudentDTO>(studentRepo.GetStudents(null));
                    customGrid.DataSource = students;
                }
            }catch { MessageBox.Show("Sorry, you can't delete this row because it has dependent relationships.", "Failed"); }
           
        }

        private void LoadData() // load viewing data 
        {
            var data = studentRepo.GetStudents(null);
            customGrid.DataSource = data;
        }
    }
}
