var people = new List<Person>
{
    new("Mia",     24, "Berlin",     true,  new List<string>{ "skiing", "gaming", "coffee" }),
    new("Lucas",   31, "Lisbon",     false, new List<string>{ "surfing", "guitar" }),
    new("Aisha",   19, "Toronto",    true,  new List<string>{ "photography", "hiking", "gaming" }),
    new("Noah",    42, "Austin",     true,  new List<string>{ "bbq", "motorcycles", "coffee", "gaming" }),
    new("Sofia",   28, "Barcelona",  false, new List<string>{ "dancing", "yoga" }),
    new("Autumn",  0, "Berlin",     false,  new List<string>{ "skiing", "gaming" }),
    new("Kai",     22, "Seoul",      true,  new List<string>{ "gaming", "street food", "photography" })
};

Console.WriteLine("Data ready. Start playing with LINQ!\n");

// 1. All people who like coffee
var coffeeLovers = people.Where(p => p.LikesCoffee);
Console.WriteLine("People who like coffee:");
foreach (var person in coffeeLovers)
{
    Console.WriteLine($"{person.Name}");
}
Console.WriteLine();

//2. Names of people whose city starts with "B"
var peopleWhoseCityStartsWithB = people.Where(p => p.City[0] == 'B');
Console.WriteLine("People's whose city starts with the letter B:");
foreach (var person in peopleWhoseCityStartsWithB)
{
    Console.WriteLine($"{person.Name} from {person.City}");
}
Console.WriteLine();

// 3. Everyone under 25, sorted youngest → oldest
var peopleUnder25 = people
    .Where(p => p.Age < 25)
    .OrderBy(p => p.Age);
Console.WriteLine("People under 25 years old (sorted youngest to oldest):");
foreach (var person in peopleUnder25)
{
    Console.WriteLine($"{person.Name} is {person.Age} years old.");
}

// 4. All hobbies from everyone (one big flat list) (hint: SelectMany)
var everyonesHobbies = people.SelectMany(p => p.Hobbies);
Console.WriteLine("All hobbies from everyone:");
foreach (var hobby in everyonesHobbies)
{
    Console.WriteLine($"- {hobby}");
}

// 5. People who like both coffee and gaming
//var coffeeAndGaming = people.Where(p => p.likesCoffee && p.Select)

// 6. The person with the most hobbies (name + count)
var max = people.Max(p => p.Hobbies.Count);
Console.WriteLine($"max = {max}");

var result = people.Where(x => x.Hobbies.Count == max);

foreach (var person in result)
{
    Console.WriteLine(person.Name);
}

// 7. Group by LikesCoffee → show count in each group
var coffeeGroups = people.GroupBy(p => p.LikesCoffee);

Console.WriteLine("Group counts by Coffee Perference:");
foreach (var group in coffeeGroups)
{
    string status = group.Key ? "Likes Coffee" : "Doesn't Like Coffee";
    Console.WriteLine($"{status}: {group.Count()}");
}

// 8. Cities that have ≥ 2 people
var bigCities = people
    .GroupBy(p => p.City)
    .Where(g => g.Count() >= 2);

Console.WriteLine("Cities with 2 or more people:");
foreach (var group in bigCities)
{
    Console.WriteLine($"- {group.Key} ({group.Count()} people)");
}

// 9. (bonus evil) People sorted by number of

//Can be useful to rewrite these as for loops