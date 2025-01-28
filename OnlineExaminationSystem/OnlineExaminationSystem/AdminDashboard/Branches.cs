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


namespace UI.AdminDashboard
{
    public partial class Branches : Form1
    {

        private readonly InstructorRepo _instructorRepo;

        public Branches() : base()
        {
            InitializeComponent();
        }

        private void Branches_Load(object sender, EventArgs e)
        {

        }
    }
}
