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
