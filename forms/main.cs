using _4pictures1word.krsutils;
using _4pictures1word.models;
using System.CodeDom;

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
            Cargar();
            ChangeButtons();
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

        private void Cargar()
        {
            statsitos = JsonManager.GetJSONstats();
            labelLevelNumber.Text = statsitos.Level.ToString();
            labelMoneyNumber.Text = statsitos.Money.ToString();
            
        }

        private void ChangeButtons()
        {
            int buttonIndex;
            Random random = new Random();
            List<Char> wordChar = gameMachine.RandomWord().ToCharArray().ToList();
            List<Char> alphabetLore = gameMachine.Alphabet;
            List<Button> botonesChar = this.Controls.OfType<Button>().Where(k => k.Text == "char").ToList();

            for (int i = 0; i < 14; i++)
            {
                buttonIndex = random.Next(botonesChar.Count);

                if(wordChar.Count != 0)
                {
                    int wordCharIndex = random.Next(wordChar.Count);
                    botonesChar[buttonIndex].Text = wordChar[wordCharIndex].ToString();
                    wordChar.RemoveAt(wordCharIndex);
                }
                else
                {
                    if(botonesChar.Count > 0)
                    {
                        int loreIndex = random.Next(alphabetLore.Count);
                        botonesChar[buttonIndex].Text = alphabetLore[loreIndex].ToString();
                        alphabetLore.RemoveAt(loreIndex);
                    }
                }

                botonesChar.RemoveAt(buttonIndex);
            }

 
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}