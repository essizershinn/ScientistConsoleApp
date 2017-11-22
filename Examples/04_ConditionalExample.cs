using System;
using System.Threading.Tasks;
using GitHub;

namespace ScientistConsoleApp
{
    static class ConditionalExample
    {
        public static bool IsMeme(string phrase)
        {
            return Scientist.Science<bool>("conditional-example", experiment => {
                experiment.AddContext("phrase", phrase);
                experiment.AddContext("when", DateTimeOffset.Now);

                // Let's say we only want to run the experiment if people are excited.
                // This means the experiment will only run when the phrase ends with an bang (!)
                experiment.RunIf(() => !string.IsNullOrWhiteSpace(phrase) && phrase.EndsWith('!'));

                experiment.Use(() => MemeBot2000.IsMeme(phrase)); // Control
                experiment.Try(() => MemeBot3000.IsMeme(phrase)); // Candidate
            });
        }
    }

    // To run this specific example, copy / paste this into Program.Main(string[])
    /*
            Scientist.ResultPublisher = new ContextualConsoleResultPublisher();
            var phrase = string.Join(" ", args);

            Console.WriteLine($"'{phrase}' is {(ConditionalExample.IsMeme(phrase) ? "" : "NOT ")}a meme.");
    */
}