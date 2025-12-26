using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tyuiu.AjtkuzhinovEE.Sprint7.V6.Lib;

namespace Tyuiu.AjtkuzhinovEE.Sprint7.V6
{
    public partial class FormMain : Form
    {
        private DataService ds = new DataService();
        private string[,] currentMatrix;
        private string currentFilePath = "";
        static int rows;
        static int columns;
        int sortColumnIndex;


        public FormMain()
        {
            InitializeComponent();


        }

        private void FormMain_AEE_Load(object sender, EventArgs e)
        {
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void buttonLoadData_AEE_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "CSV файлы (*.csv)|*.csv|Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.Title = "Выберите файл с данными пациентов";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = openFileDialog.FileName;

                        // Загружаем данные через библиотеку
                        currentMatrix = ds.LoadFromFile(currentFilePath);
                        rows = currentMatrix.GetLength(0);
                        columns = currentMatrix.GetLength(1);

                        // Отображаем данные в таблице
                        DisplayDataInDataGridView();

                        // заголовки для сортировки
                        comboBoxDoctor_AEE.Items.Clear();
                        for (int j = 0; j < columns; j++)
                            comboBoxDoctor_AEE.Items.Add(currentMatrix[0, j]);

                        // Активируем кнопки, которые требуют загруженных данных
                        buttonSaveData_AEE.Enabled = true;
                        //buttonEdit_AEE.Enabled = true;
                        buttonShowStats_AEE.Enabled = true;
                        buttonSearch_AEE.Enabled = true;
                        buttonSaveData_AEE.Enabled = true;
                        comboBoxDoctor_AEE.Enabled = true;
                        comboBoxDiagnosis_AEE.Enabled = true;
                        textBoxSearch_AEE.Enabled = true;
                        buttonDelete_AEE.Enabled = true;
                        buttonClearSearch_AEE.Enabled = true;


                        MessageBox.Show($"Данные успешно загружены!\nФайл: {Path.GetFileName(currentFilePath)}\nЗаписей: {currentMatrix.GetLength(0) - 1}",
                            "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла:\n{ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSaveData_AEE_Click(object sender, EventArgs e)
        {
            try
            {
                // Укажи фильтр для Excel-подобных файлов
                saveFileDialog_AEE.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog_AEE.FilterIndex = 1;
                saveFileDialog_AEE.FileName = "Patient.csv"; 

                if (saveFileDialog_AEE.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    // Заголовки
                    for (int j = 0; j < dataGridView.ColumnCount; j++)
                    {
                        sb.Append(dataGridView.Columns[j].HeaderText);
                        if (j != dataGridView.ColumnCount - 1)
                            sb.Append(";");
                    }
                    sb.AppendLine();

                    // Данные
                    for (int i = 0; i < dataGridView.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView.ColumnCount; j++)
                        {
                            sb.Append(dataGridView.Rows[i].Cells[j].Value);
                            if (j != dataGridView.ColumnCount - 1)
                                sb.Append(";");
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(saveFileDialog_AEE.FileName, sb.ToString(), Encoding.GetEncoding(1251));

                    // Открываем файл в Excel
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = saveFileDialog_AEE.FileName,
                        UseShellExecute = true
                    });

                    MessageBox.Show("Файл сохранен и открыт в Excel");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения");
            }
        }

        private void buttonSearch_AEE_Click(object sender, EventArgs e)
        {
            if (currentMatrix == null)
            {
                MessageBox.Show("Сначала загрузите данные!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchText = textBoxSearch_AEE.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // использование SearchInMatrix
            string[,] searchResults = ds.SearchInMatrix(currentMatrix, searchText);

            if (searchResults.GetLength(0) <= 1)
            {
                MessageBox.Show("Ничего не найдено!", "Поиск",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayDataInDataGridView(); // показываем данные
            }
            else
            {
                // Отображаем результаты поика
                DisplaySearchResultsInGridView(searchResults);

                MessageBox.Show($"Найдено записей: {searchResults.GetLength(0) - 1}",
                    "Поиск", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClearSearch_AEE_Click(object sender, EventArgs e)
        {
            textBoxSearch_AEE.Text = "";

            if (currentMatrix != null)
            {
                DisplayDataInDataGridView();
            }
        }


        private void buttonAbout_AEE_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void buttonShowStats_AEE_Click(object sender, EventArgs e)
        {
            if (currentMatrix == null)
            {
                MessageBox.Show("Сначала загрузите данные!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormStatistics formStats = new(currentMatrix);
            formStats.ShowDialog();
        }
        private void DisplayDataInDataGridView()
        {
            if (currentMatrix == null) return;

            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            int rows = currentMatrix.GetLength(0);
            int cols = currentMatrix.GetLength(1);

            // Добавляем столбцы (заголовки)
            for (int j = 0; j < cols; j++)
            {
                dataGridView.Columns.Add($"Column{j}", currentMatrix[0, j]);
            }

            // Добавляем строки с данными (со второй строки)
            for (int i = 1; i < rows; i++)
            {
                string[] rowData = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    rowData[j] = currentMatrix[i, j];
                }
                dataGridView.Rows.Add(rowData);
            }
        }
        private void DisplaySearchResultsInGridView(string[,] matrix)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Добавляем столбцы
            for (int j = 0; j < cols; j++)
            {
                dataGridView.Columns.Add($"Column{j}", matrix[0, j]);
            }

            // Добавляем строки с данными
            for (int i = 1; i < rows; i++)
            {
                string[] rowData = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    rowData[j] = matrix[i, j];
                }
                dataGridView.Rows.Add(rowData);
            }
        }
        private void textBoxSearch_AEE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonSearch_AEE_Click(sender, e);
                e.Handled = true;
            }
        }

        private void textBoxSearch_AEE_TextChanged(object sender, EventArgs e)
        {

        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxDoctor_AEE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxDiagnosis_AEE.Items.Clear();

                for (int j = 0; j < columns; j++)
                    if (comboBoxDoctor_AEE.Text == currentMatrix[0, j])
                        sortColumnIndex = j;

                for (int i = 1; i < rows; i++)
                {
                    if (!comboBoxDiagnosis_AEE.Items.Contains(currentMatrix[i, sortColumnIndex]))
                    {
                        comboBoxDiagnosis_AEE.Items.Add(currentMatrix[i, sortColumnIndex]);
                    }
                }

                comboBoxDiagnosis_AEE.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Ошибка выбора критерия");
            }
        }

        private void comboBoxDiagnosis_AEE_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();

            for (int i = 0; i < rows; i++)
            {
                if (i == 0 || currentMatrix[i, sortColumnIndex] == comboBoxDiagnosis_AEE.Text)
                {
                    int rowIndex = dataGridView.Rows.Add();
                    for (int j = 0; j < columns; j++)
                    {
                        dataGridView.Rows[rowIndex].Cells[j].Value = currentMatrix[i, j];
                    }
                }
            }
        }

        private void buttonDelete_AEE_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell != null)
            {
                dataGridView.Rows.RemoveAt(dataGridView.CurrentCell.RowIndex);
            }
        }

        private void buttonAdd_AEE_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
        }
    }

}
