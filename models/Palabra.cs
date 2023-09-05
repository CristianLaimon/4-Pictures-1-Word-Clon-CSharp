namespace P122310544TM.models
{
    [Serializable]
    public class Palabra
    {
        private string word;
        private bool resolved;
        private string[] imagespath;

        public Palabra(string palabra, string[] imagespath)
        {
            word = palabra;
            Imagespath = imagespath;
            Resolved = false;
        }

        public bool Resolved { get => resolved; set => resolved = value; }
        public string[] Imagespath { get => imagespath; set => imagespath = value; }
        public string Word { get => word; set => word = value; }
    }
}