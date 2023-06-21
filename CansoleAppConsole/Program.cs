using CansoleAppConsole.JobProcessing;

class Program
{
    static async Task Main()
    {
        var tasks = GetJobs().Select(job => job.DoWork());

        await Task.WhenAll(tasks);
    }

    private static List<JobHandler> GetJobs() => new List<JobHandler>
    {
        new JobHandler(),
        new JobHandler(),
    };
}