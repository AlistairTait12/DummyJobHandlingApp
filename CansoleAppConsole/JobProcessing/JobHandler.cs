using System.Diagnostics;

namespace CansoleAppConsole.JobProcessing;

public class JobHandler
{
    private readonly ConsoleKey _keyToStop;
    private readonly CancellationTokenSource _tokenSource;

    public JobHandler(ConsoleKey keyToStop, CancellationTokenSource tokenSource)
    {
        _keyToStop = keyToStop;
        _tokenSource = tokenSource;
    }

    public async Task DoWork()
    {
        var tasks = new List<Task>
        {
            SetOffJobProcessor(_tokenSource.Token, new JobProcessor()),
            CheckForCancellation()
        };

        await Task.WhenAny(tasks);
    }

    private async Task SetOffJobProcessor(CancellationToken token, JobProcessor processor)
    {
        await processor.DoTheHeftyWork(token);
    }

    private async Task CheckForCancellation()
    {
        Console.WriteLine($"Checking for cancellation, press {_keyToStop} to stop this job");
        while (Console.ReadKey().Key != _keyToStop)
        {
            await Task.Delay(1000);
        }

        _tokenSource.Cancel();
    }
}
