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
            CargarNivel();

        }

        private void CargarNivel()
        {
            if (!GameMachine.CheckWin())
            {
                indexLetter = 0;
                statsitos = JsonManager.GetJSONstats();
                labelLevelNumber.Text = statsitos.Level.ToString();
                labelMoneyNumber.Text = statsitos.Money.ToString();
                JSONWord = GameMachine.ChooseWord();
                AddImages();
                ChangeButtons();
                LimpiarButtons();
                EnableLetterButtons();

            }
            else
            {
                MessageBox.Show("Has ganado");
                this.Close();
            }
        }

        private void CargarForm()
        {
            //Solo se ocupa a�adir una vez los eventos a los BOTONES char y despu�s reutilizar
            botonesChar = Controls.OfType<Button>().Where(k => k.Text == "char").ToList();
            AddSharedEvent();
            botonesLetter = this.Controls.OfType<Button>().Where(k => k.Text == "").OrderBy(k => Convert.ToInt16(k.Tag)).ToList();
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
            foreach (Button b in botonesLetter)
            {
                b.Enabled = false;
            }

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
            int buttonIndex;
            Random random = new Random();

            List<Char> wordChar = JSONWord.Word.ToCharArray().ToList();
            List<Char> alphabetLore = new List<Char>(GameMachine.Alphabet);

            List<Button> copyBotonesChar = new List<Button>(botonesChar);
            //List<Button> botonesChar = this.Controls.OfType<Button>().Where(k => k.Text == "char").ToList();

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

            botonesChar = copyBotonesChar; //Para que permanezca la lista para ser usado por el bot�n "eliminar" en el siguiente nivel
            copyBotonesChar = null; //Para que GC lo limpie m�s r�pido
        }

        #endregion ChangeButtons()

        #region Handlers;IMPORTANT

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
                    statsitos.Level++;
                    statsitos.Money += 20;
                    JsonManager.UpdateJSONstats(statsitos);
                    CargarNivel();
                }
                else
                {
                    MessageBox.Show("NO ES ESE XDD");
                }
            }
        }

        private void buttonEliminarLetters_Click(object sender, EventArgs e)
        {
            LimpiarButtons(); //P=ara poder usar la l�gica de este bot�n en otra parte del c�digo
        }

        private void LimpiarButtons()
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

        #endregion

        #region CloseForm Logic

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.OpenForms[0].Show();
            Application.OpenForms[0].BringToFront();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Verifica si el usuario hizo clic en la "X" para cerrar el formulario
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Cancela el cierre del formulario
                e.Cancel = true;

                // En lugar de cerrar, simplemente oculta el formulario
                this.Hide();
                Application.OpenForms[0].Show();
                Application.OpenForms[0].BringToFront();
            }
        }

        //private void Main_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    Application.OpenForms[0].Show();
        //    Application.OpenForms[0].BringToFront();
        //}
        #endregion CloseForm Logic


    }
}