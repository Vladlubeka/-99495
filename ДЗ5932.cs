using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphPlotter
{
    public partial class Form1 : Form
    {
        private bool shouldDrawGraph = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDrawGraph_Click(object sender, EventArgs e)
        {
            shouldDrawGraph = true;
            pictureBox.Invalidate(); 
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (shouldDrawGraph)
            {
                Graphics g = e.Graphics;
                g.Clear(Color.White);

                Pen axisPen = new Pen(Color.Black, 2);
                g.DrawLine(axisPen, 0, pictureBox.Height / 2, pictureBox.Width, pictureBox.Height / 2); 
                g.DrawLine(axisPen, pictureBox.Width / 2, 0, pictureBox.Width / 2, pictureBox.Height); 

                Pen functionPen = new Pen(Color.Blue, 2);
                for (int x = -pictureBox.Width / 2; x < pictureBox.Width / 2; x++)
                {
                    int y = x; 
                    int screenX = x + pictureBox.Width / 2;
                    int screenY = -y + pictureBox.Height / 2;
                    if (screenX >= 0 && screenX < pictureBox.Width && screenY >= 0 && screenY < pictureBox.Height)
                    {
                        g.DrawEllipse(functionPen, screenX, screenY, 1, 1); 
                    }
                }
            }
        }
    }
}