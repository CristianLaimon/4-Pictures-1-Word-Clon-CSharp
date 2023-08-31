using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4pictures1word.forms
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void buttonJugar_Click(object sender, EventArgs e)
        {
            main formsito = main.GetInstance();
            formsito.Show();
            formsito.BringToFront();
            formsito.Focus();
        }
    }
}
