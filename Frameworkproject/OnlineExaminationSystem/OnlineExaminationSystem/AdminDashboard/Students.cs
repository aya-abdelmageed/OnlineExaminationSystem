﻿using System;
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
    public partial class Students : Form1
    {
        public Students(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            InitializeComponent();
        }
    }
}
