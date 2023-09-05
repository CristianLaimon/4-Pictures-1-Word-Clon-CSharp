using P122310544TM.forms;
using P122310544TM.krsutils;
using P122310544TM.models;
using Newtonsoft.Json;
using System.Text;
using System.Windows.Forms;

namespace P122310544TM
{
    public partial class Main : Form
    {
        private Stats statsitos;
        private byte indexLetter;
        private List<Button> botonesChar;
        private List<Button> botonesLetter;
        private List<Char> distinctChar;
        private Palabra JSONWord;

        public Stats Statsitos { get => statsitos; }

        #region CargarForm

        public Main()
        {
            InitializeComponent();
            CargarForm();
            CargarNivel();
        }

        private void CargarForm()
        {
            //Realmente nunca se cierra, solo se esconde.Solo se cerrará cuando gane el juego para que se reinicie. Cuando se reinicia
            //tiene que evitar que se cierra y para eso es lo siguiente, hasta que vuelva a ganar y así repetirse
            if (GameMachine.permitirCierre == true) GameMachine.permitirCierre = false;

            //Solo se ocupa añadir una vez los eventos a los BOTONES char y después reutilizar
            botonesChar = Controls.OfType<Button>().Where(k => k.Text == "char").ToList();
            AddSharedEvent();
            botonesLetter = this.Controls.OfType<Button>().Where(k => k.Text == "").OrderBy(k => Convert.ToInt16(k.Tag)).ToList();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void CargarNivel()
        {
            if (!GameMachine.CheckWin())
            {
                indexLetter = 0;
                statsitos = JsonManager.GetJSONstats();
                labelLevelNumber.Text = Statsitos.Level.ToString();
                labelMoneyNumber.Text = Statsitos.Money.ToString();
                JSONWord = GameMachine.ChooseWord();
                distinctChar = JSONWord.Word.Distinct().ToList();

                AddButtons(distinctChar.Count * 2);

                AddImages();
                ChangeButtons();
                LimpiarButtons();
                EnableLetterButtons();
            }
            else
            {
                //Codigo de la victoria
                MessageBox.Show("Has ganado");
                Palabra[] pepe = JsonManager.GetJSONwords();

                //Reiniciar palabras
                for (int i = 0; i < pepe.Length; i++)
                {
                    pepe[i].Resolved = false;
                }

                //inhabilitar continuar del menu
                 ((menu)Application.OpenForms[0]).DesableContinue();

                //Guardar cambios
                string resetedWord = JsonConvert.SerializeObject(pepe, Formatting.Indented);
                File.WriteAllText(@"testdata\data.json", resetedWord);
                GameMachine.permitirCierre = true;

                this.Close();
            }
        }



        public void RestartStats()
        {
            Statsitos.Level = 1;
            Statsitos.Money = 0;
            JsonManager.UpdateJSONstats(Statsitos);
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

            //List<Char> wordChar = JSONWord.Word.ToCharArray().ToList();
            List<Char> alphabetLore = new List<Char>(GameMachine.Alphabet);
            int totalBotones = distinctChar.Count;

            List<Button> copyBotonesChar = new List<Button>(botonesChar);

            for (int i = 0; i < totalBotones * 2; i++)
            {
                buttonIndex = random.Next(distinctChar.Count);

                if (distinctChar.Count != 0)
                {
                    int wordCharIndex = random.Next(distinctChar.Count);
                    botonesChar[buttonIndex].Text = distinctChar[wordCharIndex].ToString();
                    distinctChar.RemoveAt(wordCharIndex);

                    for (int j = 0; j < alphabetLore.Count; j++)
                    {
                        if (alphabetLore[j] == botonesChar[buttonIndex].Text.ToCharArray()[0])
                        {
                            alphabetLore.RemoveAt(j);
                            break;
                        }
                    }
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

            botonesChar = copyBotonesChar; //Para que permanezca la lista para ser usado por el botón "eliminar" en el siguiente nivel
            copyBotonesChar = null; //Para que GC lo limpie más rápido
        }

        #endregion ChangeButtons()

        #region Handlers;IMPORTANT

        private void SharedButton_Click(object sender, EventArgs e)
        {
            //COMPARACION DE UN ARRAY CON OTRO ARRAY de CHARS
            Button botonClickeado = (Button)sender;
            Char charsito = botonClickeado.Text.ToCharArray()[0];

            Char[] actualChars = JSONWord.Word.ToCharArray();

            //añadir letras
            for (int i = 0; i < actualChars.Length; i++)
            {
                if (actualChars[i] == charsito)
                {
                    botonesLetter[i].Text = charsito.ToString();
                    botonClickeado.Enabled = false;
                }
            }

            //Inhabilitar botón clickeado
            botonClickeado.Enabled = false;

            //(Rework, ahora que cheque que todas están llenas)
            if (botonesLetter.Where(x => x.Enabled).All(x => x.Text != ""))
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
                    MessageBox.Show("Palabra Correcta!");
                    JsonManager.UpdateJSONword(JSONWord);
                    Statsitos.Level++;
                    Statsitos.Money += 20;
                    JsonManager.UpdateJSONstats(Statsitos);
                    UnloadButtons();
                    CargarNivel();
                }
                else
                {
                    MessageBox.Show("Palabra Incorrecta");
                }
            }
        }

        private void buttonEliminarLetters_Click(object sender, EventArgs e)
        {
            LimpiarButtons(); //P=ara poder usar la lógica de este botón en otra parte del código
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

        #endregion Handlers;IMPORTANT

        #region CloseForm Logic

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            ((menu)Application.OpenForms[0]).UpdateMoneyNumber();
            Application.OpenForms[0].Show();
            Application.OpenForms[0].BringToFront();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Verifica si el usuario hizo clic en la "X" para cerrar el formulario
            if (e.CloseReason == CloseReason.UserClosing && !GameMachine.permitirCierre)
            {
                // Cancela el cierre del formulario
                e.Cancel = true;
                // En lugar de cerrar, simplemente oculta el formulario
                this.Hide();
            }
            Application.OpenForms[0].Show();
            Application.OpenForms[0].BringToFront();
        }

        #endregion CloseForm Logic

        #region NewChanges
        private void AddButtons(int numberButtons)
        {
            if (numberButtons <= 16)
            {
                botonesChar = new List<Button>();
                for (int i = 0; i < numberButtons; i++)
                {
                    Button b = new Button();

                    b.Cursor = Cursors.Hand;
                    b.Size = new Size(49, 46);
                    b.Text = "char";
                    b.Tag = i;
                    b.UseVisualStyleBackColor = true;
                    botonesChar.Add(b);
                    flowLayoutPanel.Controls.Add(b);
                    b.Click += SharedButton_Click;
                }
            }
            else
            {
                //Para mi como programador (no sé crear excepciones todavía)
                MessageBox.Show("Error, no puedes poner mas de 16 botones");
            }
        }

        private void UnloadButtons()
        {
            foreach (Button b in botonesChar)
            {
                b.Click -= SharedButton_Click;
            }
            botonesChar.Clear();
            botonesChar = null;
            flowLayoutPanel.Controls.Clear();
        } 


        #endregion
    }
}