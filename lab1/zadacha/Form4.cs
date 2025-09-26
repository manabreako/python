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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRows.Text.Trim(), out int rows) || rows <= 0 ||
                !int.TryParse(txtCols.Text.Trim(), out int cols) || cols <= 0)
            {
                MessageBox.Show("Введите корректные целые положительные размеры (строки и столбцы).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            gridMatrix.RowCount = rows;
            gridMatrix.ColumnCount = cols;

            gridEnsemble.RowCount = 1;
            gridEnsemble.ColumnCount = cols;

            gridMatrix.AllowUserToAddRows = false;
            gridEnsemble.AllowUserToAddRows = false;
            gridMatrix.RowHeadersVisible = false;
            gridEnsemble.RowHeadersVisible = false;
        }

        private void btnCalc2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                gridEnsemble.EndEdit();
                gridMatrix.EndEdit();

                int rows = gridMatrix.RowCount;
                int cols = gridMatrix.ColumnCount;

                if (gridEnsemble.ColumnCount != cols)
                {
                    MessageBox.Show($"Ожидается {cols} значения(й) ансамбля B, а найдено {gridEnsemble.ColumnCount}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- читаем ансамбль B ---
                double[] ensembleB = new double[cols];
                for (int j = 0; j < cols; j++)
                {
                    object raw = gridEnsemble.Rows[0].Cells[j].Value;
                    string cell = raw == null ? "" : raw.ToString().Trim();
                    if (string.IsNullOrEmpty(cell))
                    {
                        MessageBox.Show($"Пустое значение ансамбля B в столбце {j + 1}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    cell = cell.Replace(',', '.');

                    if (!double.TryParse(cell, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                    {
                        MessageBox.Show($"Некорректное значение ансамбля B в столбце {j + 1}: '{raw}'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ensembleB[j] = val;
                }

                double sumB = ensembleB.Sum();
                if (Math.Abs(sumB - 1.0) > 1e-6)
                {
                    var r = MessageBox.Show($"Сумма ансамбля B = {sumB:0.####}. Продолжить вычисления?", "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (r == DialogResult.No) return;
                }

                // --- читаем матрицу p(ai/bj) ---
                double[,] matrix = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        object raw = gridMatrix.Rows[i].Cells[j].Value;
                        string cell = raw == null ? "" : raw.ToString().Trim();

                        if (string.IsNullOrEmpty(cell))
                        {
                            MessageBox.Show($"Пустое значение в матрице p(ai/bj) в строке {i + 1}, столбце {j + 1}.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cell = cell.Replace(',', '.');

                        if (!double.TryParse(cell, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                        {
                            MessageBox.Show($"Некорректное значение в матрице p(ai/bj) в строке {i + 1}, столбце {j + 1}: '{raw}'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        matrix[i, j] = val;
                    }

                    double rowSum = 0;
                    for (int j = 0; j < cols; j++) rowSum += matrix[i, j];
                    if (Math.Abs(rowSum - 1.0) > 1e-6)
                    {
                        var r = MessageBox.Show($"Сумма строк {i + 1} условных вероятностей = {rowSum:0.####}. Продолжить?", "Проверка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (r == DialogResult.No) return;
                    }
                }

                // --- вычисления ансамбля A ---
                double[] probA = new double[rows];
                for (int i = 0; i < rows; i++)
                {
                    double s = 0;
                    for (int j = 0; j < cols; j++)
                        s += ensembleB[j] * matrix[i, j];
                    probA[i] = s;
                }

                double[,] joint = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        joint[i, j] = probA[i] * matrix[i, j];

                double[,] condB = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        condB[i, j] = matrix[i, j];

                double H_B = Entropy2(ensembleB);
                double H_A = Entropy2(probA);

                double H_A_given_B = 0;
                for (int j = 0; j < cols; j++)
                    H_A_given_B += ensembleB[j] * Entropy2(GetCol2(matrix, j));

                double H_B_given_A = 0;
                for (int i = 0; i < rows; i++)
                    H_B_given_A += probA[i] * Entropy2(GetRow2(matrix, i));

                double H_AB = H_B + H_A_given_B;
                double I_AB = H_B - H_B_given_A;

                // --- формирование результата ---
                string result = "Введенные данные:\r\n\r\n";
                result += "Ансамбль B: " + string.Join(" ", ensembleB.Select(x => x.ToString("0.0000", CultureInfo.InvariantCulture))) + "\r\n";
                result += "Условные вероятности p(ai|bj):\r\n";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        result += matrix[i, j].ToString("0.0000", CultureInfo.InvariantCulture) + " ";
                    result += "\r\n";
                }

                result += "\r\nРезультаты:\r\n";
                result += "Ансамбль A: " + string.Join(" ", probA.Select(x => x.ToString("0.0000", CultureInfo.InvariantCulture))) + "\r\n";
                result += $"Энтропия H(A): {H_A:0.0000}\r\n";
                result += $"Энтропия H(B): {H_B:0.0000}\r\n";
                result += $"Условная энтропия H(A|B): {H_A_given_B:0.0000}\r\n";
                result += $"Условная энтропия H(B|A): {H_B_given_A:0.0000}\r\n";
                result += $"Совместная энтропия H(AB): {H_AB:0.0000}\r\n";
                result += $"Взаимная информация I(A;B): {I_AB:0.0000}\r\n\r\n";

                result += "Матрица совместных вероятностей P(a_i, b_j):\r\n";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        result += joint[i, j].ToString("0.0000", CultureInfo.InvariantCulture) + " ";
                    result += "\r\n";
                }

                result += "\r\nМатрица условных вероятностей P(b_j | a_i):\r\n";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        result += condB[i, j].ToString("0.0000", CultureInfo.InvariantCulture) + " ";
                    result += "\r\n";
                }

                FormResults frm = new FormResults(result);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вычислениях: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private double Entropy2(double[] probs)
        {
            double h = 0;
            foreach (var p in probs)
                if (p > 0) h -= p * Math.Log(p, 2);
            return h;
        }

        private double[] GetRow2(double[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            double[] res = new double[cols];
            for (int j = 0; j < cols; j++) res[j] = matrix[row, j];
            return res;
        }

        private double[] GetCol2(double[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            double[] res = new double[rows];
            for (int i = 0; i < rows; i++) res[i] = matrix[i, col];
            return res;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}