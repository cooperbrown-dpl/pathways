using System;
using System.Collections.Generic;

// Task 1: Take someones height and output to the console.
// Task 2: Add a condition that will display if you are taller than 7 ft.
// Console.WriteLine("Please enter your height in inches.");

// var height = int.Parse(Console.ReadLine());

// Console.WriteLine($"Your are {height} inches tall.");

// if (height > 84)
// {
//     Console.WriteLine("You are taller than 7 ft.");
// }
// else if (height > 79)
// {
//     Console.WriteLine("You are very tall.");
// }
// else if (height > 60)
// {
//     Console.WriteLine("You are taller than 5 ft.");
// }


var list = new List<int>();
var stack = new Stack<int>();
var queue = new Queue<int>();

while (true)
{
    Console.WriteLine("Enter a number: ");
    var input = Console.ReadLine();
    if (String.IsNullOrWhiteSpace(input))
        break;
    var number = int.Parse(input);
    list.Add(number);
    stack.Push(number);
    queue.Enqueue(number);
}

var sum = 0;

foreach (var number in list)
{
    sum += number;
}
Console.WriteLine("Foreach: The sum of the number is " + sum);

sum = 0;

for (int i = 0; i < list.Count; i++)
{
    sum += list[i];
}
Console.WriteLine("For: The sum of the numbers is " + sum);

sum = 0;
var i2 = 0;
while(i2 < list.Count)
{
    sum += list[i2];
    i2++;
}
Console.WriteLine("While: The sum of the number is " + sum);

var sumStack = 0;

  //stack: LIFO
while (stack.Count > 0)
{
    sumStack = sumStack + stack.Pop();
}
Console.WriteLine("Stack: The sum of the numbers is " + sumStack);

var sumQueue = 0;

while (queue.Count > 0)
{
    sumQueue += queue.Dequeue();
}
Console.WriteLine("Queue: The sum of the numbers is " + sumQueue);

