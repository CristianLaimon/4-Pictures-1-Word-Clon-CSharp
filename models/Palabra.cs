using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4pictures1word.models
{
    internal class Palabra
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
