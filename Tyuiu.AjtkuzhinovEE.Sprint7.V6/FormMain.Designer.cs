namespace Tyuiu.AjtkuzhinovEE.Sprint7.V6
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            dataGridView = new DataGridView();
            buttonAbout_AEE = new Button();
            buttonShowStats_AEE = new Button();
            buttonSaveData_AEE = new Button();
            buttonLoadData_AEE = new Button();
            buttonSearch_AEE = new Button();
            buttonClearSearch_AEE = new Button();
            textBoxSearch_AEE = new TextBox();
            panel1 = new Panel();
            buttonAdd_AEE = new Button();
            buttonDelete_AEE = new Button();
            comboBoxDiagnosis_AEE = new ComboBox();
            comboBoxDoctor_AEE = new ComboBox();
            panel2 = new Panel();
            splitter1 = new Splitter();
            saveFileDialog_AEE = new SaveFileDialog();
            toolTip_Save = new ToolTip(components);
            toolTipAdd = new ToolTip(components);
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            toolTip4 = new ToolTip(components);
            toolTip5 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(784, 605);
            dataGridView.TabIndex = 0;
            // 
            // buttonAbout_AEE
            // 
            buttonAbout_AEE.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAbout_AEE.Cursor = Cursors.Hand;
            buttonAbout_AEE.Image = (Image)resources.GetObject("buttonAbout_AEE.Image");
            buttonAbout_AEE.Location = new Point(9, 456);
            buttonAbout_AEE.Name = "buttonAbout_AEE";
            buttonAbout_AEE.Size = new Size(247, 58);
            buttonAbout_AEE.TabIndex = 6;
            buttonAbout_AEE.Text = "\r\n";
            toolTip1.SetToolTip(buttonAbout_AEE, "Информация о разработчике");
            buttonAbout_AEE.UseVisualStyleBackColor = true;
            buttonAbout_AEE.Click += buttonAbout_AEE_Click;
            // 
            // buttonShowStats_AEE
            // 
            buttonShowStats_AEE.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonShowStats_AEE.Cursor = Cursors.Hand;
            buttonShowStats_AEE.Enabled = false;
            buttonShowStats_AEE.Image = (Image)resources.GetObject("buttonShowStats_AEE.Image");
            buttonShowStats_AEE.Location = new Point(9, 399);
            buttonShowStats_AEE.Name = "buttonShowStats_AEE";
            buttonShowStats_AEE.Size = new Size(247, 51);
            buttonShowStats_AEE.TabIndex = 7;
            toolTip4.SetToolTip(buttonShowStats_AEE, "Посмотреть статистику");
            buttonShowStats_AEE.UseVisualStyleBackColor = true;
            buttonShowStats_AEE.Click += buttonShowStats_AEE_Click;
            // 
            // buttonSaveData_AEE
            // 
            buttonSaveData_AEE.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSaveData_AEE.Cursor = Cursors.Hand;
            buttonSaveData_AEE.Enabled = false;
            buttonSaveData_AEE.Image = (Image)resources.GetObject("buttonSaveData_AEE.Image");
            buttonSaveData_AEE.Location = new Point(109, 533);
            buttonSaveData_AEE.Name = "buttonSaveData_AEE";
            buttonSaveData_AEE.Size = new Size(94, 49);
            buttonSaveData_AEE.TabIndex = 2;
            toolTip_Save.SetToolTip(buttonSaveData_AEE, "Нажмите,чтобы сохранить файл\r\n");
            buttonSaveData_AEE.UseVisualStyleBackColor = true;
            buttonSaveData_AEE.Click += buttonSaveData_AEE_Click;
            // 
            // buttonLoadData_AEE
            // 
            buttonLoadData_AEE.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonLoadData_AEE.Cursor = Cursors.Hand;
            buttonLoadData_AEE.Image = (Image)resources.GetObject("buttonLoadData_AEE.Image");
            buttonLoadData_AEE.Location = new Point(9, 533);
            buttonLoadData_AEE.Name = "buttonLoadData_AEE";
            buttonLoadData_AEE.Size = new Size(94, 49);
            buttonLoadData_AEE.TabIndex = 1;
            toolTipAdd.SetToolTip(buttonLoadData_AEE, "Нажмите, чтобы загрузить файл");
            buttonLoadData_AEE.UseVisualStyleBackColor = true;
            buttonLoadData_AEE.Click += buttonLoadData_AEE_Click;
            // 
            // buttonSearch_AEE
            // 
            buttonSearch_AEE.Cursor = Cursors.Hand;
            buttonSearch_AEE.Location = new Point(3, 3);
            buttonSearch_AEE.Name = "buttonSearch_AEE";
            buttonSearch_AEE.Size = new Size(94, 49);
            buttonSearch_AEE.TabIndex = 3;
            buttonSearch_AEE.Text = "Поиск";
            toolTip5.SetToolTip(buttonSearch_AEE, "Выполнить поиск");
            buttonSearch_AEE.UseVisualStyleBackColor = true;
            buttonSearch_AEE.Click += buttonSearch_AEE_Click;
            // 
            // buttonClearSearch_AEE
            // 
            buttonClearSearch_AEE.Cursor = Cursors.Hand;
            buttonClearSearch_AEE.Enabled = false;
            buttonClearSearch_AEE.Location = new Point(3, 58);
            buttonClearSearch_AEE.Name = "buttonClearSearch_AEE";
            buttonClearSearch_AEE.Size = new Size(94, 49);
            buttonClearSearch_AEE.TabIndex = 4;
            buttonClearSearch_AEE.Text = "Очистить поиск";
            buttonClearSearch_AEE.UseVisualStyleBackColor = true;
            buttonClearSearch_AEE.Click += buttonClearSearch_AEE_Click;
            // 
            // textBoxSearch_AEE
            // 
            textBoxSearch_AEE.Cursor = Cursors.Hand;
            textBoxSearch_AEE.Enabled = false;
            textBoxSearch_AEE.Location = new Point(109, 3);
            textBoxSearch_AEE.Multiline = true;
            textBoxSearch_AEE.Name = "textBoxSearch_AEE";
            textBoxSearch_AEE.Size = new Size(147, 46);
            textBoxSearch_AEE.TabIndex = 9;
            textBoxSearch_AEE.TextChanged += textBoxSearch_AEE_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonAdd_AEE);
            panel1.Controls.Add(buttonDelete_AEE);
            panel1.Controls.Add(comboBoxDiagnosis_AEE);
            panel1.Controls.Add(comboBoxDoctor_AEE);
            panel1.Controls.Add(buttonShowStats_AEE);
            panel1.Controls.Add(textBoxSearch_AEE);
            panel1.Controls.Add(buttonAbout_AEE);
            panel1.Controls.Add(buttonClearSearch_AEE);
            panel1.Controls.Add(buttonSearch_AEE);
            panel1.Controls.Add(buttonSaveData_AEE);
            panel1.Controls.Add(buttonLoadData_AEE);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(276, 605);
            panel1.TabIndex = 10;
            // 
            // buttonAdd_AEE
            // 
            buttonAdd_AEE.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdd_AEE.Cursor = Cursors.Hand;
            buttonAdd_AEE.Location = new Point(12, 319);
            buttonAdd_AEE.Name = "buttonAdd_AEE";
            buttonAdd_AEE.Size = new Size(94, 49);
            buttonAdd_AEE.TabIndex = 13;
            buttonAdd_AEE.Text = "Добавить";
            toolTip3.SetToolTip(buttonAdd_AEE, "Добавить строку");
            buttonAdd_AEE.UseVisualStyleBackColor = true;
            buttonAdd_AEE.Click += buttonAdd_AEE_Click;
            // 
            // buttonDelete_AEE
            // 
            buttonDelete_AEE.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonDelete_AEE.Cursor = Cursors.Hand;
            buttonDelete_AEE.Enabled = false;
            buttonDelete_AEE.Location = new Point(112, 319);
            buttonDelete_AEE.Name = "buttonDelete_AEE";
            buttonDelete_AEE.Size = new Size(144, 49);
            buttonDelete_AEE.TabIndex = 12;
            buttonDelete_AEE.Text = "Удалить";
            toolTip2.SetToolTip(buttonDelete_AEE, "Удалить строку");
            buttonDelete_AEE.UseVisualStyleBackColor = true;
            buttonDelete_AEE.Click += buttonDelete_AEE_Click;
            // 
            // comboBoxDiagnosis_AEE
            // 
            comboBoxDiagnosis_AEE.Cursor = Cursors.Hand;
            comboBoxDiagnosis_AEE.Enabled = false;
            comboBoxDiagnosis_AEE.FormattingEnabled = true;
            comboBoxDiagnosis_AEE.Location = new Point(3, 159);
            comboBoxDiagnosis_AEE.Name = "comboBoxDiagnosis_AEE";
            comboBoxDiagnosis_AEE.Size = new Size(171, 28);
            comboBoxDiagnosis_AEE.TabIndex = 11;
            comboBoxDiagnosis_AEE.Text = "Выберите значение";
            comboBoxDiagnosis_AEE.SelectedIndexChanged += comboBoxDiagnosis_AEE_SelectedIndexChanged;
            // 
            // comboBoxDoctor_AEE
            // 
            comboBoxDoctor_AEE.Cursor = Cursors.Hand;
            comboBoxDoctor_AEE.Enabled = false;
            comboBoxDoctor_AEE.FormattingEnabled = true;
            comboBoxDoctor_AEE.Location = new Point(3, 113);
            comboBoxDoctor_AEE.Name = "comboBoxDoctor_AEE";
            comboBoxDoctor_AEE.Size = new Size(169, 28);
            comboBoxDoctor_AEE.TabIndex = 10;
            comboBoxDoctor_AEE.Text = "выберите критерий";
            comboBoxDoctor_AEE.SelectedIndexChanged += comboBoxDoctor_AEE_SelectedIndexChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(276, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(784, 605);
            panel2.TabIndex = 11;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(276, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(10, 605);
            splitter1.TabIndex = 12;
            splitter1.TabStop = false;
            // 
            // toolTip_Save
            // 
            toolTip_Save.Tag = "";
            toolTip_Save.ToolTipIcon = ToolTipIcon.Info;
            toolTip_Save.ToolTipTitle = "Save";
            // 
            // toolTipAdd
            // 
            toolTipAdd.ToolTipIcon = ToolTipIcon.Info;
            toolTipAdd.ToolTipTitle = "ADD";
            // 
            // toolTip1
            // 
            toolTip1.ToolTipTitle = "Info";
            // 
            // toolTip2
            // 
            toolTip2.ToolTipTitle = "Delete";
            // 
            // toolTip3
            // 
            toolTip3.ToolTipTitle = "Add Value";
            // 
            // toolTip4
            // 
            toolTip4.ToolTipTitle = "Statistic";
            // 
            // toolTip5
            // 
            toolTip5.ToolTipTitle = "Search";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1060, 605);
            Controls.Add(splitter1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MinimumSize = new Size(1078, 652);
            Name = "FormMain";
            Text = "Айткужинов Елжас | Спринт 7";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Button buttonAbout_AEE;
        private Button buttonShowStats_AEE;
        private Button buttonSaveData_AEE;
        private Button buttonLoadData_AEE;
        private Button buttonSearch_AEE;
        private Button buttonClearSearch_AEE;
        private TextBox textBoxSearch_AEE;
        private Panel panel1;
        private Panel panel2;
        private Splitter splitter1;
        private SaveFileDialog saveFileDialog_AEE;
        private ComboBox comboBoxDoctor_AEE;
        private ComboBox comboBoxDiagnosis_AEE;
        private Button buttonDelete_AEE;
        private Button buttonAdd_AEE;
        private ToolTip toolTip_Save;
        private ToolTip toolTipAdd;
        private ToolTip toolTip1;
        private ToolTip toolTip2;
        private ToolTip toolTip3;
        private ToolTip toolTip4;
        private ToolTip toolTip5;
    }
}
