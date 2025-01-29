using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.AdminDashboard
{
    public partial class Tracks : Form1
    {
        public Tracks(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            InitializeComponent();
        }
    }
}
