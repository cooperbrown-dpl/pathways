// 1. Build out to support add/sub/mul/div
// 2. Support operations in lower and upper case
// 3. Convert do..while to a while loop.

var yesNo = "yes";
while(yesNo == "yes")
{
  Console.WriteLine("Enter number: ");
  var number1 = Console.ReadLine();
  var num1 = validateNumber(number1);

  Console.WriteLine("Enter number: ");
  var number2 = Console.ReadLine();
  var num2 = validateNumber(number2);

  Console.WriteLine("Enter Operation (add, sub, mul, div): ");
  var operation = Console.ReadLine().ToLower();

  switch (operation)
  {
    case "add":
      Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
      break;
    case "sub":
      Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
      break;
    case "mul":
      Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
      break;
    case "div":
      Console.WriteLine($"{num1} / {num2} = {num1 / num2}");
      break;
    default:
      Console.WriteLine("Invalid operation");
      break;
  }

  Console.WriteLine("Continue (yes/no)");
  yesNo = Console.ReadLine().ToLower();
}

Console.WriteLine("Exiting program, goodbye!");

double validateNumber(string input){
    if (double.TryParse(input, out double number))
    {
        return number;
    }
    else
    {
        Console.WriteLine("Invalid number, please try again.");
        return validateNumber(Console.ReadLine());
    }
};