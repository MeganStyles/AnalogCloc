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
        
         
        Hands hands;
        ClockFace clockFace;
        

        public MainForm()
        {
            
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            clockFace = new ClockFace();
            hands = new Hands();
            Paint += MainForm_Paint;
            

        }

        private void Tick(object sender, EventArgs e)
        {
           // Graphics g = CreateGraphics();
            
            
            
        }


        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            clockFace.Draw(e.Graphics, e.ClipRectangle);
            hands.Draw(e.Graphics, e.ClipRectangle);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        
    }
}
