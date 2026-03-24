namespace StudentGradeManager;

class Program
{
    static void Main()
    {
        bool userIsDone = false;
        var studentList = new List<Student>();
        var numOfStudents = 0;
        bool isValid = false;

        do
        {
            do
            {
                Console.WriteLine("How many students do you want to enter? (min 1, max 10)");

                var input = Console.ReadLine();

                if (int.TryParse(input, out numOfStudents))
                {
                    if (numOfStudents > 0 && numOfStudents < 11)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Number is out of range, please enter a number 1 through 10.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid number 1 through 10.");
                }
            } while (!isValid);

            Console.WriteLine($"{numOfStudents} students entered.");

            for (int i = 0; i < numOfStudents; i++)
            {
                var student = new Student();

                Console.WriteLine($"Enter a student {i + 1}'s name:");
                student.Name = Console.ReadLine();
                student.Test1 = GetScore("Test 1");
                student.Test2 = GetScore("Test 2");
                student.Test3 = GetScore("Test 3");

                studentList.Add(student);
            }

            double classAverageTotal = 0;
            double classAverage = 0;
            double maxAverage = 0;
            Console.WriteLine("Summary:");
            foreach (var student in studentList)
            {
                double averageScore = GetAverage(student.Test1, student.Test2, student.Test3);
                string grade = GetGrade(averageScore);
                classAverageTotal += averageScore;
                classAverage = classAverageTotal / studentList.Count;
                maxAverage = averageScore > maxAverage ? averageScore : maxAverage;

                Console.WriteLine($"{student.Name}: Average Score: {Math.Round(averageScore, 2)} Grade: {grade}");
            }
            ;

            Console.WriteLine($"Class Average: {Math.Round(classAverage, 2)}");
            Console.WriteLine($"Highest Student Average: {Math.Round(maxAverage, 2)}");

            Console.WriteLine("Do you want to run the program again? (yes/no)");
            var userChoice = Console.ReadLine().ToLower();
            if (userChoice == "n" || userChoice == "no")
            {
                Console.WriteLine("Exiting program, goodbye!");
                userIsDone = true;
            }
        } while (!userIsDone);
    } //end of Main

    static int GetScore(string test)
    {
        int testScore = 0;
        while (true)
        {
            Console.WriteLine($"Please enter the {test} score (0-100):");
            if (int.TryParse(Console.ReadLine(), out testScore) && testScore >= 0 && testScore <= 100)
            {
                return testScore;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }

    static double GetAverage(double t1, double t2, double t3)
    {
        double average = 0;
        average = (t1 + t2 + t3) / 3;
        return average;
    }

    static string GetGrade(double n)
    {
        if (n >= 90 && n <= 100)
        {
            return "A";
        }
        else if (n >= 80)
        {
            return "B";
        }
        else if (n >= 70)
        {
            return "C";
        }
        else if (n >= 60)
        {
            return "D";
        }
        else
        {
            return "F";
        }
    }
}