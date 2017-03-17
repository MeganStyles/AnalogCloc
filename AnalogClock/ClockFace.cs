using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock
{
    /// <summary>
    /// Represents the clock face.
    /// </summary>
    internal class ClockFace   {

        private const int HOUR_HAND = 0;
        private const int MINUTE_HAND = 1;
        private const int SECOND_HAND = 2;
       
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="scale">The scale of the clock face as a fraction of the form size. (Optional - the default is 0.75)</param>
        public ClockFace(float scale = 0.75f)  {
            Scale = scale;
            HandsArray = new[]  {
                new Hands(TimeUnit.Hour, 5, 0.55f),
                new Hands(TimeUnit.Minute, 3, 0.65f),
                new Hands(TimeUnit.Second, 1, 0.85f)
            };
        }

        /// <summary>
        /// Gets a reference to the clock hands array.
        /// </summary>
        private Hands[] HandsArray { get;  }

        /// <summary>
        /// Gets or sets the clock face size as a fraction of the form size. (Optional - the default is 0.75)
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// Draws the clock face to the given <paramref name ="graphics"/> reference, within the specified <paramref name="bounds"/>
        /// </summary>
        /// <param name="graphics">A reference to the target graphics device.</param>
        /// <param name="bounds">The bounds within which to draw.</param>
        public void Draw(Graphics graphics, Rectangle bounds)  {

            //get width, height and square length.
            int width = bounds.Width;
            int height = bounds.Height;
            int length = (int)(Math.Min(width,height) * Scale);

            //get the middle
            Point middle = new Point(bounds.X + (width / 2), bounds.Y + (height / 2));

            //build the shape
            Rectangle square = new Rectangle(middle.X - (length / 2), middle.Y - (length / 2), length, length);

            //draw the face
            graphics.FillEllipse(Brushes.White, square);

            //draw the hands.
            TimeSpan time = DateTime.Now - DateTime.Today;
            for (int n = 0; n < HandsArray.Length; n++)  {
                double value = 0.0;
                switch (n)  {
                    case HOUR_HAND:
                        value = time.TotalHours;
                        break;
                    case MINUTE_HAND:
                        value = time.TotalMinutes;
                        break;
                    case SECOND_HAND:
                        value = time.TotalSeconds;
                        break;
                }
                HandsArray[n].Draw(graphics, square, value);
            }
        }
    }
}
