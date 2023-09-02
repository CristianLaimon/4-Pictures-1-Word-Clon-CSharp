using _4pictures1word.krsutils;
using _4pictures1word.models;
using System.CodeDom;

namespace _4pictures1word
{
    public partial class Main : Form
    {
        private static Stats statsitos;
        private byte indexLetter;
        private List<Button> botonesChar;
        private List<Button> botonesLetter;
        private List<Char> wordChar;

        #region CargarForm
        public Main()
        {
            InitializeComponent();
            Cargar();
            AddSharedEvent();
            EnableLetterButtons();
            ChangeButtons();
        }

        private void Cargar()
        {
            statsitos = JsonManager.GetJSONstats();
            labelLevelNumber.Text = statsitos.Level.ToString();
            labelMoneyNumber.Text = statsitos.Money.ToString();
            botonesChar = this.Controls.OfType<Button>().Where(k => k.Text == "char").ToList();
            botonesLetter = this.Controls.OfType<Button>().Where(k => k.Text == "").OrderBy(k => Convert.ToInt16(k.Tag)).ToList();
            indexLetter = 0;
            wordChar = GameMachine.RandomWord().ToCharArray().ToList(); //TODO: Solucionar palabras repetidas. Es muy importante esta l�nea, por eso va aqu�
        }
        private void AddSharedEvent()
        {
            foreach (Button botonChar in botonesChar)
            {
                botonChar.Click += SharedButton_Click;
            }
        }

        private void EnableLetterButtons()
        {
            for (int i = 0; i < wordChar.Count; i++)
            {
                botonesLetter[i].Enabled = true;
            }
        }
        #endregion

        #region ChangeButtons()
        private void ChangeButtons()
        {
            //En este m�todo wordChar se vaciar� y quedar� en 0 al finalizar...
            int buttonIndex;
            List<Char> wordCopy = new List<Char>(wordChar);//Guardo una copia para evitar lo anterior
            Random random = new Random();
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

            wordChar = wordCopy; //Asigno la misma referencia
        }
        #endregion


        #region AddRemoveLetters()
        private void SharedButton_Click(object sender, EventArgs e)
        {
            Button botonClickeado = (Button)sender;

            //a�adir
            if (indexLetter < wordChar.Count)
            {
                botonesLetter[indexLetter].Text = botonClickeado.Text;
                indexLetter++;
            }


        }
        private void buttonEliminarLetters_Click(object sender, EventArgs e)
        {
            indexLetter = 0;
            foreach (Button button in botonesLetter)
            {
                button.Text = "";
            }
        }
        #endregion

        #region CloseForm Logic
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
        #endregion

    }
}