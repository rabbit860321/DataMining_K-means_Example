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

        List<double> dislist = new List<double>();  //距離陣列



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
            


            this.chart1.Series.Add(ser);//將線畫在圖上
            this.chart1.Series.Add(ACenter);
            this.chart1.Series.Add(BCenter);
            this.chart1.Series.Add(CCenter);

            ser.Points[0].Color = Color.Blue;
            ser.Points[1].Color = Color.Blue;
            ser.Points[2].Color = Color.Blue;
            ser.Points[3].Color = Color.Red;
            ser.Points[4].Color = Color.Red;
            ser.Points[5].Color = Color.Red;
            ser.Points[6].Color = Color.Green;
            ser.Points[7].Color = Color.Green;
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
            ACenter.Points.Clear();
            BCenter.Points.Clear();
            CCenter.Points.Clear();
            double Ax = 0;               //Ax A中心 x座標
            double Ay = 0;               //Ay A中心 y座標
            double Bx = 0;
            double By = 0;
            double Cx = 0;
            double Cy = 0;

            for (int i = 0; i < ser.Points.Count; i++)
            {
                if(ser.Points[i].Color == Color.Blue)
                {
                    Ax += ser.Points[i].XValue;
                    Ay += ser.Points[i].YValues[0];
                }
            }
            Ax /= 3;                                //中心座標 = (x1+x2+x3)/3
            Ay /= 3;
            ACenter.Points.AddXY(Ax, Ay);
            

            for (int i = 0; i < ser.Points.Count; i++)
            {
                if (ser.Points[i].Color == Color.Red)
                {
                    Bx += ser.Points[i].XValue;
                    By += ser.Points[i].YValues[0];
                }
            }
            Bx /= 3;
            By /= 3;
            BCenter.Points.AddXY(Bx, By);
            

            
            for (int i = 0; i < ser.Points.Count; i++)
            {
                if (ser.Points[i].Color == Color.Green)
                {
                    Cx += ser.Points[i].XValue;
                    Cy += ser.Points[i].YValues[0];
                }
            }
            Cx /= 2;
            Cy /= 2;
            CCenter.Points.AddXY(Cx, Cy);
            
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ser.Points.Count; i++)              //讓所有點設為黑色
            {
                ser.Points[i].Color = Color.Black;
            }

            for (int i = 0; i < ser.Points.Count; i++)                      //存放每一點到A中心的距離
            {
                dislist.Add(Math.Sqrt(Math.Pow(ser.Points[i].XValue - ACenter.Points[0].XValue, 2)
                    + Math.Pow(ser.Points[i].YValues[0] - ACenter.Points[0].YValues[0], 2)));
            }

            for(int i = 0; i < 3; i++)                //A群要找出幾個Point
            {
                for (int j = 0; j < dislist.Count; j++)
                {
                    if (dislist.Min() == dislist[j])             //找出距離最短的點
                    {
                        ser.Points[j].Color = Color.Blue;
                        dislist[j] = dislist.Max();
                        break;
                    }
                }
            } 
            dislist.Clear();               

            for (int i = 0; i < ser.Points.Count; i++)                                                            
            {
                if(ser.Points[i].Color == Color.Black)                       //只計算尚未分群的點與B中心距離
                {
                    dislist.Add(Math.Sqrt(Math.Pow(ser.Points[i].XValue - BCenter.Points[0].XValue, 2)
                    + Math.Pow(ser.Points[i].YValues[0] - BCenter.Points[0].YValues[0], 2)));
                }
                else
                {
                    dislist.Add(100000);                                     //若已分群 存放1000000
                }
                
            }

            for (int i = 0; i < 3; i++)                //B群要找出幾個Point
            {
                for (int j = 0; j < dislist.Count; j++)
                {
                    if (dislist.Min() == dislist[j])             //找出距離最短的點
                    {
                        ser.Points[j].Color = Color.Red;
                        dislist[j] = dislist.Max();
                        break;
                    }
                }
            }
            dislist.Clear();

            for (int i = 0; i < ser.Points.Count; i++)                           //其餘就是C群
            {
                if(ser.Points[i].Color == Color.Black)
                {
                    ser.Points[i].Color = Color.Green;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ser.Points[0].Color = Color.Blue;
            ser.Points[1].Color = Color.Blue;
            ser.Points[2].Color = Color.Blue;
            ser.Points[3].Color = Color.Red;
            ser.Points[4].Color = Color.Red;
            ser.Points[5].Color = Color.Red;
            ser.Points[6].Color = Color.Green;
            ser.Points[7].Color = Color.Green;

            ACenter.Points.Clear();
            BCenter.Points.Clear();
            CCenter.Points.Clear();
        }

    }
}
