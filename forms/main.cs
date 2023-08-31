using _4pictures1word.krsutils;
using _4pictures1word.models;

namespace _4pictures1word
{
    public partial class Main : Form
    {
        private static Main instance;
        private static Stats statsitos;
        public Main()
        {
            InitializeComponent();
            instance = this;
            cargarStats();

        }

        #region Properties
        public static Main GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Main();
            }
            return instance;
        }
        #endregion

        private void cargarStats()
        {
            statsitos = JsonManager.GetJSONstats();
            labelLevelNumber.Text = statsitos.Level.ToString();
            labelMoneyNumber.Text = statsitos.Money.ToString();
            gameMachine.RandomWord();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}