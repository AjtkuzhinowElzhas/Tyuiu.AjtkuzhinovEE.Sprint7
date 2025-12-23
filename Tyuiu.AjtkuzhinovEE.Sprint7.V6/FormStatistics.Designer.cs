namespace Tyuiu.AjtkuzhinovEE.Sprint7.V6
{
    partial class FormStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStatistics));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            splitContainer1 = new SplitContainer();
            buttonShowChart_AEE = new Button();
            buttonAddFile_AEE = new Button();
            chartPatients_AEE = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartPatients_AEE).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(buttonShowChart_AEE);
            splitContainer1.Panel1.Controls.Add(buttonAddFile_AEE);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(chartPatients_AEE);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // buttonShowChart_AEE
            // 
            buttonShowChart_AEE.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonShowChart_AEE.Location = new Point(153, 378);
            buttonShowChart_AEE.Name = "buttonShowChart_AEE";
            buttonShowChart_AEE.Size = new Size(94, 55);
            buttonShowChart_AEE.TabIndex = 1;
            buttonShowChart_AEE.Text = "Реализовать";
            buttonShowChart_AEE.UseVisualStyleBackColor = true;
            buttonShowChart_AEE.Click += buttonShowChart_AEE_Click;
            // 
            // buttonAddFile_AEE
            // 
            buttonAddFile_AEE.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAddFile_AEE.Image = (Image)resources.GetObject("buttonAddFile_AEE.Image");
            buttonAddFile_AEE.Location = new Point(12, 378);
            buttonAddFile_AEE.Name = "buttonAddFile_AEE";
            buttonAddFile_AEE.Size = new Size(94, 60);
            buttonAddFile_AEE.TabIndex = 0;
            buttonAddFile_AEE.UseVisualStyleBackColor = true;
            buttonAddFile_AEE.Click += buttonAddFile_AEE_Click;
            // 
            // chartPatients_AEE
            // 
            chartArea1.Name = "ChartArea1";
            chartPatients_AEE.ChartAreas.Add(chartArea1);
            chartPatients_AEE.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            chartPatients_AEE.Legends.Add(legend1);
            chartPatients_AEE.Location = new Point(0, 0);
            chartPatients_AEE.Name = "chartPatients_AEE";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chartPatients_AEE.Series.Add(series1);
            chartPatients_AEE.Size = new Size(530, 450);
            chartPatients_AEE.TabIndex = 0;
            chartPatients_AEE.Text = "chart1";
            chartPatients_AEE.Click += chartPatients_AEE_Click;
            // 
            // FormStatistics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "FormStatistics";
            Text = "FormStatistics";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartPatients_AEE).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPatients_AEE;
        private Button buttonAddFile_AEE;
        private Button buttonShowChart_AEE;
    }
}