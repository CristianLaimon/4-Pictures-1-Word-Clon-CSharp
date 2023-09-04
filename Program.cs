using _4pictures1word.forms;
using _4pictures1word.krsutils;

namespace _4pictures1word
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new menu());
            Startup.CheckDirectories();
        }
    }
}