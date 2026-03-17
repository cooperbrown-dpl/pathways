using System;

namespace MyApp
class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        int result = calc.Add(5, 3);
        Console.WriteLine("Result: " + result);

        Helper.SayHello();
    }
}