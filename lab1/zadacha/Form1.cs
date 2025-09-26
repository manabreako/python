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

