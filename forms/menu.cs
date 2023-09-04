using _4pictures1word.krsutils;
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
        private Main formsito;
        public menu()
        {
            InitializeComponent();
        }

        private void buttonJugar_Click(object sender, EventArgs e)
        {
            // Verifica si el formulario secundario ya existe
            if (this.formsito == null || this.formsito.IsDisposed)
            {
                // Si no existe o se ha cerrado, crea uno nuevo
                this.formsito = new Main();
            }

            // Muestra o restaura el formulario secundario
            formsito.Show();
            formsito.BringToFront();
            formsito.Focus();
            Hide();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
