# Отчёт по лабораторной работе №1

## Задание
Реализовать программу на Windows Forms, которая позволяет рассчитывать информационные характеристики (энтропию, условную энтропию, совместную энтропию и взаимную информацию) на основе заданных ансамблей событий и матриц условных вероятностей.
Программа должна предоставлять выбор одного из вариантов задачи и выводить результат в удобной форме.

## Как я выполнял задание
Я делал эту работу в Visual Studio, используя язык C# и технологию Windows Forms. Сначала я создал главную форму с радиокнопками для выбора варианта задачи и кнопкой, которая открывает нужное окно. Затем сделал отдельные формы, где можно ввести количество строк и столбцов, задать матрицу условных вероятностей и ансамбли. Для ввода данных использовал стандартные элементы управления, такие как TextBox, Label, Button и DataGridView. Дальше я написал обработчики кнопок, которые считывали значения из таблиц, проверяли правильность данных и переводили их в числа, учитывая, что разделитель может быть и точкой, и запятой. После этого реализовал вычисления: энтропию ансамблей, условные и совместные энтропии, а также взаимную информацию. Результаты я собирал в текст и выводил в отдельной форме, чтобы все было наглядно и удобно читать.
## Интерфейс программы
### Главная форма (Form1):
![](https://github.com/manabreako/python/blob/main/lab1/Screenshot_1.png)
### Форма с вводом данных:
![](https://github.com/manabreako/python/blob/main/lab1/Screenshot_3.png)
### Форма с результатами :
![](https://github.com/manabreako/python/blob/main/lab1/Screenshot_4.png)

## Что использовал?
В проекте использовались несколько основных блоков кода:
Главная форма (Form1) – служит для выбора варианта задачи через радиокнопки и открытия нужного окна.
Form2 и Form4 – формы для ввода исходных данных (ансамбли и условные вероятности) через таблицы и текстовые поля, а также для запуска расчётов.
EndForm – форма для работы с матрицей совместных вероятностей и вычислений всех необходимых энтропий и взаимной информации.
FormResults – отдельное окно, где выводятся результаты в удобном текстовом виде.
DataGridView, TextBox, Button – использовались для ввода данных, запуска вычислений и отображения таблиц вероятностей.
Функции для вычислений – отдельные методы для нахождения энтропии, условной энтропии, совместной энтропии и взаимной информации.
Все блоки кода связаны между собой: данные вводятся в формах, обрабатываются в методах, а результат отображается в итоговой форме.

## Главная форма (Form1)
Создание радиокнопок и кнопки «Выбрать».
В обработчике кнопки я проверяю, какая радиокнопка выбрана, и открываю соответствующую форму.
```
using System;
using System.Windows.Forms;

namespace TeoryFear
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "Выбрать"
        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (radioA.Checked)
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
            else if (radioB.Checked)
            {
                Form4 form4 = new Form4();
                form4.Show();
            }
            else if (radioAB.Checked)
            {
                EndForm form5 = new EndForm();
                form5.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
```
![](https://github.com/manabreako/python/blob/main/lab1/Screenshot_1.png)

## Формы для расчётов:
Обработчик «Задать размеры матрицы» — создает таблицу нужного размера.
Обработчик «Рассчитать» — считывает данные из таблиц, проверяет корректность, переводит запятые в точки.
Реализованы функции для вычисления: энтропии ансамбля, условной энтропии, совместной энтропии, взаимной информации.
Все результаты собираются в текст и передаются в форму FormResults.
### Form2
```
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
```
![](https://github.com/manabreako/python/blob/main/lab1/Screenshot_3.png)

## Форма результатов (FormResults):
Принимает строку с результатами и отображает её в текстовом поле.
```
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeoryFear
{
    public partial class FormResults: Form
    {
        public FormResults()
        {
            InitializeComponent();
        }
        public FormResults(string results) : this()
        {
            // Обязательно InitializeComponent() уже вызван в базовом конструкторе (.ctor)
            txtResults.Text = results;
        }

        private void FormResults_Load(object sender, EventArgs e)
        {

        }

        private void txtResults_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
```
![](https://github.com/manabreako/python/blob/main/lab1/Screenshot_4.png)

## Трудности, с которыми столкнулся

Основная сложность была в работе с таблицами DataGridView, потому что нужно было правильно задавать их размеры и считывать данные из ячеек. Еще проблемой было то, что пользователи могут вводить дробные числа и через запятую, и через точку, из-за чего возникали ошибки при преобразовании, поэтому пришлось написать замену запятых на точки. Также пришлось учитывать, что сумма вероятностей должна быть равна единице, и сделать проверки с предупреждениями для пользователя. Немного запутанным оказалось и вычисление разных видов энтропий, особенно условной и совместной, но постепенно я разобрался с формулами. Еще одна трудность заключалась в том, что программа состоит из нескольких форм, и нужно было организовать их взаимодействие, но в итоге это сделало проект более удобным и понятным.

![](https://github.com/manabreako/python/blob/main/lab1/ccb0de0deb8003cf755dc7f73ec6926f.jpg)

