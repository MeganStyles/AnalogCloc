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
        Point centerHand;
        Point outsideHand;
        float Length; // depends on size of circle

        public Hands(Point center, Point edge)        {
            centerHand = center;
            outsideHand = edge;
        }

        public void Initialize(Graphics g)  {
            g.DrawLine(new Pen(Color.Black, 2f), centerHand, outsideHand);
        }

        private void Draw(Graphics g) {

        }


    }
}
