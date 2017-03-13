using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock
{
    class Hands
    {
        float length; // depends on size of circle

        public Hands(float scale = 0.75f)
        {
            Scale = scale;
        }

        public float Scale { get; set; }

        public void Draw(Graphics g, Rectangle bounds)
        {
            //get width length and height
            int width = bounds.Width;
            int height = bounds.Height;
            int length = (int)(Math.Min(width, height) * Scale);

            //get center coordinates
            int heightCenter = bounds.X / 2;
            int widthCenter = bounds.Y / 2;

            //current time
            int timeNow = DateTime.Now.Second;

            int[] handCoord = new int[2];
            timeNow *= 6; //each minute and second makes a 6 degree movement

            if (timeNow >= 0 && timeNow <= 180)
            {
                handCoord[0] = heightCenter + (int)(length * Math.Sin(Math.PI * timeNow / 180));
                handCoord[1] = widthCenter - (int)(length * Math.Cos(Math.PI * timeNow / 180));
            }
            else
            {
                handCoord[0] = widthCenter - (int)(length * Math.Sin(Math.PI * timeNow / 180));
                handCoord[1] = heightCenter - (int)(length * Math.Cos(Math.PI * timeNow / 180));
            }

            g.DrawLine(new Pen(Color.Black, 2f), heightCenter, widthCenter, handCoord[0], handCoord[1]);
        }

         

    }
}
