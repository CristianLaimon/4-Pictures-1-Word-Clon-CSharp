using _4pictures1word.forms;
using _4pictures1word.krsutils;
using _4pictures1word.testdata;

namespace _4pictures1word
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new menu());
            Startup.CheckDirectories();


            //solo debugging y ya
            testingGame.testlevel();
        }
    }
}