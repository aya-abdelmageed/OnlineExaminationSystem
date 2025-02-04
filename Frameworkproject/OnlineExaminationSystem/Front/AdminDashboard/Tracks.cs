using BusinessLogi.DTO;
using BusinessLogi.Repositories;
using BusinessLogic.Repositories;
using Front.popUpForms;
using Nest;
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
    public partial class Tracks : Form1
    {
        private TrackRepo track;
        private DataGridView customGrid;
        private Button addbutton;
        private TextBox customSearch;
        public Tracks(int _mode)
        {
            track = new TrackRepo();

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

            // **Handle Click Events with Dynamic Detection**

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
                    customSearch.Text = "Search by ID, or Location...";
                    customSearch.ForeColor = Color.Gray;
                    LoadData();

                }
            };

            customSearch.TextChanged += (s, e) => SearchTracks(customSearch.Text);


        }
        //-------------------------------------------------------------------------------------
        private void SearchTracks(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                LoadData();
                return;
            }

            int? trackId = null;
            if (int.TryParse(searchText, out int parsedId))
            {
                trackId = parsedId;
                customGrid.DataSource = track.GetTracks(trackId); 
                return;
            }

            var byName = track.SearchTrackByName(searchText);

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

        // *Functions to Perform Actions*
        private void EditRow(DataGridViewRow row)
        {
            TrackDTO track = new TrackDTO
            {
                TrackID = Convert.ToInt32(row.Cells["TrackID"].Value),
                Name = row.Cells["Name"].Value.ToString(),
                Department = row.Cells["Department"].Value.ToString()
            };

            var Form = new TrackForm((int)FormMode.Edit,track,customGrid);

            Form.Show();
        }

        private void ViewRow(DataGridViewRow row)
        {
            TrackDTO track = new TrackDTO
            {
                TrackID = Convert.ToInt32(row.Cells["TrackID"].Value),
                Name = row.Cells["Name"].Value.ToString(),
                Department = row.Cells["Department"].Value.ToString()
            };

            var Form = new TrackForm((int)FormMode.View,track, customGrid);

            Form.Show();
        }

        private void DeleteRow(DataGridView grid, int rowIndex)
        {
            int TrackID = Convert.ToInt32(grid.Rows[rowIndex].Cells["TrackID"].Value);
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this row?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    track.DeleteTrack(TrackID);

                    BindingList<TrackDTO> tracks = new BindingList<TrackDTO>(track.GetTracks(null));
                    customGrid.DataSource = tracks;
                }
            }
            catch
            {
                MessageBox.Show("Sorry, you can't delete this row because it has dependent relationships.", "Failed");
            }

        }

        private void LoadData() // load viewing data 
        {

            var data = track.GetTracks(null);   

            customGrid.DataSource = data;
            customGrid.Refresh();
        }



    }
}