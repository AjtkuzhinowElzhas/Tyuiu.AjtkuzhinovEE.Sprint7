using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Tyuiu.AjtkuzhinovEE.Sprint7.V6.Lib;

namespace Tyuiu.AjtkuzhinovEE.Sprint7.V6
{
    public partial class FormStatistics : Form
    {
        public FormStatistics(string[,] currentMatrix)
        {
            InitializeComponent();
        }
        private DataService ds = new DataService();
        private string[,] currentMatrix;
        private string currentFilePath = "";

        private void buttonAddFile_AEE_Click(object sender, EventArgs e)
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

                        // Отображаем данные в таблице
                        //DisplayDataInDataGridView();

                        // Активируем кнопки, которые требуют загруженных данных
                        //buttonSaveData_AEE.Enabled = true;
                        //buttonEdit_AEE.Enabled = true;
                        //buttonShowStats_AEE.Enabled = true;
                        //buttonSearch_AEE.Enabled = true;


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

        private void chartPatients_AEE_Click(object sender, EventArgs e)
        {
            if (currentMatrix == null || currentMatrix.GetLength(0) <= 1)
                return;

            chartPatients_AEE.Series.Clear();

            Series series = new Series("Стоимость услуг");
            series.ChartType = SeriesChartType.Column;
            series.XValueType = ChartValueType.String;
            series.IsXValueIndexed = true;

            for (int i = 1; i < currentMatrix.GetLength(0); i++)
            {
                string route = currentMatrix[i, 0].Trim();

                if (int.TryParse(currentMatrix[i, 5], out int passengers))
                {
                    series.Points.AddXY(route, passengers);
                }
            }

            chartPatients_AEE.Series.Add(series);

            chartPatients_AEE.ChartAreas[0].AxisX.Title = "Ф.И.О";
            chartPatients_AEE.ChartAreas[0].AxisY.Title = "стоимость услуг";
            chartPatients_AEE.ChartAreas[0].AxisX.Interval = 1;
        }

        private void buttonShowChart_AEE_Click(object sender, EventArgs e)
        {
            if (currentMatrix == null || currentMatrix.GetLength(0) <= 1)
            {
                MessageBox.Show("Сначала загрузите данные!", "Внимание",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chartPatients_AEE.Series.Clear();

            Series series = new Series("Стоимость лечения");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            for (int i = 1; i < currentMatrix.GetLength(0); i++)
            {
                string fullName = currentMatrix[i, 0].Trim();
                string costStr = currentMatrix[i, 5].Trim();

                // Сокращаем ФИО для лучшего отображения
                //string shortName = fullName;

                if (int.TryParse(costStr, out int cost))
                {
                    series.Points.AddXY(fullName, cost);
                    series.Points[series.Points.Count - 1].Label = cost.ToString();
                }
            }

            chartPatients_AEE.Series.Add(series);

            chartPatients_AEE.ChartAreas[0].AxisX.Title = "Пациенты";
            chartPatients_AEE.ChartAreas[0].AxisY.Title = "Стоимость (руб.)";
            chartPatients_AEE.ChartAreas[0].AxisX.Interval = 1;
            //chartPatients_AEE.ChartAreas[0].AxisX.LabelStyle.Angle = ;
        }
    }
}
