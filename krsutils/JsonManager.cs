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

        //public static void UpdateJSONwords(Palabra[] updatedWords)
        //{
            


        //}
    }
}
