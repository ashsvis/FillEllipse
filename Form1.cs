using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FillEllipse
{
    public partial class Form1 : Form
    {
        private int level;

        public Form1()
        {
            InitializeComponent();
            level = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var offset = 10;
            var width = 300;
            var heigh = 200;
            var rect = new Rectangle(offset, 10, width, heigh);
            var canvas = e.Graphics;
            canvas.DrawEllipse(Pens.Black, rect);
            var fillRect = new Rectangle(offset, 10 + heigh - level, width, heigh);
            using (var path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                using (var ellipseRegion = new Region(path))
                {
                    ellipseRegion.Intersect(fillRect);
                    canvas.FillRegion(Brushes.Red, ellipseRegion);
                }
            }
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (level < 200)
            {
                level++;
                Invalidate();
            }
        }
    }
}
