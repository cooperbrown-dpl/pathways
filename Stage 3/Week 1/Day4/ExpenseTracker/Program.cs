var userChoice = false;
var expenseList = new List<Expense>();
var numOfExpenses = 0;

do
{
    Console.WriteLine("How many expenses do you want to enter? (Min 1, max 8)");

    var valid = false;
    while (!valid)
    {
        var input = Console.ReadLine();
        if(int.TryParse(input, out numOfExpenses) && numOfExpenses > 0 && numOfExpenses < 9)
        {
            valid = true;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number between 1 and 8.");
        }
    }

    decimal total = 0;
    decimal max = 0;
    for (int i = 0; i < numOfExpenses; i++)
    {
        var expense = new Expense();

        Console.WriteLine($"Enter expense {i + 1}'s description:");
        expense.Description = Console.ReadLine();

        bool validAmount = false;
        while (!validAmount)
        {
            Console.WriteLine($"Enter expense {i + 1}'s amount:");
            var amountInput = Console.ReadLine();
            if (decimal.TryParse(amountInput, out decimal amount) && amount >= 0)
            {
                expense.Amount = amount;
                validAmount = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid non-negative number for the amount.");
            }
        }
        expenseList.Add(expense);

        total = GetTotal(expenseList);

        if (expense.Amount > max)
        {
            max = expense.Amount;
        }
    } // end of for loop

    decimal average = total / expenseList.Count;

    Console.WriteLine("Expense Summary:");

    for (int i = 0; i < expenseList.Count; i++)
    {
        Console.WriteLine($"Expense {i + 1}: {expenseList[i].Description}, Amount: {expenseList[i].Amount:C}");
    }
    
    Console.WriteLine($"Total expenses: {total:C}, Average: {average:C}, Most expensive single expense: {max:C}");

    Console.WriteLine("Do you want to run the program again? (yes/no)");
    var userInput = Console.ReadLine().ToLower();
    if (userInput == "n" || userInput == "no")
    {
        Console.WriteLine("Exiting program, goodbye!");
        userChoice = true;
    }
} while (!userChoice);

decimal GetTotal(List<Expense> expenses)
{
    decimal total = 0;
    foreach (var expense in expenses)
    {
        total += expense.Amount;
    }
    return total;
}