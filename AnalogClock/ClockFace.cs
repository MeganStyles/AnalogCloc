using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock
{
    internal class ClockFace   {
        //The center of the clock
       
        public ClockFace(float scale = 0.75f)  {
            Scale = scale;
        }

        public float Scale { get; set; }

        public void Draw(Graphics g, Rectangle bounds)  {
            //get width, height and length
            int width = bounds.Width;
            int height = bounds.Height;
            int length = (int)(Math.Min(width,height) * Scale) ;

            //get center coordinates
            int heightCenter = bounds.X / 2;
            int widthCenter = bounds.Y / 2;

            //build the shape
            Point position = new Point(0, 0);
            Size size = new Size(length, length);
            Rectangle square = new Rectangle(position, size);

            //draw the face
            g.FillEllipse(Brushes.White, square);
        }

         
        
    }
}
