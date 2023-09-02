using _4pictures1word.krsutils;
using _4pictures1word.models;
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
            CargarForm();
            ChooseWord();
            ChangeButtons();
            AddSharedEvent();
            AddImages();
            EnableLetterButtons();
        }

        private void CargarForm()
        {
            statsitos = JsonManager.GetJSONstats();
            labelLevelNumber.Text = statsitos.Level.ToString();
            labelMoneyNumber.Text = statsitos.Money.ToString();
            botonesChar = this.Controls.OfType<Button>().Where(k => k.Text == "char").ToList();
            botonesLetter = this.Controls.OfType<Button>().Where(k => k.Text == "").OrderBy(k => Convert.ToInt16(k.Tag)).ToList();
            indexLetter = 0;
            this.StartPosition = FormStartPosition.CenterScreen;
            ChooseWord();
        }

        private void ChooseWord()
        {
            bool found = false;
            bool todasResueltas = true;

            while (!found) //Repite mientras found == false (no se encuentre la palabra)
            {
                JSONWord = GameMachine.RandomWord();

                for (int i = 0; i < GameMachine.TotalWords.Length; i++)
                {
                    Palabra w = GameMachine.TotalWords[i];

                    if (w.Word == JSONWord.Word && w.Resolved == false && JSONWord.Resolved == false)
                    {
                        found = true; 
                        break;
                        //Se encontr�!
                    }
                    //No se ha encontrado...

                    if (!w.Resolved) //Conque haya una Resolved False, entonces no se ha terminado
                    {
                        todasResueltas = false;
                    }

                }

                if(todasResueltas)//Para evitar while infinito cuando todas est�n resueltas
                {
                    break;
                }

            }
            
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

        #endregion CargarForm

        #region ChangeButtons()

        private void ChangeButtons()
        {
            //En este m�todo wordChar se vaciar� y quedar� en 0 al finalizar...
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

        #endregion ChangeButtons()

        #region AddRemoveLetters()

        private void SharedButton_Click(object sender, EventArgs e)
        {
            Button botonClickeado = (Button)sender;

            //a�adir letras
            if (indexLetter < JSONWord.Word.Length)
            {
                botonesLetter[indexLetter].Text = botonClickeado.Text;
                indexLetter++;
            }

            //Inhabilitar bot�n clickeado
            botonClickeado.Enabled = false;

            //Verificar �ltima letra de la palabra
            if (botonesLetter.Where(x => x.Enabled).OrderBy(x => Convert.ToInt32(x.Tag)).Last().Text != "")
            {
                List<Button> enableds = botonesLetter.Where(x => x.Enabled).OrderBy(x => Convert.ToInt32(x.Tag)).ToList();
                StringBuilder palabraCorrecta = new StringBuilder();

                foreach (Button b in enableds)
                {
                    palabraCorrecta.Append(b.Text);
                }

                if (JSONWord.Word == palabraCorrecta.ToString())
                {
                    //testing solamente
                    MessageBox.Show("ES CORRECTO"); 
                    JsonManager.UpdateJSONword(JSONWord);
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

            foreach (Button button in botonesChar)
            {
                button.Enabled = true;
            }
        }

        #endregion AddRemoveLetters()

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

        #endregion CloseForm Logic


    }
}