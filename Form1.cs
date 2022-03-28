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

            using (var path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                using (var region = new Region(path))
                {
                    canvas.FillRegion(Brushes.Red, region);
                }
            }
        }
    }
}
