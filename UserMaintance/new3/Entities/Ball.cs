using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace new3.Entities
{
    internal class Ball:Label
    {
        public Ball()
        {
            AutoSize = false;
            Height = 50;
            Width = 50;
            Paint += Ball_Paint;
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            //throw new NotImplementedException();
            DrawImage(e.Graphics);
        }
        public void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }
       public void MoveBall()
        {
            Left = -1;
        }
    }
}
