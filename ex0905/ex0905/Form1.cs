using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex0905
{
    public partial class Form1 : Form
    {

        //자료형
        struct Coord
        {

            //public -> 외부에 공유
            public int x { get; set; } //자동화로 사용
            public int y { get; set; } //자동화로 사용

            public void SetOrigin()
            {
                this.x = 0;
                this.y = 0;
            }

            public Coord(int xx, int yy)
            {
                this.x = xx;
                this.y = yy;


            }

            public static Coord Factory()
            {
                return new Coord();
            }
        }



        struct Coordinate
        {
            public int x;
            public int y;

        }

        // Enum (열거자)
        enum University
        {
            백석대,      //0
            백석문화대,  //1
            백석예술대   //2
        }

        enum WeekDays
        {
            Monday,     //0
            Tuesday,    //1
            Wednesday,  //2
            Thursday,   //3
            Friday,     //4
            Saturday,   //5
            Sunday      //6
        }


        public Form1()
        {
            InitializeComponent();

            //문자열은 "", 문자는 ''
            char c = 'c';
            string dse = "ddd";

            System.Diagnostics.Debug.Print(dse);
            //자료형 변경 char->string
            System.Diagnostics.Debug.Print(c.ToString());

            string str = @"xyzdef\rabc";
            string path = @"\\mypc\shared\project";
            string email = @"test@test.com";

            string str1 = "this is a \n" + "multi line \n" + "string";
            string str2 = @"this is a multi line string";

            System.Diagnostics.Debug.Print(str);
            System.Diagnostics.Debug.Print(path);
            System.Diagnostics.Debug.Print(email);
            System.Diagnostics.Debug.Print(str1);
            System.Diagnostics.Debug.Print(str2);

            int e = 10;
            float k = 10.0f;
            double d = 10.0;
            byte b = 100; // 255 초과시 오류
            bool t = false; //or true, 1bit

            System.Diagnostics.Debug.Print(byte.MaxValue.ToString()); // byte 자료형의 최대값 구하기

            Coord coord = new Coord(100, 200);
            Console.WriteLine(coord.x);
            Console.WriteLine(coord.y);

            coord.SetOrigin(); // 0, 0 으로 초기화
            Console.WriteLine(coord.x);
            Console.WriteLine(coord.y);
            
            Coord coord1 = Coord.Factory();


            Coordinate point = new Coordinate();
            point.x = 10;
            point.y = 20;
            Console.WriteLine(point.x); //ootput : 0
            Console.WriteLine(point.y); //output : 0

            University university = University.백석문화대;

            WeekDays w = WeekDays.Tuesday;

            switch (w)
            { 
                case WeekDays.Monday:
                    break;
                case WeekDays.Tuesday:
                    break;
                case WeekDays.Wednesday:
                    break;
                case WeekDays.Thursday:
                    break;
                case WeekDays.Friday:
                    break;
                case WeekDays.Saturday:
                    break;
                case WeekDays.Sunday:
                    break;
            }

            
            Console.WriteLine(WeekDays.Friday);
            int day = (int)WeekDays.Friday;
            Console.WriteLine(day);

            var wd = (WeekDays)5;
            Console.WriteLine(wd);

            Nullable<int> i = null; // 오류 x
            // int x = null; 오류남

            //this.button1.Location = new Point(10, 30);

            this.button2.Click += Button1_Click;
            this.button3.Click += Button1_Click;
            this.button4.Click += Button1_Click;
            this.button5.Click += Button1_Click;
            
            this.button6.Click += Button1_Click;
            this.button7.Click += Button1_Click;

            this.trackBar1.ValueChanged += TrackBar1_ValueChange;
            
        }

        //c# 은4사분면에 위치 그러므로
        int preValue = 0;

        private void TrackBar1_ValueChange(object sender, EventArgs e)
        {
            Size size = this.button1.Size;

            int diff = this.trackBar1.Value - preValue;
            preValue = this.trackBar1.Value;

            size.Width += diff;
            size.Height += diff;
            
            this.button1.Size = size;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Point current = this.button1.Location;
            Size size = this.button1.Size;

            if (sender == this.button2)
                current.Y -= 1;
            if(sender == this.button3)
                current.Y += 1;
            if(sender == this.button4)
                current.X -= 1;
            if (sender == this.button5)
                current.X += 1;
            
            if( sender == this.button6)
            { 
                size.Width += 10;
                size.Height += 10;

            }
            if (sender == this.button7)
            {
                size.Width -= 10;
                size.Height -= 10;

            }

            this.button1.Location = current;
            this.button1.Size = size;

        }




        //private void button2_Click(object sender, EventArgs e)
        //{
        //    Point current =this.button1.Location;
        //    current.Y -= 1;

        //    this.button1.Location = current;

        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    Point current = this.button1.Location;
        //    current.Y += 1;

        //    this.button1.Location = current;

        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    Point current = this.button1.Location;
        //    current.X -= 1;

        //    this.button1.Location = current;
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    Point current = this.button1.Location;
        //    current.X += 1;

        //    this.button1.Location = current;
        //}
    }
}
