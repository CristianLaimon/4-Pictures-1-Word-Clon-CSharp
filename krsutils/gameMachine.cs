using _4pictures1word.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _4pictures1word.krsutils
{
    public class gameMachine
    {
        private static List<char> alphabet = Enumerable.Range(65, 26).Select(letter => (Char)letter).Append('Ñ').ToList();

        public static List<char> Alphabet { get => alphabet; }

        public static string RandomWord()
        {
            Random randomizer = new Random();
            Palabra[] repertorio = JsonManager.GetJSONwords();
            int totalRepertorio = repertorio.Length;
            int selectedIndex = randomizer.Next(0, totalRepertorio);

            return repertorio[selectedIndex].Word;
        }


    }
}
