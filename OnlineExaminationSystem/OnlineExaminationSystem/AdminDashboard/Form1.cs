using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using DataAccess;

namespace UI.AdminDashboard
{
    public partial class Form1 : Form
    {

        public Form1() 
        {
            InitializeComponent();
        }

        private void ShowFormAndCloseCurrent(Form newForm)
        {
            newForm.StartPosition = FormStartPosition.Manual;
            newForm.Location = this.Location;
            newForm.Size = new Size(1324, 657);

            newForm.Show();

            this.Close();
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            ShowFormAndCloseCurrent(new Dashboard());
        }

        private void Branches_Click(object sender, EventArgs e)
        {


            ShowFormAndCloseCurrent(new Branches());
        }

        private void Tracks_Click(object sender, EventArgs e)
        {
            ShowFormAndCloseCurrent(new Tracks());
        }

        private void Courses_Click(object sender, EventArgs e)
        {
            ShowFormAndCloseCurrent(new Courses());
        }

        private void Instructors_Click(object sender, EventArgs e)
        {
            ShowFormAndCloseCurrent(new Instructors());
        }

        private void Students_Click(object sender, EventArgs e)
        {
            ShowFormAndCloseCurrent(new Students());
        }

        private void Reports_Click(object sender, EventArgs e)
        {
            ShowFormAndCloseCurrent(new Reports());
        }
    }
}