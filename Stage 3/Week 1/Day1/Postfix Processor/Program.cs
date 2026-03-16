var stack = new Stack<int>();

while (true)
{
    Console.WriteLine("Input: ");
    var input = Console.ReadLine();
    if (String.IsNullOrWhiteSpace(input))
        break;

    if (input == "+")
    {
        //add top two numbers
        var first = stack.Pop();
        var second = stack.Pop();
        var add = first + second;
        Console.WriteLine($"Adding {first} and {second} result {add}");
        stack.Push(add);
    }
    else if (input == "-")
    {
        var first = stack.Pop();
        var second = stack.Pop();
        var subtract = first - second;
        Console.WriteLine($"Subtracting {first} from {second} results in {subtract}");
        stack.Push(subtract);
    }
    else if (input == "*")
    {
        var first = stack.Pop();
        var second = stack.Pop();
        var multiply = first * second;
        Console.WriteLine($"Multiplying {first} by {second} results in {multiply}");
        stack.Push(multiply);
    }
    else if (input == "/")
    {
        var first = stack.Pop();
        var second = stack.Pop();
        var divide = first / second;
        Console.WriteLine($"Dividing {first} from {second} results in {divide}");
        stack.Push(divide);
    }
    else
    {
        stack.Push(int.Parse(input));
    }
}

while (stack.Count > 0)
{
    Console.WriteLine($"Stack {stack.Count}: {stack.Pop()}");
}