using System;
using System.Threading.Tasks;
using GitHub;

namespace ScientistConsoleApp
{
    static class RecordingResultsExample
    {
        public static bool IsMeme(string phrase)
        {
            // Runs and returns the control
            // Runs the experiment as well (but does not return it)
            return Scientist.Science<bool>("recording-results-example", experiment => {
                experiment.Use(() => MemeBot2000.IsMeme(phrase)); // Control
                experiment.Try(() => MemeBot3000.IsMeme(phrase)); // Candidate
            });
        }
    }

    // Use this by setting Scientist.ResultPublisher = new ConsoleResultPublisher()
    public class ConsoleResultPublisher : IResultPublisher
    {
        public Task Publish<T, TClean>(Result<T, TClean> result)
        {
            // As you can see, the supplied result contains a bunch of useful information:
            // Did the results match?
            // What were their actual values?
            // How long did the control / experiments take?
            // Etc.

            Console.WriteLine(
                $"{result.ExperimentName}: results {(result.Matched ? "matched." : "did not match." )}");
                
            foreach (var observation in result.Observations)
            {
                Console.WriteLine($"Observation '{observation.Name}' took {observation.Duration}: {observation.Value}");
            }

            return Task.CompletedTask;
        }
    } 
       
    // To run this specific example, copy / paste this into Program.Main(string[])
    /*
            Scientist.ResultPublisher = new ConsoleResultPublisher();
            var phrase = string.Join(" ", args);

            Console.WriteLine($"'{phrase}' is {(RecordingResultsExample.IsMeme(phrase) ? "" : "NOT ")}a meme.");
    */
}