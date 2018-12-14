using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataMining
{
    public partial class Form1 : Form
    {
        Series ser = new Series();
        Series ACenter = new Series("A center");
        Series BCenter = new Series("B center");
        Series CCenter = new Series("C center");
        Random rnd = new Random();

        List<double> Adislist = new List<double>();  //距離陣列
        List<double> Bdislist = new List<double>();  //距離陣列
        List<double> Cdislist = new List<double>();  //距離陣列

        public Form1() 
        {
            InitializeComponent();
            setchart();

            ser.ChartType = SeriesChartType.Point; //設定Point種類
            ser.MarkerStyle = MarkerStyle.Circle;  //Point圓圈表示
            ser.MarkerSize = 10;  //圓圈大小  


            setAcenterpoint(ACenter);
            setBcenterpoint(BCenter);
            setCcenterpoint(CCenter);
            
            ser.Points.AddXY(2, 10);
            ser.Points.AddXY(2, 5);
            ser.Points.AddXY(8, 4);

            ser.Points.AddXY(5, 8);
            ser.Points.AddXY(7, 5);
            ser.Points.AddXY(6, 4);

            ser.Points.AddXY(1, 2);
            ser.Points.AddXY(4, 9);

            ACenter.Points.AddXY(rnd.Next(1,9), rnd.Next(1,10));
            BCenter.Points.AddXY(rnd.Next(1,9), rnd.Next(1,10));
            CCenter.Points.AddXY(rnd.Next(1,9), rnd.Next(1,10));

            for(int i = 0; i < 8; i++)
            {
                ser.Points[i].Color = Color.Black;
            }

            this.chart1.Series.Add(ser);//將線畫在圖上
            this.chart1.Series.Add(ACenter);
            this.chart1.Series.Add(BCenter);
            this.chart1.Series.Add(CCenter);

        }


        public void setchart() //繪圖
        {
            //---------------------
            chart1.Series.Clear();  //每次使用此function前先清除圖表
            chart1.ChartAreas[0].AxisX.Minimum = 0;  //設定X軸最小值
            chart1.ChartAreas[0].AxisX.Maximum = 10; //設定X軸最大值
            chart1.ChartAreas[0].AxisY.Minimum = 0;  //設定Y軸最小值
            chart1.ChartAreas[0].AxisY.Maximum = 10; //設定Y軸最大值
            chart1.ChartAreas[0].AxisX.MajorTickMark.Interval = 1;  //X軸刻度線的間隔
            chart1.ChartAreas[0].AxisY.MajorTickMark.Interval = 1;  //Y軸刻度線的間隔
            
        }

        public void setAcenterpoint(Series point)
        {
            point.Color = Color.Blue; //設定Point顏色           
            point.ChartType = SeriesChartType.Point; //設定Point種類
            point.MarkerStyle = MarkerStyle.Star5;  //Point圓圈表示
            point.MarkerSize = 20;  //圓圈大小  
        }
        public void setBcenterpoint(Series point)
        {
            point.Color = Color.Red; //設定Point顏色           
            point.ChartType = SeriesChartType.Point; //設定Point種類
            point.MarkerStyle = MarkerStyle.Star5;  //Point圓圈表示
            point.MarkerSize = 20;  //圓圈大小  
        }
        public void setCcenterpoint(Series point)
        {
            point.Color = Color.Green; //設定Point顏色           
            point.ChartType = SeriesChartType.Point; //設定Point種類
            point.MarkerStyle = MarkerStyle.Star5;  //Point圓圈表示
            point.MarkerSize = 20;  //圓圈大小  
        }
       

        public void button1_Click(object sender, EventArgs e) 
        {

            double Ax = 0;               //Ax A中心 x座標
            double Ay = 0;               //Ay A中心 y座標
            double Bx = 0;
            double By = 0;
            double Cx = 0;
            double Cy = 0;

            int a_count = 0;
            int b_count = 0;
            int c_count = 0;

            for (int i = 0; i < ser.Points.Count; i++)
            {
                if(ser.Points[i].Color == ACenter.Color)
                {
                    Ax += ser.Points[i].XValue;
                    Ay += ser.Points[i].YValues[0];
                    a_count++;
                }
                else if (ser.Points[i].Color == BCenter.Color)
                {
                    Bx += ser.Points[i].XValue;
                    By += ser.Points[i].YValues[0];
                    b_count++;
                }
                else
                {
                    Cx += ser.Points[i].XValue;
                    Cy += ser.Points[i].YValues[0];
                    c_count++;
                }
            }
            Ax /= a_count;
            Ay /= a_count;
            Bx /= b_count;                          
            By /= b_count;
            Cx /= c_count;                         
            Cy /= c_count;
            ACenter.Points[0].XValue = Ax;
            ACenter.Points[0].YValues[0] = Ay;
            BCenter.Points[0].XValue = Bx;
            BCenter.Points[0].YValues[0] = By;
            CCenter.Points[0].XValue = Cx;
            CCenter.Points[0].YValues[0] = Cy;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            double shortnum = 0;
            for(int i = 0; i < ser.Points.Count; i++)                     //各點到A群心的距離
            {
                Adislist.Add(Math.Sqrt(Math.Pow(ser.Points[i].XValue - ACenter.Points[0].XValue, 2)//各點到A群心的距離
                    + Math.Pow(ser.Points[i].YValues[0] - ACenter.Points[0].YValues[0], 2)));
                Bdislist.Add(Math.Sqrt(Math.Pow(ser.Points[i].XValue - BCenter.Points[0].XValue, 2)//各點到B群心的距離
                    + Math.Pow(ser.Points[i].YValues[0] - BCenter.Points[0].YValues[0], 2)));
                Cdislist.Add(Math.Sqrt(Math.Pow(ser.Points[i].XValue - CCenter.Points[0].XValue, 2)//各點到C群心的距離
                    + Math.Pow(ser.Points[i].YValues[0] - CCenter.Points[0].YValues[0], 2)));
            }

            for(int i = 0; i < ser.Points.Count; i++)
            {
                shortnum = Math.Min(Adislist[i], Math.Min(Bdislist[i], Cdislist[i]));     //找出該點到ABC群心最短距離

                if(shortnum == Adislist[i])
                {
                    ser.Points[i].Color = ACenter.Color;
                }else if(shortnum == Bdislist[i])
                {
                    ser.Points[i].Color = BCenter.Color;
                }
                else
                {
                    ser.Points[i].Color = CCenter.Color;
                }
            }

            Adislist.Clear();
            Bdislist.Clear();
            Cdislist.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                ser.Points[i].Color = Color.Black;
            }

            ACenter.Points.Clear();
            BCenter.Points.Clear();
            CCenter.Points.Clear();

            ACenter.Points.AddXY(rnd.Next(1, 9), rnd.Next(1, 10));
            BCenter.Points.AddXY(rnd.Next(1, 9), rnd.Next(1, 10));
            CCenter.Points.AddXY(rnd.Next(1, 9), rnd.Next(1, 10));
        }
    }
}
