using BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using AutoMapper;
using BusinessLogic.Repositories;
using System.Data;

using System.Data.SqlClient;
using System.Windows.Forms;
using BusinessLogi.Repositories;
using DataAccess;
using Microsoft.Extensions.Configuration;
using BusinessLogi.DTO;


namespace UI.AdminDashboard
{
    public partial class Branches : Form1
    {
        private BranchRepo _branchesRepository;
        private DataGridView dataGridView1;
        public Branches() : base()
        {
            InitializeComponent();
            var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            // Create DBManager and pass it to the repository
            DBManager dbManager = new DBManager(config);
            _branchesRepository = new BranchRepo(dbManager);

            // Initialize and configure DataGridView
            dataGridView1 = new DataGridView
            {
                Dock = DockStyle.Fill, // Fill the entire form
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true, // Read-only mode
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };

            // Add DataGridView to the form
            this.Controls.Add(dataGridView1);
        }

        private void Branches_Load(object sender, EventArgs e)
        {
            BranchDTO branch = new BranchDTO
            {
                Name = "Branch 2",
                Location = "Location 2",
                Phone = "123456780"
            };
            //Console.WriteLine(_branchesRepository.InsertBranch(branch));
            //var branches = _branchesRepository.UpdateBranch(branch);
            //_branchesRepository.DeleteBranch(" Branch_Name = ''F'' ");
            var branches = _branchesRepository.GetBranches();

            dataGridView1.DataSource = branches;
            
        }
    }
}
