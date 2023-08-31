namespace _4pictures1word
{
    public partial class main : Form
    {
        private static main instance;
        public main()
        {
            InitializeComponent();
            instance = this;
        }

        public static main GetInstance()
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new main();
            }
            return instance;
        }
            

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}