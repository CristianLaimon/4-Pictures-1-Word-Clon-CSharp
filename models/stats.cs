using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace _4pictures1word.models
{
    public class Stats
    {
        private byte level;
        private int money;
        private byte hints;



        public byte Level { get => level; set => level = value; }
        public int Money { get => money; set => money = value; }
        public byte Hints { get => hints; set => hints = value; }

        
    }
}
