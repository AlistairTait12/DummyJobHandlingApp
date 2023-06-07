using System.Diagnostics;

namespace CansoleAppConsole.JobProcessing;

public class JobProcessor
{
    public async Task DoTheHeftyWork(CancellationToken cancellationToken)
    {
        try
        {
            await DrillSomeHoles(cancellationToken);
            await MoveTheBoxes(cancellationToken);
            await FillTheBucket(cancellationToken);
            await WriteTheReport(cancellationToken);
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine("Operation cancelled");
            Console.WriteLine(ex.Message.ToString());
        }
    }

    private async Task DrillSomeHoles(CancellationToken cancellationToken)
    {
        Console.WriteLine("Drilling some holes\r\n");
        await Task.Delay(2000, cancellationToken);
    }

    private async Task MoveTheBoxes(CancellationToken cancellationToken)
    {
        Console.WriteLine("Moving the Boxes\r\n");
        await Task.Delay(3000, cancellationToken);
    }

    private async Task FillTheBucket(CancellationToken cancellationToken)
    {
        Console.WriteLine("Filling the bucket\r\n");
        await Task.Delay(5000, cancellationToken);
    }

    private async Task WriteTheReport(CancellationToken cancellationToken)
    {
        Console.WriteLine("Writing the report\r\n");
        await Task.Delay(3000, cancellationToken);
        SayTokenWasCancelled(cancellationToken);
        Console.WriteLine("Finished!");
    }

    private void SayTokenWasCancelled(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Cancellation was requested");
        }
    }
}
