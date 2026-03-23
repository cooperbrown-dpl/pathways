using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Actions & Funcs playground\n");

        SayHello("Valerie");

        Action<string> sayHello = name => Console.WriteLine($"Hello {name}!");

        sayHello("Cooper");

        Action<int> showNumber = n => Console.WriteLine($"The number is {n}");

        showNumber(7);
        showNumber(42);
        showNumber(-3);

        Func<int, int, int> add = (a, b) => a + b;
        Func<int, int, int> multiply = (a, b) => a * b;

        Console.WriteLine(add(5, 6));
        Console.WriteLine(multiply(4, 9));

        DoTwice(() => Console.WriteLine("Hi!"));
        DoTwice(() => Console.WriteLine("Click!"));

        Console.WriteLine(Calculate(10, 3, (x, y) => x + y));
        Console.WriteLine(Calculate(11, 3, (x, y) => x / y));

        Console.WriteLine("\nPress ENTER to exit...");
        Console.ReadLine();
    }


    static int Calculate(int a, int b, Func<int, int, int> operation)
    {
        return operation(a, b);
    }

    static void DoTwice(Action action)
    {
        action();
        action();
    }


    static void SayHello(string name)
    {
        Console.WriteLine($"Hello {name}!");
    }

    // You can add your own small helper methods here later
}