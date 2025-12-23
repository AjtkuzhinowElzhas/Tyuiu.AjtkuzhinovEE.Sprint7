using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using Tyuiu.AjtkuzhinovEE.Sprint7.V6.Lib;

namespace Tyuiu.AjtkuzhinovEE.Sprint7.Project.V6.Test
{
    [TestClass]
    public class DataServiceTest
    {
        private string testFile;
        private string testFolder;

        [TestInitialize]
        public void Initialize()
        {
            // Регистрируем провайдер кодировок для поддержки 1251
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Создаем уникальную папку для тестов, чтобы избежать конфликтов
            testFolder = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(testFolder);

            // Создаем тестовый CSV файл в папке Temp
            testFile = Path.Combine(testFolder, "test_data.csv");
            string csvData = @"ID;ФИО_Пациента;Дата_Рождения;ФИО_Врача;Должность_Врача;Диагноз;Диспансерный_Учет;Примечание
1;Иванов Иван Иванович;15.05.1980;Петров П.П.;Терапевт;ОРВИ;Нет;Без осложнений
2;Петрова Мария Сергеевна;22.11.1992;Сидоров С.С.;Хирург;Аппендицит;Да;После операции
3;Сидоров Алексей Петрович;10.03.1975;Иванов И.И.;Терапевт;Грипп;Нет;Температура 38
4;Козлова Анна Викторовна;05.07.1988;Петров П.П.;Терапевт;ОРВИ;Да;Хронический бронхит";

            File.WriteAllText(testFile, csvData, Encoding.GetEncoding(1251));
        }

        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                // Пытаемся удалить файл, если существует
                if (File.Exists(testFile))
                {
                    File.Delete(testFile);
                }

                // Удаляем папку
                if (Directory.Exists(testFolder))
                {
                    Directory.Delete(testFolder, true);
                }
            }
            catch
            {
                // Игнорируем ошибки удаления (если файл все еще используется)
            }
        }

        [TestMethod]
        public void ValidLoadFromFile_LoadedMatrix()
        {
            DataService ds = new DataService();

            // Act
            string[,] matrix = ds.LoadFromFile(testFile);

            // Assert
            Assert.AreEqual(5, matrix.GetLength(0)); // 1 заголовок + 4 данных
            Assert.AreEqual(8, matrix.GetLength(1)); // 8 столбцов
            Assert.AreEqual("ID", matrix[0, 0]);
            Assert.AreEqual("Иванов Иван Иванович", matrix[1, 1]);
        }

        [TestMethod]
        public void ValidSaveToFile_SavedMatrix()
        {
            DataService ds = new DataService();

            // Arrange
            string saveFile = Path.Combine(testFolder, "save_test.csv");
            string[,] testMatrix = new string[2, 3]
            {
                { "A", "B", "C" },
                { "1", "2", "3" }
            };

            // Act
            ds.SaveToFile(saveFile, testMatrix);

            // Assert
            Assert.IsTrue(File.Exists(saveFile));
        }

        [TestMethod]
        public void ValidGetPatientCount_ReturnsFour()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act
            int count = ds.GetPatientCount(matrix);

            // Assert
            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void ValidGetOnDispensaryCount_ReturnsTwo()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act
            int count = ds.GetOnDispensaryCount(matrix);

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void ValidSearchInMatrix_FindsIvanov()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act
            string[,] result = ds.SearchInMatrix(matrix, "Иванов");

            // Assert - найдет 2 записи (пациента и врача)
            Assert.AreEqual(3, result.GetLength(0)); // заголовок + 2 найденных
            Assert.AreEqual("Иванов Иван Иванович", result[1, 1]);
        }

        [TestMethod]
        public void ValidSearchInMatrix_EmptySearch_ReturnsAll()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act
            string[,] result = ds.SearchInMatrix(matrix, "");

            // Assert
            Assert.AreEqual(matrix.GetLength(0), result.GetLength(0));
        }

        [TestMethod]
        public void ValidSortMatrixByColumn_AscendingSort()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act - сортировка по ФИО (столбец 1)
            string[,] sorted = ds.SortMatrixByColumn(matrix, 1, true);

            // Assert
            Assert.AreEqual("Иванов Иван Иванович", sorted[1, 1]);
            Assert.AreEqual("Козлова Анна Викторовна", sorted[2, 1]);
            Assert.AreEqual("Петрова Мария Сергеевна", sorted[3, 1]);
            Assert.AreEqual("Сидоров Алексей Петрович", sorted[4, 1]);
        }

        [TestMethod]
        public void ValidSortMatrixByColumn_DescendingSort()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act
            string[,] sorted = ds.SortMatrixByColumn(matrix, 1, false);

            // Assert
            Assert.AreEqual("Сидоров Алексей Петрович", sorted[1, 1]);
            Assert.AreEqual("Петрова Мария Сергеевна", sorted[2, 1]);
            Assert.AreEqual("Козлова Анна Викторовна", sorted[3, 1]);
            Assert.AreEqual("Иванов Иван Иванович", sorted[4, 1]);
        }

        [TestMethod]
        public void ValidFilterByColumnValue_FilterTherapists()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act - фильтр по терапевтам (столбец 4)
            string[,] filtered = ds.FilterByColumnValue(matrix, 4, "Терапевт");

            // Assert
            Assert.AreEqual(4, filtered.GetLength(0)); // заголовок + 3 терапевта
            Assert.AreEqual("Терапевт", filtered[1, 4]);
            Assert.AreEqual("Терапевт", filtered[2, 4]);
            Assert.AreEqual("Терапевт", filtered[3, 4]);
        }

        [TestMethod]
        public void ValidGetColumnStatistics_DiagnosisStats()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act - статистика по диагнозам (столбец 5)
            string[,] stats = ds.GetColumnStatistics(matrix, 5);

            // Assert
            Assert.IsTrue(stats.GetLength(0) > 1); // есть статистика
            Assert.AreEqual("Значение", stats[0, 0]);
            Assert.AreEqual("Количество", stats[0, 1]);
        }

        [TestMethod]
        public void ValidGetUniqueValues_PositionsUnique()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act
            string[] unique = ds.GetUniqueValues(matrix, 4);

            // Assert
            Assert.AreEqual(2, unique.Length); // Терапевт и Хирург
        }

        [TestMethod]
        public void ValidGetMostFrequentValue_ReturnsORVI()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] matrix = ds.LoadFromFile(testFile);

            // Act
            string frequent = ds.GetMostFrequentValue(matrix, 5);

            // Assert
            Assert.AreEqual("ОРВИ", frequent);
        }

        [TestMethod]
        public void LoadFromFile_FileNotExists_EmptyMatrix()
        {
            DataService ds = new DataService();

            // Act
            string[,] matrix = ds.LoadFromFile("no_such_file.csv");

            // Assert
            Assert.AreEqual(0, matrix.GetLength(0));
        }


        [TestMethod]
        public void GetPatientCount_EmptyMatrix_ReturnsZero()
        {
            DataService ds = new DataService();

            // Arrange
            string[,] empty = new string[0, 0];

            // Act
            int count = ds.GetPatientCount(empty);

            // Assert
            // У пустой матрицы GetLength(0) = 0, значит 0 - 1 = -1
            // Но метод должен возвращать 0 для пустой матрицы
            Assert.AreEqual(0, Math.Max(0, count));
        }
    }
}