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
        var workTasks = new List<Task>
        {
            SetOffJobProcessor(_tokenSource.Token, new JobProcessor()),
            ListenForCancellation(_tokenSource.Token)
        };

        await Task.WhenAny(workTasks);
    }

    private async Task SetOffJobProcessor(CancellationToken token, JobProcessor processor)
    {
        await processor.DoTheHeftyWork(token);
    }

    private async Task ListenForCancellation(CancellationToken token)
    {
        Console.WriteLine($"Checking for cancellation, press {_keyToStop} to stop this job");
        while (true)
        {
            try
            {
                if (Console.ReadKey().Key == _keyToStop)
                {
                    _tokenSource.Cancel();
                    break;
                }
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("Exception caught in the listener");
            }
        }
    }
}
