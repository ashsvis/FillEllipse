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
            var trianglePoints = new Point[] { new Point(rect.X, rect.Y),
                                               new Point(rect.X + rect.Width, rect.Y + rect.Height / 2),
                                               new Point(rect.X + rect.Width / 3, rect.Y + rect.Height)
                                             };
            canvas.DrawPolygon(Pens.Black, trianglePoints);
            //canvas.DrawEllipse(Pens.Black, rect);
            var fillRect = new Rectangle(offset, 10 + heigh - level, width, heigh);
            using (var path = new GraphicsPath())
            {
                path.AddPolygon(trianglePoints);
                //path.AddEllipse(rect);
                using (var region = new Region(path))
                {
                    region.Intersect(fillRect);
                    canvas.FillRegion(Brushes.Red, region);
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
