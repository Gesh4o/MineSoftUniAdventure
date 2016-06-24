namespace howto_binary_tree
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class DrawTreeForm : Form
    {
        public DrawTreeForm()
        {
            this.InitializeComponent();
        }

        // Draw the tree.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        // Recursively draw a binary tree branch.
        private void DrawBranch(
            Graphics gr,
            Pen pen,
            int depth,
            float x,
            float y,
            float length,
            float theta,
            float length_scale,
            float dtheta)
        {

            // See where this branch should end.
            float x1 = (float)(x + (length * Math.Cos(theta)));
            float y1 = (float)(y + (length * Math.Sin(theta)));

            gr.DrawLine(pen, x, y, x1, y1);

            // If depth > 1, draw the attached branches.
            if (depth > 1)
            {
                this.DrawBranch(gr, pen, depth - 1, x1, y1, length * length_scale, theta + dtheta, length_scale, dtheta);
                this.DrawBranch(gr, pen, depth - 1, x1, y1, length * length_scale, theta - dtheta, length_scale, dtheta);
            }
        }

        // Draw the tree.
        private void PicCanvasPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.PicCanvas.BackColor);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            try
            {
                float root_x = this.PicCanvas.ClientSize.Width / 2;
                float root_y = this.PicCanvas.ClientSize.Height - 4;
                float length_scale = float.Parse(txtLengthScale.Text);
                float dtheta = (float)(Math.PI / 180.0 * (double)nudDtheta.Value);
                this.DrawBranch(
                    e.Graphics,
                    Pens.Green,
                    (int)nudDepth.Value,
                    root_x,
                    root_y,
                    (int)nudLength.Value,
                    (float)(-Math.PI / 2),
                    length_scale,
                    dtheta);
            }
            catch
            {
                // ignored
            }
        }

        // Redraw.
        private void ParameterValueChanged(object sender, EventArgs e)
        {
            this.PicCanvas.Refresh();
        }

        // Redraw.
        private void PicCanvasResize(object sender, EventArgs e)
        {
            this.PicCanvas.Refresh();
        }

        // Redraw.
        private void NudKeyUp(object sender, KeyEventArgs e)
        {
            this.PicCanvas.Refresh();
        }
    }
}
