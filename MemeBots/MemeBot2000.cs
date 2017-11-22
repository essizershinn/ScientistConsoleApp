namespace ScientistConsoleApp
{
    static class MemeBot2000
    {
        public static bool IsMeme(string phrase)
        {
            return !string.IsNullOrWhiteSpace(phrase) 
                && phrase.ToUpperInvariant().Contains("KITTY");
        }
    }
}