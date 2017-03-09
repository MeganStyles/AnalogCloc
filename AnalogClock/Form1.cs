using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogClock
{
    public partial class MainForm : Form
    {
        int SecHand = 140;
        int minHand = 110;
        int centerWidth;
        int centerHeight;
        int[] handCoordMin;
        Hands hands;

        public MainForm()
        {
            centerWidth = Size.Width / 2;
            centerHeight = Size.Height / 2;
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            ClockFaceClass clockFace = new ClockFaceClass(Center());
            handCoordMin = HandCoordinates(DateTime.Now.Second, SecHand);
            hands = new Hands(Center(), new Point(handCoordMin[0], handCoordMin[1]));

        }

        private void Tick(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.DrawEllipse(new Pen(Color.Black),Size.Width,Size.Height,Size.Width,Size.Height);

            hands.Initialize(g);
            //g.DrawLine(new Pen(Color.Black),Center(), new Point(handCoordMin[0],handCoordMin[1]));
        }

        public Point Center()
        {
            int heightCenter = Size.Height / 2;
            int widthCenter = Size.Width / 2;
            Point center = new Point(heightCenter, widthCenter);
            return center;
        }

        public int[] HandCoordinates(int timeNow, int minSecHand)
        {
            int[] handCoord = new int[2];
            timeNow *= 6; //each minute and second makes a 6 degree movement

            if (timeNow >= 0 && timeNow <= 180)
            {
                handCoord[0] = centerWidth + (int)(minSecHand * Math.Sin(Math.PI * timeNow / 180));
                handCoord[1] = centerHeight - (int)(minSecHand * Math.Cos(Math.PI * timeNow / 180));
            }
            else
            {
                handCoord[0] = centerWidth - (int)(minSecHand * Math.Sin(Math.PI * timeNow / 180));
                handCoord[1] = centerHeight - (int)(minSecHand * Math.Cos(Math.PI * timeNow / 180));
            }

            return handCoord;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
