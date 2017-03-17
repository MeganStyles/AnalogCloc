using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock       {

    /// <summary>
    /// Represents a clock hand.
    /// </summary>
    internal class Hands {

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="unit">The time for this hand.</param>
        /// <param name="weight">The line thickness for this clock hand.</param>
        /// <param name="scale">The scale of the clock hand as a fraction of the clock face radius. (Optional - the default is 0.85)</param>
        public Hands(TimeUnit unit, int weight = 2, float scale = 0.75f) {
            Unit = unit;
            switch (unit) {
                case TimeUnit.Hour:
                    UnitSize = 12;
                    break;
                default:
                    UnitSize = 60;
                    break;
            }
            Weight = weight;
            Scale = scale;
        }

        /// <summary>
        /// Gets the time unit for the current<see cref="Hands"/> instance.
        /// </summary>
        public TimeUnit Unit { get; }

        /// <summary>
        /// Gets the size of a single rotation on the clock, for the current time unit.
        /// </summary>
        private int UnitSize { get; }

        /// <summary>
        /// Sets the line thickness for the clock hand.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the scale of the clock hand as a fraction of the clock face radius. (Optional - the default is 0.85)
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// draws the clock hand to the given <paramref name="graphics"/> reference, within the specified <paramref name="bounds"/>, at the indicated <paramref name="position"/>
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="bounds"></param>
        /// <param name="value"></param>
        public void Draw(Graphics graphics, Rectangle bounds, double value)  {

            // get the square size (radius of the clock face)
            double radius = Math.Min(bounds.Width, bounds.Height) / 2; 

            //calculate the angle
            double radians = CalculateAngle(value);

            //get the middle point
            PointF middle = new PointF(bounds.X + (float)radius, bounds.Y + (float)radius);

            //calculate hand end point
            PointF end = CalculateEndPoint(radius, radians, middle);

            //draw the hand
            using (Pen pen = new Pen(Color.Black, Weight))  {
                graphics.DrawLine(pen, middle, end);
            }
       }


        private double CalculateAngle( double value)       {
            //calculate fraction of a rotation (0.0 - 1.0)
            double position = (value % UnitSize) / UnitSize;
            //one rotation is 360 degrees
            double degrees = position * 360f;
            //degrees to radians
            return Math.PI * degrees / 180.0;
            
        }

        private PointF CalculateEndPoint( double bounds, double radians, PointF middle) {
            //calculate hands length
            double length = bounds * Scale;
            //calculate the endpoint coordinate offset
            double dX = length * Math.Sin(radians);
            double dY = length * -Math.Cos(radians);
            //get the point as an offset of the middle point
            return new PointF(middle.X + (float)dX, middle.Y + (float)dY);
        }

         

    }
}
