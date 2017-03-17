using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogClock       {
    /// <summary>
    /// The main program UI.
    /// </summary>
    public partial class MainForm : Form    {

        /// <summary>
        /// Buffered Graphics Context.
        /// </summary>
        /// <remarks>Ensures the screen doesn't flicker when we redraw.</remarks>
        private readonly BufferedGraphicsContext _GraphicsContext;

        /// <summary>
        /// The background graphics buffer.
        /// </summary>
        private BufferedGraphics _GraphicsBuffer;

        private bool _SuppressDrawing;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainForm(){

            Shown += MainForm_Show;
            Resize += MainForm_Resize;

            _GraphicsContext = BufferedGraphicsManager.Current;
            SetUpGraphicsBuffer();

            _SuppressDrawing = true;
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            _SuppressDrawing = false;

            _timer.tick += Timer_Tick;


            Clock = new ClockFace()            {
                DrawMinuteMarkers = true;

            }
            
            Text = "Megan's Time Machine";

           
        }
        /// <summary>
        /// Get's a reference to the clock face.
        /// </summary>
        private ClockFace Clock { get; }

        /// <summary>
        /// Occurs when the form is painted on screen.
        /// </summary>
        /// <param name="sender">The originator of the event.</param>
        /// <param name="e">The event argument.</param>
        

        private void MainForm_Load(object sender, EventArgs e)        {
            timer1.Tick += timer_Tick;
            timer1.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)    {
            DrawClock();
        }

        private void DrawClock() {
            if (_SuppressDrawing)            {
                return;
            }
            _SuppressDrawing = true;
            DrawToBuffer(_GraphicsBuffer.Graphics,ClientRectangle);
            _GraphicsBuffer.Render(Graphics.FromHwnd(Handle));
            _SuppressDrawing = false;
        }

        /// <summary>
        /// Sets up the graphics buffer.
        /// </summary>
        private void SetUpGraphicsBuffer()   {
            _GraphicsContext.MaximumBuffer = new Size(Width + 1, Height + 1);
            if (_GraphicsBuffer != null)            {
                _GraphicsBuffer = _GraphicsContext.Allocate(CreateGraphics(), new Rectangle(0, 0,
                    Width, Height));
            }
        }

        private void MainForm_Show(Object sendar, EventArgs e) {
            DrawClock();
        }

        private void DrawToBuffer(Graphics graphics, Rectangle bounds)  {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.FillRectangle(SystemBrushes.Control, 0, 0, Width, Height);
            Clock.Draw(graphics, bounds);
        }

        private void MainForm_Resize(object sendar, EventArgs e)    {
            SetUpGraphicsBuffer();
            DrawClock();
        }
    }
}

/*

            */
