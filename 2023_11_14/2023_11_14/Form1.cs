using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2023_11_14
{
    public delegate void Change();
    public delegate void DirectionChange(int val);
    public delegate void TextChange(string val);
    public partial class Form1 : Form
    {
        
        Mover m = new Mover();

        
        public Form1()
        {
            InitializeComponent();

            this.button1.Size = new Size(50, 50);
            m.Targe(this.button1);
            m.ChangeHandler += M_ChangeHander;


        }
        private void M_TextChangeHander(string val)
        {
            Console.WriteLine(val);
        }
        private void M_ChangeHander()
        {
            if (this.button1.Location.X <= 0)
            {
                m.DirChangeX(1);

            }
            if (this.button1.Location.X + this.button1.Width >= this.Width)
            {
                m.DirChangeX(-1);
            }
            if (this.button1.Location.Y <= 0)
            {
                m.DirChangeY(1);

            }
            if (this.button1.Location.Y + this.button1.Height >= this.Height)
            {
                m.DirChangeY(-1);
            }
        }

    }

    class Mover
    {
        Timer _updater = new Timer();
        Point addPoint = new Point();
        Button btn;

        public event DirectionChange DirectionChangeHandler;
        public event TextChange TextChangeHandler;
        public event Change ChangeHandler;

        string[] txt = { "a", "b", "c", "d"};
        Random r = new Random();
        int counter;


        public Mover()
        {
            _updater.Interval = 10;
            _updater.Tick += _updater_Tick;
            

            addPoint.X = 1;
            addPoint.Y = 1;
        }
        public void Targe(Button btn)
        {
            this.btn = btn;
            _updater.Start();

        }
        public void DirChangeX(int val)
        {
            addPoint.X = val;

        }
        public void DirChangeY(int val)
        {
            addPoint.Y = val;
        }

        private void _updater_Tick(object sender, EventArgs e)
        {
            Point cp = btn.Location;
            cp.X += addPoint.X;
            cp.Y += addPoint.Y;

            btn.Location = cp;

            ChangeHandler?.Invoke();

            counter += _updater.Interval;

            if(counter>1000)
            {
                this.btn.Text = txt[r.Next(0, txt.Length)];
                TextChangeHandler?.Invoke(this.btn.Text);
                
                counter = 0;
            }
        }
    }
}
