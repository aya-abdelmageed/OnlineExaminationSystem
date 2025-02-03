using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using BusinessLogic.Repositories;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace UI.AdminDashboard
{

    public partial class Branches : Form1
    {
        private BranchRepo branch;
        private DataGridView customGrid;
        private Button addbutton;

        public Branches() 
         {

            branch = new BranchRepo();  
            //this.AutoScaleMode = AutoScaleMode.Dpi;
            //this.AutoScaleDimensions = new SizeF(96F, 96F); // Set it for 100% scaling
            this.ClientSize = new Size(1324, 600); // Set exact size (same as in the Designer
            customGrid = InitializeCustomGrid();
            GenerateCustomSearch();     
            addbutton = GenerateCustomButton();  
            addbutton.Text = "Add Branch";
            addbutton.Click += (s, e) =>
            {
                var newForm = new BranchForm((int)FormMode.Add, null,customGrid);
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
                Console.WriteLine("Edit icon clicked!"); // Debugging
                EditRow(customGrid.Rows[e.RowIndex]);
            }
            else if (e.ColumnIndex == customGrid.Columns["ViewAction"].Index)
            {
                Console.WriteLine("View icon clicked!"); // Debugging
                ViewRow(customGrid.Rows[e.RowIndex]);
 
            else if (e.ColumnIndex == customGrid.Columns["DeleteAction"].Index)

            {
                Console.WriteLine("Delete icon clicked!"); // Debugging
                DeleteRow(customGrid, e.RowIndex);
            }
        }

        // **Functions to Perform Actions**
        private void EditRow(DataGridViewRow row)
        {
            var branchDTO = new BranchDTO
            {
                BranchID = Convert.ToInt32(row.Cells["BranchID"].Value),
                Name = row.Cells["Name"].Value.ToString(),
                Location = row.Cells["Location"].Value.ToString(),
                Phone = row.Cells["Phone"].Value.ToString()
            };
            var Form = new BranchForm((int)FormMode.Edit,branchDTO, customGrid);
            Form.Show();
        }

        private void ViewRow(DataGridViewRow row)
        {
            var branchDTO = new BranchDTO
            {
                BranchID = Convert.ToInt32(row.Cells["BranchID"].Value),
                Name = row.Cells["Name"].Value.ToString(),
                Location = row.Cells["Location"].Value.ToString(),
                Phone = row.Cells["Phone"].Value.ToString()
            };
            var Form = new BranchForm((int)FormMode.View, branchDTO, customGrid);
            Form.Show();
        }

        private void DeleteRow(DataGridView grid, int rowIndex)
        {
            int branchID = Convert.ToInt32(grid.Rows[rowIndex].Cells["BranchID"].Value);
            branch.DeleteBranch(branchID);
            if (MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                BindingList<BranchDTO> branches = new BindingList<BranchDTO>(branch.GetBranches(null));
                customGrid.DataSource = branches;
            }
        }
      
        internal void LoadData() // load viewing data 
        {
           var data = branch.GetBranches(null);
           customGrid.DataSource = data;
            customGrid.Refresh();
        }
       
        }


    }

