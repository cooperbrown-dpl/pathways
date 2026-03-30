using System;
using System.Threading.Tasks;

Console.WriteLine("Recipe Timer started");

// TODO: Add your async methods and calls here

Console.WriteLine("You can still type while waiting...");

await CookStep("Boil water", 1);
await CookStep("Cook pasta", 1);
await CookStep("Make sauce", 1);

System.Console.WriteLine("Recipe complete!");

await RunParallel();

Console.WriteLine("Program finished.");
Console.ReadLine();

async Task CookStep(string stepName, int seconds)
{
    System.Console.WriteLine($"Starting {stepName}");
    await Task.Delay(seconds * 1000);
    System.Console.WriteLine($"Finshed: {stepName}");
}

async Task RunParallel()
{
    var chop = CookStep("Chop vegetables", 3);
    var preheat = CookStep("Preheat oven", 3);

    await Task.WhenAll(chop, preheat);
}