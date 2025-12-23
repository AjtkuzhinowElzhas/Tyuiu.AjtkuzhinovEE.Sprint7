namespace Tyuiu.AjtkuzhinovEE.Sprint7.V6
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            pictureBox_AEE = new PictureBox();
            labelInfo = new Label();
            labelgroup = new Label();
            label = new Label();
            label1 = new Label();
            label2 = new Label();
            buttonOk = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_AEE).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_AEE
            // 
            pictureBox_AEE.ErrorImage = null;
            pictureBox_AEE.Image = (Image)resources.GetObject("pictureBox_AEE.Image");
            pictureBox_AEE.Location = new Point(28, 22);
            pictureBox_AEE.Name = "pictureBox_AEE";
            pictureBox_AEE.Size = new Size(279, 350);
            pictureBox_AEE.TabIndex = 0;
            pictureBox_AEE.TabStop = false;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(322, 22);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(325, 20);
            labelInfo.TabIndex = 1;
            labelInfo.Text = "Разработчик : Айткужинов Елжас Есилбаевич";
            // 
            // labelgroup
            // 
            labelgroup.AutoSize = true;
            labelgroup.Location = new Point(322, 53);
            labelgroup.Name = "labelgroup";
            labelgroup.Size = new Size(144, 20);
            labelgroup.TabIndex = 2;
            labelgroup.Text = "Группа : РППб-25-1";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(322, 97);
            label.Name = "label";
            label.Size = new Size(387, 20);
            label.TabIndex = 3;
            label.Text = "Программа разработана в рамках изучения языка С#\r\n";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(317, 352);
            label1.Name = "label1";
            label1.Size = new Size(330, 20);
            label1.TabIndex = 4;
            label1.Text = "Внутреннее имя: Tyuiu.AjtkuzhinovEE.Sprint7.V6\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(322, 217);
            label2.Name = "label2";
            label2.Size = new Size(304, 60);
            label2.TabIndex = 5;
            label2.Text = "Тюменский индустриальный университет \r\nВысшая школа цифровых технологий\r\n\r\n";
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(694, 391);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(94, 47);
            buttonOk.TabIndex = 6;
            buttonOk.Text = "Ок";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonOk);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label);
            Controls.Add(labelgroup);
            Controls.Add(labelInfo);
            Controls.Add(pictureBox_AEE);
            Name = "FormAbout";
            Text = "FormAbout";
            Load += FormAbout_Load_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox_AEE).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_AEE;
        private Label labelInfo;
        private Label labelgroup;
        private Label label;
        private Label label1;
        private Label label2;
        private Button buttonOk;
    }
}