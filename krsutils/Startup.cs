using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4pictures1word.krsutils
{
    internal static class Startup
    {
        public static void CheckDirectories()
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }
        }
    }
}
