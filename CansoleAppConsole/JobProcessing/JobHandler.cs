using System.Diagnostics;

namespace CansoleAppConsole.JobProcessing;

public class JobHandler
{
    public async Task DoWork()
    {
        var workTasks = new List<Task>
        {
            SetOffJobProcessor(new JobProcessor())
        };

        await Task.WhenAny(workTasks);
    }

    private async Task SetOffJobProcessor(JobProcessor processor)
    {
        await processor.DoTheHeftyWork();
    }
}
