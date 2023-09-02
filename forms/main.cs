using _4pictures1word.krsutils;
using _4pictures1word.models;
using System.CodeDom;
using System.Drawing;
using System.Text;

namespace _4pictures1word
{
    public partial class Main : Form
    {
        private Stats statsitos;
        private byte indexLetter;
        private List<Button> botonesChar;
        private List<Button> botonesLetter;
        private Palabra JSONWord;

        #region CargarForm
        public Main()
        {
            InitializeComponent();
            Cargar();
            AddSharedEvent();
            AddImages();
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
            JSONWord = GameMachine.RandomWord(); //TODO: Solucionar palabras repetidas. Es muy importante esta línea, por eso va aquí
            this.StartPosition = FormStartPosition.CenterScreen;
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
            for (int i = 0; i < JSONWord.Word.Length; i++)
            {
                botonesLetter[i].Enabled = true;
            }
        }

        private void AddImages()
        {
            byte adder = 0;

            foreach (PictureBox pb in this.Controls.OfType<PictureBox>())
            {
                pb.ImageLocation = JSONWord.Imagespath[adder];
                adder++;
            }
        }
        #endregion

        #region ChangeButtons()
        private void ChangeButtons()
        {
            //En este método wordChar se vaciará y quedará en 0 al finalizar...
            int buttonIndex;
            List<Char> wordChar = JSONWord.Word.ToCharArray().ToList();//Guardo una copia para evitar lo anterior
            Random random = new Random();
            List<Char> alphabetLore = new List<Char>(GameMachine.Alphabet);
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
        #endregion

        #region AddRemoveLetters()
        private void SharedButton_Click(object sender, EventArgs e)
        {
            Button botonClickeado = (Button)sender;

            //añadir letras
            if (indexLetter < JSONWord.Word.Length)
            {
                botonesLetter[indexLetter].Text = botonClickeado.Text;
                indexLetter++;
            }

            //Verificar última letra de la palabra 
            if(botonesLetter.Where(x => x.Enabled).OrderBy(x => Convert.ToInt32(x.Tag)).Last().Text != "")
            {
                List<Button> enableds = botonesLetter.Where(x => x.Enabled).OrderBy(x => Convert.ToInt32(x.Tag)).ToList();
                StringBuilder palabraCorrecta = new StringBuilder();


                foreach (Button b in enableds)
                {
                    palabraCorrecta.Append(b.Text); //me da cosa que haya espacios o algo
                }

                if (JSONWord.Word == palabraCorrecta.ToString())
                {
                    //testing solamente
                    MessageBox.Show("ES CORRECTO");
                }
                else
                {
                    MessageBox.Show("NO ES ESE XDD");
                }

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

        private void CorrectAnswerChecker()
        {
            //al momento de poner la letra
           
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