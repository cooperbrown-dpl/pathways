using System;

Console.WriteLine("Lambda playground started\n");

Func<int, int> doubleNum = n => n * 2;

Console.WriteLine(doubleNum(3));

Action<string> sayNameIsAwesome = name => Console.WriteLine($"You're awesome, {name}!");

sayNameIsAwesome("Valerie");
sayNameIsAwesome("Jim");
sayNameIsAwesome("Dominic");

Func<int, bool> isItEven = n => n % 2 == 0;

Console.WriteLine($"4: {isItEven(4)}");
Console.WriteLine($"7: {isItEven(7)}");
Console.WriteLine($"0: {isItEven(0)}");
Console.WriteLine($"13: {isItEven(13)}");

Twice(() => Console.WriteLine("Hello Twice"));

Console.WriteLine(Operate(5, 5, (a, b) => a * b));

Func<string> greetingBasedOnHour = () =>
{
    int h = DateTime.Now.Hour;
    return h < 12 ? "Morning!" : h < 17 ? "Afternoon!" : "Evening!";
};

Console.WriteLine($"Good {greetingBasedOnHour()}");

Func<int, int> numSquared = n => n * n;

Console.WriteLine(numSquared(4));

Console.WriteLine("\nDone. Press ENTER to close...");
Console.ReadLine();

int Operate(int a, int b, Func<int, int, int> op)
{
    return op(a, b);
}

void Twice(Action action)
{
    action();
    action();
}
