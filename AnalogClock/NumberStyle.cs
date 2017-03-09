using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace AnalogClock
{
    class NumberStyle    {
        Font fond;
        float distance;
        [Flags]
        public enum MyNumbers        {
            Twelve = 1,
            Three = 3,
            Six = 6,
            Nine = 9
        }
    }
}
