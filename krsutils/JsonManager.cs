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
        //public static void Serializewords()
        //{
        //    Palabra[] palabras = new Palabra[]
        //    {
        //        new Palabra("Felicidad", new string[] {@"images\zorro_1", @"images\zorro_2", @"images\zorro_3", @"images\zorro_4"})
        //    };
        //    string content = JsonConvert.SerializeObject(palabras, Formatting.Indented);
        //    string ruta = Path.Combine(Environment.CurrentDirectory, @"testdata\data.json");

        //    File.WriteAllText(ruta, content);

        //}

        //public static void Serializestats()
        //{
        //    Stats estadisticas = new Stats(0, 0, 0);
        //    string content = JsonConvert.SerializeObject(estadisticas, Formatting.Indented);
        //    string ruta = Path.Combine(Environment.CurrentDirectory, @"testdata\stats.json");
        //    File.WriteAllText(ruta, content);
        //}

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
    }
}
