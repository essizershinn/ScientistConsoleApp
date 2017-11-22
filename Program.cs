using GitHub;
using System;
using System.Threading.Tasks;

namespace ScientistConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var phrase = string.Join(" ", args);

            Console.WriteLine($"'{phrase}' is {(MemeBot2000.IsMeme(phrase) ? "" : "NOT ")}a meme.");
        }
    }
}
