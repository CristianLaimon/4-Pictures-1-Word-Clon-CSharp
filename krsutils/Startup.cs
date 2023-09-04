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