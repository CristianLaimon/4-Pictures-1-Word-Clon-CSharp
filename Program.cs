using P122310544TM.forms;
using P122310544TM.krsutils;

namespace P122310544TM
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