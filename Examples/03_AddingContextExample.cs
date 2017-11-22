using System;
using System.Threading.Tasks;
using GitHub;

namespace ScientistConsoleApp
{
    static class AddingContextExample
    {
        public static bool IsMeme(string phrase)
        {
            return Scientist.Science<bool>("adding-context-example", experiment => {
                // If you add context here...
                experiment.AddContext("phrase", phrase);
                experiment.AddContext("when", DateTimeOffset.Now);

                experiment.Use(() => MemeBot2000.IsMeme(phrase)); // Control
                experiment.Try(() => MemeBot3000.IsMeme(phrase)); // Candidate
            });
        }
    }

    public class ContextualConsoleResultPublisher : IResultPublisher
    {
        public Task Publish<T, TClean>(Result<T, TClean> result)
        {
            //... use can access it here and use it!
            Console.WriteLine(
                $"{result.ExperimentName} on {result.Contexts["when"]}:" 
                    +$" results for '{result.Contexts["phrase"]}' {(result.Matched ? "matched." : "did not match." )}");
                
            foreach (var observation in result.Observations)
            {
                Console.WriteLine($"Observation '{observation.Name}' took {observation.Duration}: {observation.Value}");
            }

            return Task.CompletedTask;
        }
    }
    
    // To run this specific example, copy / paste this into Program.Main(string[])
    /*
            Scientist.ResultPublisher = new ContextualConsoleResultPublisher();
            var phrase = string.Join(" ", args);

            Console.WriteLine($"'{phrase}' is {(AddingContextExample.IsMeme(phrase) ? "" : "NOT ")}a meme.");
    */    
}

