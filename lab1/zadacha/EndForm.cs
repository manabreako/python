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
    public partial class EndForm : Form
    {
        public EndForm()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRows.Text.Trim(), out int rows) || rows <= 0 ||
                !int.TryParse(txtCols.Text.Trim(), out int cols) || cols <= 0)
            {
                MessageBox.Show("Введите корректные размеры.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            gridMatrix.RowCount = rows;
            gridMatrix.ColumnCount = cols;

            gridMatrix.AllowUserToAddRows = false;
            gridMatrix.RowHeadersVisible = false;
        }

        private void btnCalc3_Click(object sender, EventArgs e)
        {
            try
            {
                gridMatrix.EndEdit();
                int rows = gridMatrix.RowCount;
                int cols = gridMatrix.ColumnCount;

                double[,] joint = new double[rows, cols];

                // --- читаем введённые совместные вероятности ---
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        object raw = gridMatrix.Rows[i].Cells[j].Value;
                        string cell = raw?.ToString().Trim() ?? "";
                        if (string.IsNullOrEmpty(cell))
                        {
                            MessageBox.Show($"Пустое значение в ячейке [{i + 1},{j + 1}]", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        cell = cell.Replace(',', '.');

                        if (!double.TryParse(cell, NumberStyles.Any, CultureInfo.InvariantCulture, out double val))
                        {
                            MessageBox.Show($"Некорректное значение в ячейке [{i + 1},{j + 1}]: '{raw}'", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        joint[i, j] = val;
                    }
                }

                // --- вычисляем ансамбли ---
                double[] ensembleA = new double[rows];
                double[] ensembleB = new double[cols];

                for (int i = 0; i < rows; i++)
                    ensembleA[i] = Enumerable.Range(0, cols).Sum(j => joint[i, j]);

                for (int j = 0; j < cols; j++)
                    ensembleB[j] = Enumerable.Range(0, rows).Sum(i => joint[i, j]);

                // --- вычисляем условные вероятности ---
                double[,] condB_given_A = new double[rows, cols]; // P(bj|ai)
                double[,] condA_given_B = new double[rows, cols]; // P(ai|bj)

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                    {
                        condB_given_A[i, j] = ensembleA[i] > 0 ? joint[i, j] / ensembleA[i] : 0;
                        condA_given_B[i, j] = ensembleB[j] > 0 ? joint[i, j] / ensembleB[j] : 0;
                    }

                // --- энтропии ---
                double H_A = Entropy3(ensembleA);
                double H_B = Entropy3(ensembleB);

                double H_B_given_A = 0;
                for (int i = 0; i < rows; i++)
                    H_B_given_A += ensembleA[i] * Entropy3(GetRow3(condB_given_A, i));

                double H_A_given_B = 0;
                for (int j = 0; j < cols; j++)
                    H_A_given_B += ensembleB[j] * Entropy3(GetCol3(condA_given_B, j));

                double H_AB = H_A + H_B_given_A;
                double I_AB = H_A - H_A_given_B;

                // --- формируем результат ---
                string result = "Введенные данные:\r\n\r\n";
                result += "Совместные вероятности P(ai, bj):\r\n";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        result += joint[i, j].ToString("0.0000", CultureInfo.InvariantCulture) + " ";
                    result += "\r\n";
                }

                result += "\r\nРезультаты:\r\n";
                result += "Ансамбль A: " + string.Join(" ", ensembleA.Select(x => x.ToString("0.0000", CultureInfo.InvariantCulture))) + "\r\n";
                result += "Ансамбль B: " + string.Join(" ", ensembleB.Select(x => x.ToString("0.0000", CultureInfo.InvariantCulture))) + "\r\n";
                result += $"Энтропия H(A): {H_A:0.0000}\r\n";
                result += $"Энтропия H(B): {H_B:0.0000}\r\n";
                result += $"Условная энтропия H(B|A): {H_B_given_A:0.0000}\r\n";
                result += $"Условная энтропия H(A|B): {H_A_given_B:0.0000}\r\n";
                result += $"Совместная энтропия H(AB): {H_AB:0.0000}\r\n";
                result += $"Взаимная информация I(A;B): {I_AB:0.0000}\r\n\r\n";

                result += "Матрица условных вероятностей P(b_j | a_i):\r\n";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        result += condB_given_A[i, j].ToString("0.0000", CultureInfo.InvariantCulture) + " ";
                    result += "\r\n";
                }

                result += "\r\nМатрица условных вероятностей P(a_i | b_j):\r\n";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        result += condA_given_B[i, j].ToString("0.0000", CultureInfo.InvariantCulture) + " ";
                    result += "\r\n";
                }

                FormResults frm = new FormResults(result);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private double Entropy3(double[] probs)
        {
            double h = 0;
            foreach (var p in probs)
                if (p > 0) h -= p * Math.Log(p, 2);
            return h;
        }

        private double[] GetRow3(double[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            double[] res = new double[cols];
            for (int j = 0; j < cols; j++) res[j] = matrix[row, j];
            return res;
        }

        private double[] GetCol3(double[,] matrix, int col)
        {
            int rows = matrix.GetLength(0);
            double[] res = new double[rows];
            for (int i = 0; i < rows; i++) res[i] = matrix[i, col];
            return res;
        }

        private void EndForm_Load(object sender, EventArgs e)
        {

        }
    }
}