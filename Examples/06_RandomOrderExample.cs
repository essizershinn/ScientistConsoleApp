using System;
using System.Threading.Tasks;
using GitHub;

namespace ScientistConsoleApp
{
    static class RandomOrderExample
    {
        public static bool IsMeme(string phrase)
        {
            return Scientist.Science<bool>("random-order-example", experiment => {
                experiment.AddContext("phrase", phrase);
                experiment.AddContext("when", DateTimeOffset.Now);

                experiment.Use(() => {
                    // Let's print out when this ran so we can see if the control ran first.
                    Console.WriteLine($"{nameof(MemeBot2000)} kicking it at {DateTimeOffset.Now.Ticks}!");
                    return MemeBot2000.IsMeme(phrase);
                });// Control
                experiment.Try(() => {
                    // Let's print out when this ran so we can see if the candidate ran first.
                    Console.WriteLine($"{nameof(MemeBot3000)} kicking it at {DateTimeOffset.Now.Ticks}!");
                    return MemeBot3000.IsMeme(phrase);
                }); // Candidate
            });
        }
    }

    // To run this specific example, copy / paste this into Program.Main(string[])
    /*
            Scientist.ResultPublisher = new ContextualConsoleResultPublisher();
            var phrase = string.Join(" ", args);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Try #{i} - '{phrase}' is {(RandomOrderExample.IsMeme(phrase) ? "" : "NOT ")}a meme.");
            }
    */
}