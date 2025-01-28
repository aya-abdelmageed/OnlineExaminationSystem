using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.AdminDashboard
{
    public partial class Dashboard : Form1
    {
        public Dashboard()
        {
            InitializeComponent();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rounded rectangle for panel2
            DrawRoundedPanelBorder(e, panel2, 20, Color.Black, 2);
        }

        private void DrawRoundedPanelBorder(PaintEventArgs e, Panel panel, int radius, Color borderColor, int borderWidth)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle panelRect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            using (GraphicsPath path = GetRoundedRectanglePath(panelRect, radius))
            {
                // Fill the panel background
                using (Brush brush = new SolidBrush(panel.BackColor))
                {
                    graphics.FillPath(brush, path);
                }

                // Draw the border
                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    graphics.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Top-left arc
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);

            // Top-right arc
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);

            // Bottom-right arc
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);

            // Bottom-left arc
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);

            // Close the path
            path.CloseFigure();
            return path;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel3, 20, Color.Black, 2);
        }




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel4, 20, Color.Black, 2);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            DrawRoundedPanelBorder(e, panel5, 20, Color.Black, 2);
        }
    }
}
