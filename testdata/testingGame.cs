using _4pictures1word.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace _4pictures1word.testdata
{
    internal class testingGame
    {
        public static void Serializewords()
        {
            List<Palabra> palabras = new List<Palabra>
            {
                new Palabra("Felicidad", new string[] {@"images\zorro_1", @"images\zorro_2", @"images\zorro_3", @"images\zorro_4"})
            };
            string content = JsonConvert.SerializeObject(palabras, Formatting.Indented);
            string ruta = Path.Combine(Environment.CurrentDirectory, @"testdata\data.json");

            File.WriteAllText(ruta, content);

        }

        public static void Serializestats()
        {
            Stats estadisticas = new Stats(0, 0, 0);
            string content = JsonConvert.SerializeObject(estadisticas, Formatting.Indented);
            string ruta = Path.Combine(Environment.CurrentDirectory, @"testdata\stats.json");
            File.WriteAllText(ruta, content);
        }

        
    }
    
}
