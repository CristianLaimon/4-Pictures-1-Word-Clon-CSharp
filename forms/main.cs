using _4pictures1word.krsutils;
using _4pictures1word.models;
using System.CodeDom;

namespace _4pictures1word
{
    public partial class Main : Form
    {
        private static Stats statsitos;
        public Main()
        {
            InitializeComponent();
            Cargar();
            ChangeButtons();
        }

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
            List<Char> wordChar = GameMachine.RandomWord().ToCharArray().ToList(); //TODO: Solucionar palabras repetidas
            List<Char> alphabetLore = new GameMachine().Alphabet.ToList();
            List<Button> botonesChar = this.Controls.OfType<Button>().Where(k => k.Text == "char").ToList();

            for (int i = 0; i < 14; i++)
            {
                buttonIndex = random.Next(botonesChar.Count);

                if (wordChar.Count != 0)
                {
                    int wordCharIndex = random.Next(wordChar.Count);
                    botonesChar[buttonIndex].Text = wordChar[wordCharIndex].ToString();
                    wordChar.RemoveAt(wordCharIndex);
                }
                else
                {
                    if (botonesChar.Count > 0)
                    {
                        int loreIndex = random.Next(alphabetLore.Count);
                        botonesChar[buttonIndex].Text = alphabetLore[loreIndex].ToString();
                        alphabetLore.RemoveAt(loreIndex);
                    }
                }

                botonesChar.RemoveAt(buttonIndex);
            }


        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[0].Show();
            Application.OpenForms[0].BringToFront();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.OpenForms[0].Show();
            Application.OpenForms[0].BringToFront();
        }
    }
}