// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


List<int> numList = new List<int>();

numList.Add(8);
numList.Add(2);
numList.Add(3);
numList.Add(7);
numList.Add(9);



foreach(int num in numList)
{
    Console.WriteLine(num);
}

Console.WriteLine(numList.Average());

numList.Sort();
foreach(int num in numList)
{
    Console.WriteLine(num);
}