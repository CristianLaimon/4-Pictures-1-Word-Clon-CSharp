namespace P122310544TM.krsutils
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