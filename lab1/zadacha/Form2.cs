using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeoryFear
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRows.Text.Trim(), out int rows) || rows <= 0 ||
                !int.TryParse(txtCols.Text.Trim(), out int cols) || cols <= 0)
            {
                MessageBox.Show("Введите корректные целые положительные размеры (строки и столбцы).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Подгоняем таблицы
            gridMatrix.RowCount = rows;
            gridMatrix.ColumnCount = cols;

            gridEnsemble.RowCount = 1;
            gridEnsemble.ColumnCount = rows;

            // Для удобства отключаем добавление пустых строк и скрываем заголовки строк
            gridMatrix.AllowUserToAddRows = false;
            gridEnsemble.AllowUserToAddRows = false;
            gridMatrix.RowHeadersVisible = false;
            gridEnsemble.RowHeadersVisible = false;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                // Завершаем редактирование текущей ячейки, чтобы Value был заполнен
                this.Validate();
                gridEnsemble.EndEdit();
                gridMatrix.EndEdit();

                int rows = gridMatrix.RowCount;
                int cols = gridMatrix.ColumnCount;

                // Быстрая проверка соответствия размеров
                if (gridEnsemble.ColumnCount != rows)
                {
                    MessageBox.Show($"Ожидается {rows} значения(й) ансамбля A, а найдено {gridEnsemble.ColumnCount}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- читаем ансамбль A ---
                double[] ensemble = new double[rows];
                for (int i = 0; i < rows; i++)
                {
                    object raw = gridEnsemble.Rows[0].Cells[i].Value;
                    string cell = raw == null ? "" : raw.ToString().Trim();

                    if (string.IsNullOrEmpty(cell))
                    {
                        MessageBox.Show($"Пустое значение ансамбля A в столбце {i + 1}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // принимаем как с запятой, так и с точкой
                    cell = cell.Replace(',', '.');

                    if (!double.TryParse(cell, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                    {
                        MessageBox.Show($"Некорректное значение ансамбля A в столбце {i + 1}: '{raw}' (тип: {raw?.GetType().Name ?? "null"})", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ensemble[i] = val;
                }

                // Проверка суммы ансамбля (если хочешь — можно требовать ровно 1)
                double sumA = ensemble.Sum();
                if (Math.Abs(sumA - 1.0) > 1e-6)
                {
                    var r = MessageBox.Show($"Сумма ансамбля A = {sumA:0.####}. Продолжить вычисления? (Да — продолжить, Нет — исправить ввод)", "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (r == DialogResult.No) return;
                }

                // --- читаем матрицу p(bj/ai) ---
                double[,] matrix = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        object raw = gridMatrix.Rows[i].Cells[j].Value;
                        string cell = raw == null ? "" : raw.ToString().Trim();

                        if (string.IsNullOrEmpty(cell))
                        {
                            MessageBox.Show($"Пустое значение в матрице p(bj/ai) в строке {i + 1}, столбце {j + 1}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cell = cell.Replace(',', '.');

                        if (!double.TryParse(cell, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                        {
                            MessageBox.Show($"Некорректное значение в матрице p(bj/ai) в строке {i + 1}, столбце {j + 1}: '{raw}'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        matrix[i, j] = val;
                    }

                    // опциональная проверка: сумма строки должна быть 1
                    double rowSum = 0;
                    for (int j = 0; j < cols; j++) rowSum += matrix[i, j];
                    if (Math.Abs(rowSum - 1.0) > 1e-6)
                    {
                        var r = MessageBox.Show($"Сумма строк {i + 1} условных вероятностей = {rowSum:0.####}. Продолжить?", "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (r == DialogResult.No) return;
                    }
                }

                // --- вычисления (ансамбль B, совместные, условные, энтропии) ---
                double[] probB = new double[cols];
                for (int j = 0; j < cols; j++)
                {
                    double s = 0;
                    for (int i = 0; i < rows; i++)
                        s += ensemble[i] * matrix[i, j];
                    probB[j] = s;
                }

                double[,] joint = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        joint[i, j] = ensemble[i] * matrix[i, j];

                double[,] condA = new double[rows, cols]; // P(ai|bj)
                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        condA[i, j] = probB[j] > 0 ? joint[i, j] / probB[j] : 0;
                    }
                }

                double H_A = Entropy(ensemble);
                double H_B = Entropy(probB);

                double H_B_given_A = 0;
                for (int i = 0; i < rows; i++)
                    H_B_given_A += ensemble[i] * Entropy(GetRow(matrix, i));

                double H_A_given_B = 0;
                for (int j = 0; j < cols; j++)
                    H_A_given_B += probB[j] * Entropy(GetCol(condA, j));

                double H_AB = H_A + H_B_given_A;
                double I_AB = H_A - H_A_given_B;

                // --- формирование строкового результата (формат: 4 знака после запятой) ---
                // Сначала введённые данные
                string result = "Введенные данные:\r\n\r\n";

                // Ансамбль A
                result += "Ансамбль A: " + string.Join(" ", ensemble.Select(x => x.ToString("0.0000", CultureInfo.InvariantCulture))) + "\r\n";

                // Матрица условных вероятностей p(bj|ai)
                result += "Условные вероятности p(bj|ai):\r\n";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        result += matrix[i, j].ToString("0.0000", CultureInfo.InvariantCulture) + " ";
                    result += "\r\n";
                }

                result += "\r\nРезультаты:\r\n";

                // Ансамбль B
                result += "Ансамбль B: " + string.Join(" ", probB.Select(x => x.ToString("0.0000", CultureInfo.InvariantCulture))) + "\r\n";
                result += $"Энтропия H(A): {H_A:0.0000}\r\n";
                result += $"Энтропия H(B): {H_B:0.0000}\r\n";
                result += $"Условная энтропия H(B|A): {H_B_given_A:0.0000}\r\n";
                result += $"Условная энтропия H(A|B): {H_A_given_B:0.0000}\r\n";
                result += $"Совместная энтропия H(AB): {H_AB:0.0000}\r\n";
                result += $"Взаимная информация I(A;B): {I_AB:0.0000}\r\n\r\n";

                // Матрица совместных вероятностей
                result += "Матрица совместных вероятностей P(a_i, b_j):\r\n";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        result += joint[i, j].ToString("0.0000", CultureInfo.InvariantCulture) + " ";
                    result += "\r\n";
                }

                result += "\r\nМатрица условных вероятностей P(a_i | b_j):\r\n";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        result += condA[i, j].ToString("0.0000", CultureInfo.InvariantCulture) + " ";
                    result += "\r\n";
                }

                // показываем в твоей форме результатов (предполагаем, что есть конструктор FormResults(string))
                FormResults frm = new FormResults(result);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вычислениях: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // функция энтропии (логарифм по основанию 2)
        private double Entropy(double[] probs)
        {
            double h = 0;
            foreach (var p in probs)
            {
                if (p > 0) h -= p * Math.Log(p, 2);
            }
            return h;
        }

        // вспомогательные: получить строку и столбец из матрицы
        private double[] GetRow(double[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            double[] res = new double[cols];
            for (int j = 0; j < cols; j++) res[j] = matrix[row, j];
            return res;
        }

        private double[] GetCol(double[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            double[] res = new double[rows];
            for (int i = 0; i < rows; i++) res[i] = matrix[i, col];
            return res;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}