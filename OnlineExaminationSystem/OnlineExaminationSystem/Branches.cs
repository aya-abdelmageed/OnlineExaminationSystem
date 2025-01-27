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


namespace UI
{
    public partial class Branches : Form1
    {

        private readonly InstructorRepo _instructorRepo; // InstructorRepo instance
        private DataGridView dataGridView1;              // DataGridView instance

        public Branches(InstructorRepo instructorRepo) : base( instructorRepo)
        {
            InitializeComponent();
            _instructorRepo = instructorRepo; // Store the injected InstructorRepo
            InitializeDataGridView();         // Initialize DataGridView in Form1

        }
        private void InitializeDataGridView()
        {
            dataGridView1 = new DataGridView();
            dataGridView1.Size = new System.Drawing.Size(958, 528);
            dataGridView1.Location = new System.Drawing.Point(286, 81);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dataGridView1);

        }
        //----





    }
}
