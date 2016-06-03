using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace howto_binary_tree
{
    public partial class DrawTreeForm : Form
    {
        public DrawTreeForm()
        {
            InitializeComponent();
        }

        // Draw the tree.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Recursively draw a binary tree branch.
        private void DrawBranch(Graphics gr, Pen pen, int depth, float x, float y,
            float length, float theta, float length_scale, float dtheta)
        {
            // See where this branch should end.
            float x1 = (float)(x + length * Math.Cos(theta));
            float y1 = (float)(y + length * Math.Sin(theta));

            gr.DrawLine(pen, x, y, x1, y1);

            // If depth > 1, draw the attached branches.
            if (depth > 1)
            {
                DrawBranch(gr, pen, depth - 1, x1, y1,
                    length * length_scale, theta + dtheta, length_scale,
                    dtheta);
                DrawBranch(gr, pen, depth - 1, x1, y1,
                    length * length_scale, theta - dtheta, length_scale,
                    dtheta);
            }
        }

        // Draw the tree.
        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(picCanvas.BackColor);
            e.Graphics.SmoothingMode=System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            try
            {
                float root_x = picCanvas.ClientSize.Width / 2;
                float root_y = picCanvas.ClientSize.Height - 4;
                float length_scale = float.Parse(txtLengthScale.Text);
                float dtheta = (float)(Math.PI / 180.0 * (double)nudDtheta.Value);
                DrawBranch(e.Graphics, Pens.Green,
                    (int)nudDepth.Value, root_x, root_y,
                    (int)nudLength.Value, (float)(-Math.PI / 2), length_scale,
                    dtheta);
            }
            catch
            {
            }
        }

        // Redraw.
        private void parameter_ValueChanged(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }

        // Redraw.
        private void picCanvas_Resize(object sender, EventArgs e)
        {
            picCanvas.Refresh();
        }

        // Redraw.
        private void nud_KeyUp(object sender, KeyEventArgs e)
        {
            picCanvas.Refresh();
        }
    }
}
