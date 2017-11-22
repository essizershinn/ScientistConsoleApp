using GitHub;

namespace ScientistConsoleApp
{
    static class BasicExample
    {
        public static bool IsMeme(string phrase)
        {
            // Runs and returns the control
            // Runs the experiment as well (but does not return it)

            // Note! This doesn't actually output or record anything about the experiment.
            // To see how that's done, look at 02-RecordingResultsExample.cs.
            return Scientist.Science<bool>("basic-example", experiment => {
                experiment.Use(() => MemeBot2000.IsMeme(phrase)); // Control
                experiment.Try(() => MemeBot3000.IsMeme(phrase)); // Candidate
            });
        }
    }

    // To run this specific example, copy / paste this into Program.Main(string[])
    /*
            var phrase = string.Join(" ", args);

            Console.WriteLine($"'{phrase}' is {(BasicExample.IsMeme(phrase) ? "" : "NOT ")}a meme.");
    */    
}