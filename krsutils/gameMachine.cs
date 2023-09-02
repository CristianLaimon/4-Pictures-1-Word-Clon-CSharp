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

        public static Palabra ChooseWord()
        {
            Palabra JSONWord = null ;
            bool found = false;
            bool todasResueltas = true; //Solo para evitar while infinito

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
                        //Se encontrï¿½!
                    }
                    //No se ha encontrado...

                    if (!w.Resolved) //Conque haya una Resolved False, entonces no se ha terminado
                    {
                        todasResueltas = false;
                    }
                }

                if (todasResueltas)
                {
                    break;
                }
            }

            return JSONWord;
        }
        public static bool CheckWin()
        {
            Palabra[] palabras = JsonManager.GetJSONwords();

            bool win = true;

            foreach( Palabra p in palabras)
            {
                if(p.Resolved == false)
                {
                    win = false;
                }
            }

            return win;
        }
    }

    
}
