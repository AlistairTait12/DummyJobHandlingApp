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

    public ConsoleKey KeyToStop => _keyToStop;
    public CancellationTokenSource TokenSource => _tokenSource;

    public async Task DoWork()
    {
        var workTasks = new List<Task>
        {
            SetOffJobProcessor(_tokenSource.Token, new JobProcessor())
        };

        await Task.WhenAny(workTasks);
    }

    private async Task SetOffJobProcessor(CancellationToken token, JobProcessor processor)
    {
        await processor.DoTheHeftyWork(token);
    }
}
