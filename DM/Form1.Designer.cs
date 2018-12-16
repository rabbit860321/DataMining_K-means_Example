namespace DataMining
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.findCenterbtn = new System.Windows.Forms.Button();
            this.allocationBtn = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(23, 21);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(664, 368);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // findCenterbtn
            // 
            this.findCenterbtn.Location = new System.Drawing.Point(188, 409);
            this.findCenterbtn.Name = "findCenterbtn";
            this.findCenterbtn.Size = new System.Drawing.Size(159, 48);
            this.findCenterbtn.TabIndex = 1;
            this.findCenterbtn.Text = "找群中心點";
            this.findCenterbtn.UseVisualStyleBackColor = true;
            this.findCenterbtn.Click += new System.EventHandler(this.findCenterbtn_Click);
            // 
            // allocationBtn
            // 
            this.allocationBtn.Location = new System.Drawing.Point(188, 409);
            this.allocationBtn.Name = "allocationBtn";
            this.allocationBtn.Size = new System.Drawing.Size(159, 48);
            this.allocationBtn.TabIndex = 2;
            this.allocationBtn.Text = "分群";
            this.allocationBtn.UseVisualStyleBackColor = true;
            this.allocationBtn.Click += new System.EventHandler(this.allocationBtn_Click);
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(353, 409);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(159, 48);
            this.restart.TabIndex = 3;
            this.restart.Text = "重新";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 540);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.allocationBtn);
            this.Controls.Add(this.findCenterbtn);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button findCenterbtn;
        private System.Windows.Forms.Button allocationBtn;
        private System.Windows.Forms.Button restart;
    }
}

