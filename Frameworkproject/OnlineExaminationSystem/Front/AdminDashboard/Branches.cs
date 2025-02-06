
using BusinessLogi.Repositories;
using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using BusinessLogic.Repositories;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.ComponentModel;
using System.Drawing;
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
        private TextBox searchBox;


        public Branches()
        {
            branch = new BranchRepo();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.ClientSize = new Size(1324, 600);

            // Initialize UI elements
            customGrid = InitializeCustomGrid();
            addbutton = GenerateCustomButton();
            searchBox = GenerateSearchBox();

            // Add UI elements to form
            this.Controls.Add(addbutton);
            this.Controls.Add(searchBox);
            this.Controls.Add(customGrid);



            addbutton.Text = "Add Branch";
            addbutton.Click += (s, e) =>
            {
                var newForm = new BranchForm((int)FormMode.Add, null, customGrid);
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

        private TextBox GenerateSearchBox()
        {
            TextBox searchBox = new TextBox
            {
                Location = new Point(addbutton.Location.X - 680, addbutton.Location.Y + 4),
                Size = new Size(650, 100)
            };

            // Placeholder text workaround
            searchBox.Text = "Search by ID, Name, or Location...";
            searchBox.ForeColor = Color.Gray;

            searchBox.GotFocus += (s, e) =>
            {
                if (searchBox.Text == "Search by ID, Name, or Location...")
                {
                    searchBox.Text = "";
                    searchBox.ForeColor = Color.Black;
                }
            };

            searchBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchBox.Text))
                {
                    searchBox.Text = "Search by ID, Name, or Location...";
                    searchBox.ForeColor = Color.Gray;
                }
            };

            searchBox.TextChanged += (s, e) => SearchBranches(searchBox.Text);
            return searchBox;


        }

        private void SearchBranches(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadData();
                return;
            }

            int? branchId = null;
            if (int.TryParse(searchText, out int parsedId))
            {
                branchId = parsedId;
                customGrid.DataSource = branch.GetBranches(branchId);
                return;
            }

            var byName = branch.SearchBranchByName(searchText);
            var byLocation = branch.SearchBranchByLocation(searchText);


            var combinedResults = byName.Concat(byLocation).Distinct().ToList();
            customGrid.DataSource = combinedResults;
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

            }
            else if (e.ColumnIndex == customGrid.Columns["DeleteAction"].Index)
            {
                Console.WriteLine("Delete icon clicked!"); // Debugging
                DeleteRow(customGrid, e.RowIndex);

            }
        }
        private void EditRow(DataGridViewRow row)
        {
            var branchDTO = new BranchDTO
            {
                BranchID = Convert.ToInt32(row.Cells["BranchID"].Value),
                Name = row.Cells["Name"].Value.ToString(),
                Location = row.Cells["Location"].Value.ToString(),
                Phone = row.Cells["Phone"].Value.ToString()
            };
            var Form = new BranchForm((int)FormMode.Edit, branchDTO, customGrid);
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


            try
            {
                if (MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    branch.DeleteBranch(branchID);
                    BindingList<BranchDTO> branches = new BindingList<BranchDTO>(branch.GetBranches(null));
                    customGrid.DataSource = branches;
                }

            }
            catch
            {

                MessageBox.Show("Sorry, you can't delete this row because it has dependent relationships.", "Failed");


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

