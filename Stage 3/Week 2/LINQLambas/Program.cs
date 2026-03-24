using System;
using System.Collections.Generic;
using System.Linq;

var people = new List<Person>
{
    new("Mia",    24, "Berlin",   true,  3),
    new("Lucas",  31, "Lisbon",   false, 2),
    new("Aisha",  19, "Toronto",  true,  5),
    new("Noah",   42, "Austin",   true,  4),
    new("Sofia",  28, "Barcelona",false, 2),
    new("Kai",    22, "Seoul",    true,  3)
};

Console.WriteLine("LINQ + Lambda playground ready\n");

//1. All people who like coffee
//Print their names.

var likesCoffee = people.Where(p => p.LikesCoffee);
Console.WriteLine("People who like coffee:");
foreach (Person person in likesCoffee)
{
    Console.WriteLine(person.Name);
}

// 2. Names of people under 25
// Sorted from youngest to oldest.

var peopleUnder25 = people
    .Where(p => p.Age < 25)
    .OrderBy(p => p.Age)
    .Select(p => p.Name);

Console.WriteLine("People under 25, sorted youngest to oldest:");
Console.WriteLine(string.Join("\n", peopleUnder25));

// 3. Anyone from Berlin?
// Print "Yes" or "No".

var isAnyoneFromBerlin = people
    .Any(p => p.City == "Berlin");

Console.WriteLine("Is anyone from Berlin?");
Console.WriteLine(isAnyoneFromBerlin ? "Yes" : "No");

// 4. How many people have 3+ hobbies?
// Just print the number.

var numOfPeopleWithThreeOrMoreHobbies = people
    .Count(p => p.HobbiesCount >= 3);

Console.WriteLine("Number of people with 3+ hobbies:");
Console.WriteLine(numOfPeopleWithThreeOrMoreHobbies);

// 5. Create short descriptions
// Format like: Mia (24) – Berlin – ☕ yes

var descriptions = people
    .Select(p =>
    $"{p.Name} ({p.Age}) - {p.City} - ☕ {p.LikesCoffee}");

Console.WriteLine("Short descriptions of each person:");

foreach (var desc in descriptions)
{
    Console.WriteLine(desc);
}

// 6. People sorted by name length (longest first)
// Show name and length.

var byNameLength = people
    .OrderByDescending(p => p.Name.Length)
    .Select(p => p.Name);

Console.WriteLine("Sorted by name length:");

foreach (var person in byNameLength)
{
    Console.WriteLine(person);
}

// 7. Bonus – combined filter
// People who are 20–30 years old AND like coffee, sorted by age.

var combinedFilter = people
    .Where(p => p.Age >= 20 && p.Age <= 30 && p.LikesCoffee)
    .OrderBy(p => p.Age);

Console.WriteLine("People between 20 and 30 who like coffee soted by age:");
foreach (var p in combinedFilter)
{
    Console.WriteLine($"{p.Name} - {p.Age}");
}

// 8. Free play ideas (pick any)
// • Count people from Europe (Berlin, Lisbon, Barcelona)
// • Find if anyone has more than 4 hobbies
// • Show names in uppercase
// • List cities (without duplicates) – hint: .Select(p => p.City).Distinct()

var moreThanFourHobbies = people
    .Where(p => p.HobbiesCount > 4);

Console.WriteLine("People with more than 4 hobbies: ");
foreach (var p in moreThanFourHobbies)
{
    Console.WriteLine($"{p.Name} has {p.HobbiesCount} hobbies.");
}

Console.WriteLine("\nDone. Press ENTER to close...");
Console.ReadLine();

record Person(string Name, int Age, string City, bool LikesCoffee, int HobbiesCount);