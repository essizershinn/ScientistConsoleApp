using System;
using System.Threading.Tasks;
using GitHub;

namespace ScientistConsoleApp
{
    static class SamplingExample
    {
        // Yes this isn't perfectly random but fine for demonstration purposes
        static readonly Random rng = new Random();

        public static bool IsMeme(string phrase)
        {
            return Scientist.Science<bool>("sampling-example", experiment => {
                experiment.AddContext("phrase", phrase);
                experiment.AddContext("when", DateTimeOffset.Now);

                // Let's say we only want to run the experiment 50% of the time                
                experiment.RunIf(() => rng.Next(10) < 5);

                experiment.Use(() => MemeBot2000.IsMeme(phrase)); // Control
                experiment.Try(() => MemeBot3000.IsMeme(phrase)); // Candidate
            });
        }
    }

    // To run this specific example, copy / paste this into Program.Main(string[])
    /*
            Scientist.ResultPublisher = new ContextualConsoleResultPublisher();
            var phrase = string.Join(" ", args);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Try #{i} - '{phrase}' is {(SamplingExample.IsMeme(phrase) ? "" : "NOT ")}a meme.");
            }
    */
}