using CansoleAppConsole.JobProcessing;

class Program
{
    static async Task Main()
    {
        var myJob = new JobHandler(5000, ConsoleKey.K, new CancellationTokenSource());

        await myJob.DoWork();
    }
}