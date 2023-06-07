using CansoleAppConsole.JobProcessing;

class Program
{
    static async Task Main()
    {
        var myJobs = new List<JobHandler>
        {
            new JobHandler(ConsoleKey.K, new CancellationTokenSource()),
            new JobHandler(ConsoleKey.S, new CancellationTokenSource()),
        };

        Parallel.ForEach(myJobs, async job =>
        {
            await job.DoWork();
        });
    }
}