using System.Diagnostics;

namespace CansoleAppConsole.JobProcessing;

public class JobProcessor
{
    public async Task DoTheHeftyWork()
    {
        await DrillSomeHoles();
        await MoveTheBoxes();
        await FillTheBucket();
        await WriteTheReport();
    }

    private async Task DrillSomeHoles()
    {
        Console.WriteLine("Drilling some holes\r\n");
        await Task.Delay(2000);
    }

    private async Task MoveTheBoxes()
    {
        Console.WriteLine("Moving the Boxes\r\n");
        await Task.Delay(3000);
    }

    private async Task FillTheBucket()
    {
        Console.WriteLine("Filling the bucket\r\n");
        await Task.Delay(5000);
    }

    private async Task WriteTheReport()
    {
        Console.WriteLine("Writing the report\r\n");
        await Task.Delay(3000);
        Console.WriteLine("Finished!");
    }
}
