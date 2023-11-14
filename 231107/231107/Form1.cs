using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _231107
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            int sum = 0;

            
        }

        void Test(int[] arr)
        {
            for(int i = 0; i< arr.Length; i++)
            {
                arr[i] = 1;
            }
        }
        
        

    }
}
