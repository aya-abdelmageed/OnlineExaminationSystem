using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using DataAccess;

namespace UI.AdminDashboard
{
    public partial class Form1 : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public Form1(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        private void ShowForm<T>() where T : Form
        {
            var form = _serviceProvider.GetRequiredService<T>();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Size = new Size(1324, 657);
            form.Show();
            this.Close();
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
        }

        private void Branches_Click(object sender, EventArgs e)
        {

            ShowForm<Branches>();

        }

        private void Tracks_Click(object sender, EventArgs e)
        {
        }

        private void Courses_Click(object sender, EventArgs e)
        {
        }

        private void Instructors_Click(object sender, EventArgs e)
        {
        }

        private void Students_Click(object sender, EventArgs e)
        {
        }

        private void Reports_Click(object sender, EventArgs e)
        {
        }
    }
}