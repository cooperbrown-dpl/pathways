using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

Console.WriteLine("Generics Practice Started\n");

// Your code for the 20 activities goes here

// 1. Create a List<int> called numbers and add the values 10, 20, 30, 40, 50. Print all numbers.

List<int> numbers = new List<int>() { 10, 20, 30, 40, 50 };
foreach (var n in numbers)
{
    System.Console.WriteLine(n);
}

// 2. Create a List<string> called names. Add five names, then print how many names are in the list using .Count.

List<string> names = new List<string> { "Bob", "John", "Fred", "Hank", "Denise" };
System.Console.WriteLine(names.Count());


// 3. Create a List<double> called prices. Add 5.99, 12.50, 3.75. Remove the first item and print the remaining prices.

List<double> prices = new List<double> { 5.99, 12.50, 3.75 };

prices.RemoveAt(0);
foreach (var p in prices)
{
    System.Console.WriteLine(p);
}

// 4. Create a List<bool> called flags and add true, false, true. Check if the list contains false and print the result.
System.Console.WriteLine("----- Activity 4 -----");
List<bool> flags = new List<bool> { true, false, true };
var result = flags.Contains(false);
System.Console.WriteLine($"Does the list flags contain a false?: {result}");

//5. Create a List<int> called scores. Add 85, 92, 78. Sort the list and print the sorted values.
System.Console.WriteLine("----- Activity 5 -----");
List<int> scores = new List<int> { 85, 92, 78 };
scores.Sort();
foreach (var s in scores)
{
    System.Console.WriteLine(s);
}

// 6. Create a Stack<int> called numbersStack. Push 100, 200, 300. Pop one value and print it.
System.Console.WriteLine("----- Activity 6 -----");
Stack<int> numbersStack = new Stack<int>();
numbersStack.Push(100);
numbersStack.Push(200);
numbersStack.Push(300);
numbersStack.Pop();
foreach (var n in numbersStack)
{
    System.Console.WriteLine(n);
}

//7. Create a Stack<string> called undoStack. Push three actions ("save", "edit", "delete"). Use Peek to see the top without removing it.
System.Console.WriteLine("----- Activity 7 -----");
Stack<string> undoStack = new Stack<string>();
undoStack.Push("save");
undoStack.Push("edit");
undoStack.Push("delete");
var top = undoStack.Peek();
System.Console.WriteLine(top);

//8. Create a Stack<char> called letters. Push A, B, C, D. Pop all items and print them (they should come out in reverse order).
System.Console.WriteLine("----- Activity 8 -----");
Stack<char> letters = new Stack<char>();
letters.Push('A');
letters.Push('B');
letters.Push('C');
letters.Push('D');

while (letters.Count > 0)
{
    System.Console.WriteLine(letters.Pop());
}

// 9. Create a Stack<int> called tempStack. Push 5 numbers. Print the count of items in the stack.
System.Console.WriteLine("----- Activity 9 -----");
Stack<int> tempStack = new Stack<int>();
tempStack.Push(1);
tempStack.Push(2);
tempStack.Push(3);
tempStack.Push(4);
tempStack.Push(5);

var count = tempStack.Count();
System.Console.WriteLine($"Count of items in tempstack: {count}");

// 10.Create a Stack<string> called browserHistory. Push three URLs.Pop one and print "Navigated back from" + the URL.
System.Console.WriteLine("----- Activity 10 -----");
Stack<string> browserHistory = new Stack<string>();
browserHistory.Push("www.youtube.com");
browserHistory.Push("www.w3schools.com");
browserHistory.Push("www.echocollective.com");
var navBackFrom = browserHistory.Pop();
System.Console.WriteLine($"Navigated back from {navBackFrom}");

// 11. Create a Queue<string> called orderQueue. Enqueue three customer names. Dequeue one and print it.
System.Console.WriteLine("----- Activity 11 -----");
Queue<string> orderedQueue = new Queue<string>();
orderedQueue.Enqueue("Bob");
orderedQueue.Enqueue("Alice");
orderedQueue.Enqueue("Carol");
System.Console.WriteLine(orderedQueue.Dequeue());

// 12. Create a Queue<int> called ticketQueue. Enqueue ticket numbers 101 to 105. Use Peek to see the next ticket without removing it.
System.Console.WriteLine("----- Activity 12 -----");

Queue<int> ticketQueue = new Queue<int>();
ticketQueue.Enqueue(101);
ticketQueue.Enqueue(102);
ticketQueue.Enqueue(103);
ticketQueue.Enqueue(104);
ticketQueue.Enqueue(105);

var nextTicket = ticketQueue.Peek();
System.Console.WriteLine($"Next ticket: {nextTicket}");

// 13. Create a Queue<string> called tasks. Enqueue "Task1", "Task2", "Task3". Dequeue all items in a loop and print them.
System.Console.WriteLine("----- Activity 13 -----");
var tasks = new Queue<string>();
tasks.Enqueue("Task 1");
tasks.Enqueue("Task 2");
tasks.Enqueue("Task 3");

while (tasks.Count > 0)
{
    System.Console.WriteLine(tasks.Dequeue());
}

// 14. Create a Queue<bool> called flagsQueue. Enqueue true, false, true. Print the count and the first item using Peek.
System.Console.WriteLine("----- Activity 14 -----");
var flagsQueue = new Queue<bool>();
flagsQueue.Enqueue(true);
flagsQueue.Enqueue(false);
flagsQueue.Enqueue(true);
var firstItem = flagsQueue.Peek();
System.Console.WriteLine($"flagsQueue count: {flagsQueue.Count}, First item in Queue: {firstItem}");

// 15. Create a Queue<double> called payments. Enqueue three amounts. Dequeue one and print "Processed payment of" + amount.
System.Console.WriteLine("----- Activity 15 -----");
var payments = new Queue<double>();
payments.Enqueue(22.49);
payments.Enqueue(10.69);
payments.Enqueue(13.29);
System.Console.WriteLine($"Processes payment of {payments.Dequeue()}");

// 16. Create a generic class Message<T> with a property T Content and a constructor that sets it. Create a Message<string> and print its content.
System.Console.WriteLine("----- Activity 16-20 -----");

Message<string> m1 = new Message<string>("Hello");
System.Console.WriteLine(m1.Content);

// 17. Create a Message<int> with value 42 and print it.
Message<int> msg2 = new Message<int>(42);
System.Console.WriteLine(msg2.Content);

// 18. Create a Message<bool> with value true and print "Status:" + value.
Message<bool> msg3 = new Message<bool>(true);
System.Console.WriteLine("Status: " + msg3.Content);

// 19. Create a Message<double> with value 99.99 and print it with a label.
Message<double> msg4 = new Message<double>(99.99);
System.Console.WriteLine($"Amount: {msg4.Content}");

// 20. Create a List<Message<string>> and add two messages. Loop through the list and print each content.
List<Message<string>> messages = new List<Message<string>>();
messages.Add(new Message<string>("Hola"));
messages.Add(new Message<string>("Gracias"));
foreach (var m in messages)
{
    System.Console.WriteLine(m.Content);
}

class Message<T>
{
    public T Content { get; set; }

    public Message(T content)
    {
        Content = content;
    }
}