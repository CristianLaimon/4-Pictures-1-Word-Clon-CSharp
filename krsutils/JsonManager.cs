using _4pictures1word.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4pictures1word.krsutils
{
    public static class JsonManager
    {

        public static Stats GetJSONstats()
        {
            string text = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"testdata\stats.json"));

            Stats importedStats = JsonConvert.DeserializeObject<Stats>(text);

            return importedStats;
        }

        public static Palabra[] GetJSONwords()
        {
            string ruta = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"testdata\data.json"));
            Palabra[] output = JsonConvert.DeserializeObject<Palabra[]>(ruta);
            return output;
        }

        public static void UpdateJSONword(Palabra updatedWord)
        {
            //Para este punto ya debería de estar actualizado el repertorio con la palabra ya hecha
            updatedWord.Resolved = true;

            for (int i = 0; i < GameMachine.TotalWords.Length; i++)
            {
                if (GameMachine.TotalWords[i].Word == updatedWord.Word)
                {
                    GameMachine.TotalWords[i] = updatedWord;
                    break;
                }
            }

            string inputJSON = JsonConvert.SerializeObject(GameMachine.TotalWords, Formatting.Indented);
            File.WriteAllText(@"testdata\data.json", inputJSON);


        }

        public static void UpdateJSONstats(Stats updatedStats)
        {
            string inputJSON = JsonConvert.SerializeObject(updatedStats, Formatting.Indented);
            File.WriteAllText(@"testdata\stats.json", inputJSON);
        }
    }
}
