using _4pictures1word.krsutils;

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
            JugarLogic();
        }

        private void buttonJugar_Click_1(object sender, EventArgs e)
        {


            if (this.formsito != null)
            {
                formsito.RestartStats();
                GameMachine.permitirCierre = true;
                this.formsito.Close();
            }

            buttonContinuar.Enabled = true;
            JugarLogic();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void JugarLogic()
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

        public void UpdateMoneyNumber()
        {

          labelDineroActual.Text = $"Dinero: {formsito.Statsitos.Money}";

        }

        public void DesableContinue()
        {
            buttonContinuar.Enabled = false;
        }
    }
}