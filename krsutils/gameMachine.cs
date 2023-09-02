using _4pictures1word.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _4pictures1word.krsutils
{
    public class GameMachine
    {
        private static List<char> alphabet = Enumerable.Range(65, 26).Select(letter => (Char)letter).Append('Ñ').ToList();

        private static Palabra[] repertorioActual;
        public static List<char> Alphabet { get => alphabet; }
        public static Palabra[] TotalWords { get => repertorioActual; set => repertorioActual = value; }

        public static Palabra RandomWord()
        {
            Palabra[] repertorio = JsonManager.GetJSONwords();
            TotalWords = repertorio;
            Random randomizer = new Random();
            int totalRepertorio = repertorio.Length;
            int selectedIndex = randomizer.Next(0, totalRepertorio);
            return repertorio[selectedIndex];

        }


    }
}
