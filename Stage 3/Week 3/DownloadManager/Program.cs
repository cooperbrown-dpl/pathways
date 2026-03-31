using System;
using System.Threading.Tasks;

Console.WriteLine("Download Manager Started\n");

// TODO: Add your async methods and calls here

int size = await GetFileSize("video.mp4");
System.Console.WriteLine($"video.mp4 file size is: {size}MB");

await DownloadWithProgress("report.pdf");

await DownloadFile("report.pdf", 1);
await DownloadFile("image.jpg", 1);
await DownloadFile("data.csv", 1);

System.Console.WriteLine("All sequential downloads have been completed!");

await RunParallel();
System.Console.WriteLine("All parallel downloads completed!");

async Task DownloadFile(string filename, int seconds)
{
    System.Console.WriteLine($"Starting download: {filename}");

    await Task.Delay(seconds * 1000);
    System.Console.WriteLine($"Download completed: {filename}");
}

async Task RunParallel()
{
    var d1 = DownloadFile("movie.mp4", 2);
    var d2 = DownloadFile("music.mp3", 2);
    var d3 = DownloadFile("ebook.pdf", 2);

    await Task.WhenAll(d1, d2, d3);
}

async Task<int> GetFileSize(string filename)
{
    System.Console.WriteLine($"Calculating {filename} file size...");
    await Task.Delay(2000);
    Random rand = new Random();
    int size = rand.Next(10, 101);
    return size;
}

async Task DownloadWithProgress(string filename)
{
    System.Console.WriteLine($"Starting download: {filename}");
    await Task.Delay(1000);
    System.Console.WriteLine("Downloading report.pdf... 25% complete");
    await Task.Delay(1000);
    System.Console.WriteLine("Downloading report.pdf... 50% complete");
    await Task.Delay(1000);
    System.Console.WriteLine("Downloading report.pdf... 75% complete");
    await Task.Delay(1000);
    System.Console.WriteLine("Downloading report.pdf... 100% complete");
    System.Console.WriteLine($"Download completed: {filename}")
}