using BusinessLogi.Repositories;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

            LoadData();
            AddActions(customGrid);
            customGrid.CellClick += (s, e) => HandleActionClick(customGrid, e);
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

        private void HandleActionClick(DataGridView customGrid, DataGridViewCellEventArgs e)
        {
            if (customGrid.Columns[e.ColumnIndex].Name != "Actions" || e.RowIndex < 0)
                return;

            int clickX = customGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).X;
            int mouseX = customGrid.PointToClient(Cursor.Position).X;
            int relativeX = mouseX - clickX;

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

        private void EditRow(DataGridViewRow row)
        {
            var Form = new BranchForm();
            Form.Show();
            MessageBox.Show($"Edit clicked for row {row.Index}");
        }

        private void ViewRow(DataGridViewRow row)
        {
            MessageBox.Show($"View clicked for row {row.Index}");
        }

        private void DeleteRow(DataGridView grid, int rowIndex)
        {
            if (MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                grid.Rows.RemoveAt(rowIndex);
                MessageBox.Show($"Row {rowIndex} deleted.");
            }
        }

        private void LoadData()
        {
            var data = branch.GetBranches(null);
            customGrid.DataSource = data;
        }
    }
}
