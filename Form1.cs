using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillEllipse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var rect = new Rectangle(10, 10, 300, 200);

            var canvas = e.Graphics;
            canvas.DrawEllipse(Pens.Black, rect);
        }
    }
}
