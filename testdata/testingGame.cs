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
        public static void testlevel()
        {
            List<Palabra> palabras = new List<Palabra>
            {
                new Palabra("Felicidad", new string[] {@"images\zorro_1", @"images\zorro_2", @"images\zorro_3", @"images\zorro_4"})

            };

            string content = JsonConvert.SerializeObject(palabras);
            string ruta = Path.Combine(Environment.CurrentDirectory, @"testdata\data.json");

            File.WriteAllText(ruta, content);


        }
    }
    
}
