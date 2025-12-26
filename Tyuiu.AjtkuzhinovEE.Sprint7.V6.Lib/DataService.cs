
using System;
using System.IO;
using System.Text;

namespace Tyuiu.AjtkuzhinovEE.Sprint7.V6.Lib
{
    public class DataService
    {
        static DataService()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }


        //Загрузка файла
        public string[,] LoadFromFile(string path)
        {
            // Проверяем есть ли файл
            if (!File.Exists(path))
                return new string[0, 0];

            // Читаемстроки
            string[] lines = File.ReadAllLines(path, Encoding.GetEncoding(1251));

            // Если файл пустой
            if (lines.Length == 0)
                return new string[0, 0];

            // Определяем разделитель (;)
            char separator = lines[0].Contains(';') ? ';' : ',';

            //размеры матрицы
            int rows = lines.Length;
            int columns = lines[0].Split(separator).Length;

            // Создаем матрицу
            string[,] matrix = new string[rows, columns];

            //Заполняем матрицу
            for (int i = 0; i < rows; i++)
            {
                string[] parts = lines[i].Split(separator);
                for (int j = 0; j < columns; j++)
                {
                    if (j < parts.Length)
                        matrix[i, j] = parts[j].Trim();
                    else
                        matrix[i, j] = "";
                }
            }

            return matrix;
        }

        //Сохранить матрицу в файл
        public void SaveToFile(string path, string[,] matrix)
        {
            StringBuilder csv = new StringBuilder();

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                string[] row = new string[columns];
                for (int j = 0; j < columns; j++)
                {
                    row[j] = matrix[i, j];
                }
                csv.AppendLine(string.Join(";", row));
            }

            File.WriteAllText(path, csv.ToString(), Encoding.GetEncoding(1251));
        }

        //поиск по матрице
        public string[,] SearchInMatrix(string[,] matrix, string searchWord)
        {
            if (string.IsNullOrEmpty(searchWord))
                return matrix;

            //Кол-во подходящих строк
            int foundCount = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            //подсчет !!
            for (int i = 1; i < rows; i++) // с 1, чтобы пропустить заголовок
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j].Contains(searchWord, StringComparison.OrdinalIgnoreCase))
                    {
                        foundCount++;
                        break;
                    }
                }
            }

            // Создаем новую матрицу для результата
            string[,] result = new string[foundCount + 1, cols]; // +1 для заголовка

            //Копируем заголовок
            for (int j = 0; j < cols; j++)
            {
                result[0, j] = matrix[0, j];
            }

            //заполнение  !!
            int currentRow = 1;
            for (int i = 1; i < rows; i++)
            {
                bool found = false;
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j].Contains(searchWord, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result[currentRow, j] = matrix[i, j];
                    }
                    currentRow++;
                }
            }

            return result;
        }

        //Сортировкв матрицы по столбцу
        public string[,] SortMatrixByColumn(string[,] matrix, int columnIndex, bool ascending = true)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows <= 1) return matrix; // только заголовок,иначе пусто

            //Создаем временный массив( для строк данных (без заголовка))
            string[][] dataRows = new string[rows - 1][];

            for (int i = 0; i < rows - 1; i++)
            {
                dataRows[i] = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    dataRows[i][j] = matrix[i + 1, j];
                }
            }

            //Сортируем
            if (ascending)
                Array.Sort(dataRows, (a, b) => string.Compare(a[columnIndex], b[columnIndex]));
            else
                Array.Sort(dataRows, (a, b) => string.Compare(b[columnIndex], a[columnIndex]));

            // Создаем новую матрицу
            string[,] sortedMatrix = new string[rows, cols];

            //Копируем заголовок
            for (int j = 0; j < cols; j++)
            {
                sortedMatrix[0, j] = matrix[0, j];
            }

            // Копируем (отсортированные) данные
            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sortedMatrix[i + 1, j] = dataRows[i][j];
                }
            }

            return sortedMatrix;
        }

        //Получаем все строки, где в столбце нужное значение
        public string[,] FilterByColumnValue(string[,] matrix, int columnIndex, string filterValue)
        {
            if (string.IsNullOrEmpty(filterValue))
                return matrix;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            //Считаем нужные строки
            int filteredCount = 0;
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, columnIndex].Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    filteredCount++;
            }

            //Создаем новую матрицу
            string[,] result = new string[filteredCount + 1, cols];

            //Копируем заголовок
            for (int j = 0; j < cols; j++)
            {
                result[0, j] = matrix[0, j];
            }

            //Копируем нужные строки
            int currentRow = 1;
            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, columnIndex].Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result[currentRow, j] = matrix[i, j];
                    }
                    currentRow++;
                }
            }

            return result;
        }

        //Считаем сколько раз встречается значение в столбце
        public string[,] GetColumnStatistics(string[,] matrix, int columnIndex)
        {
            int rows = matrix.GetLength(0);
            if (rows <= 1) return new string[0, 2];

            // Используем Dictionary для подсчета
            var counts = new System.Collections.Generic.Dictionary<string, int>();

            for (int i = 1; i < rows; i++)
            {
                string value = matrix[i, columnIndex];
                if (counts.ContainsKey(value))
                    counts[value]++;
                else
                    counts[value] = 1;
            }

            // Создаем матрицу для статистики
            string[,] stats = new string[counts.Count + 1, 2];
            stats[0, 0] = "Значение";
            stats[0, 1] = "Количество";

            int row = 1;
            foreach (var item in counts)
            {
                stats[row, 0] = item.Key;
                stats[row, 1] = item.Value.ToString();
                row++;
            }

            return stats;
        }

        //Получим все (уникальные) значения из столбца
        public string[] GetUniqueValues(string[,] matrix, int columnIndex)
        {
            int rows = matrix.GetLength(0);
            if (rows <= 1) return new string[0];

            var uniqueValues = new System.Collections.Generic.HashSet<string>();

            for (int i = 1; i < rows; i++)
            {
                string value = matrix[i, columnIndex];
                if (!string.IsNullOrEmpty(value))
                    uniqueValues.Add(value);
            }

            string[] result = new string[uniqueValues.Count];
            uniqueValues.CopyTo(result);

            return result;
        }

        //Получаем кол-во пациентов
        public int GetPatientCount(string[,] matrix)
        {
            //Кол-во строк минус заголовок
            return matrix.GetLength(0) - 1;
        }

        //Получаем кол-во пациентов на диспансерном учете
        public int GetOnDispensaryCount(string[,] matrix)
        {
            int count = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Найдем индекс столбца "Диспансерный_Учет"
            int columnIndex = -1;
            for (int j = 0; j < cols; j++)
            {
                if (matrix[0, j].Contains("Диспансерный") || matrix[0, j].Contains("Учет"))
                {
                    columnIndex = j;
                    break;
                }
            }

            if (columnIndex == -1) return 0;

            for (int i = 1; i < rows; i++)
            {
                if (matrix[i, columnIndex].ToLower() == "да")
                    count++;
            }

            return count;
        }

        //Получаем самое частое значение в столбце
        public string GetMostFrequentValue(string[,] matrix, int columnIndex)
        {
            var stats = GetColumnStatistics(matrix, columnIndex);
            if (stats.GetLength(0) <= 1) return "";

            string mostFrequent = "";
            int maxCount = 0;

            for (int i = 1; i < stats.GetLength(0); i++)
            {
                int count = int.Parse(stats[i, 1]);
                if (count > maxCount)
                {
                    maxCount = count;
                    mostFrequent = stats[i, 0];
                }
            }

            return mostFrequent;
        }
    }
}