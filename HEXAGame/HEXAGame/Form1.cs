using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HEXAGame
{
    public partial class Form1 : Form
    {

        Timer _updater = new Timer();
        Button currentBlock;
        public Form1()
        {
            InitializeComponent();

            _updater.Interval = 100;
            _updater.Tick += _updater_Tick;

        }
        private void _updater_Tick(object sender, EventArgs e)
        {
            if (currentBlock != null)
            { 
                Point p = currentBlock.Location;
                p.Y += 5;
                currentBlock.Location = p;

                Console.WriteLine("{0},{1},{2},{3}", currentBlock.Location.Y, 
                    this.ClientSize.Height - currentBlock.Size.Height,
                    this.Height, currentBlock.Size.Height);

                if(this.Controls.Count ==2)
                {
                    if (currentBlock.Location.Y >= this.ClientSize.Height - currentBlock.Size.Height)
                    {
                        currentBlock = null;
                    }
                }
                else if (this.Controls.Count > 2)
                {
                    if(currentBlock.Location.Y >= this.Controls[this.Controls.Count - 2].Location.Y - currentBlock.Size.Height)
                    {
                        currentBlock = null;
                    }
                }
           
            }
            else if (currentBlock== null)
            {
                currentBlock = CreateBlock();
                this.Controls.Add(currentBlock);
            }

        }
        
        Button CreateBlock()
        {
            Button btn = new Button();
            btn.Size = new Size(100, 100);
            btn.Location = new Point(this.Width / 2 - btn.Width/2, 0);

            return btn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _updater.Start();
        }
    }
}
