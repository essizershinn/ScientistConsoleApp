namespace ScientistConsoleApp
{
    static class MemeBot3000
    {
        public static bool IsMeme(string phrase)
        {
            return !string.IsNullOrWhiteSpace(phrase) 
                && phrase.ToUpperInvariant().Contains("SQUIRREL");
        }
    }
}