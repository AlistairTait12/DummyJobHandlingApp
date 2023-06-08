using CansoleAppConsole.JobProcessing;

class Program
{
    static async Task Main()
    {
        var tasks = GetJobs().Select(job => job.DoWork());

        await Task.WhenAll(tasks);
        CheckForCancellations();
    }

    private static void CheckForCancellations()
    {
        while (true)
        {
            var key = Console.ReadKey();
            GetJobs().FirstOrDefault(job => job.KeyToStop == key.Key).TokenSource.Cancel();
        }
    }

    private static List<JobHandler> GetJobs() => new List<JobHandler>
    {
        new JobHandler(ConsoleKey.K, new CancellationTokenSource()),
        new JobHandler(ConsoleKey.J, new CancellationTokenSource()),
    };
}