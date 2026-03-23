//using arrays
//Validate rating between 1 and 10
//Use at least 1 method

// After entering all movies, display:
// A clean list of all movies with their title, rating, and genre
// The highest rated movie (title + rating)
// The average rating of all movies (rounded to 1 decimal place)
// How many movies were entered per genre (simple count)

var userChoice = true;
var numOfMovies = 0;

while (userChoice)
{

    var validInput = false;
    while (!validInput)
    {
        Console.WriteLine("How many movies do you want to add? (Between 1 and 6)");
        var input = Console.ReadLine();

        if (int.TryParse(input, out numOfMovies) && numOfMovies >= 1 && numOfMovies <= 6)
        {
            validInput = true;
        }
        else
        {
            Console.WriteLine("Number invalid, please enter a number between 1 and 6.");
        }
    }
    var movieTitles = new string[numOfMovies];
    var movieRatings = new double[numOfMovies];
    var movieGenres = new string[numOfMovies];

    for (int i = 0; i < numOfMovies; i++)
    {
        Console.WriteLine($"Enter the title of movie #{i + 1}:");
        movieTitles[i] = Console.ReadLine();

        var validRating = false;
        while (!validRating)
        {
            Console.WriteLine($"Enter the rating of movie #{i + 1} (between 1 and 10):");
            var ratingInput = Console.ReadLine();

            if (double.TryParse(ratingInput, out double rating) && rating >= 1 && rating <= 10)
            {
                movieRatings[i] = rating;
                validRating = true;
            }
            else
            {
                Console.WriteLine("Rating invalid, please enter a number between 1 and 10.");
            }
        }

        Console.WriteLine($"Enter the genre of movie #{i + 1}:");
        movieGenres[i] = Console.ReadLine();
    }

    var highestRatedMovieIndex = Array.IndexOf(movieRatings, movieRatings.Max());
    var averageRating = Math.Round(movieRatings.Average(), 1);
    var genreCounts = movieGenres.GroupBy(g => g)
                                 .ToDictionary(g => g.Key, g => g.Count());

    Console.WriteLine("\nMovies entered:");
    for (int i = 0; i < numOfMovies; i++)
    {
        Console.WriteLine($"Title: {movieTitles[i]}, Rating: {movieRatings[i]}, Genre: {movieGenres[i]}");
    }

    Console.WriteLine($"\nHighest Rated Movie: {movieTitles[highestRatedMovieIndex]} with a rating of {movieRatings[highestRatedMovieIndex]}");
    Console.WriteLine($"Average Rating: {averageRating}");

    Console.WriteLine("\nGenre Counts:");
    foreach (var kvp in genreCounts)
    {
        Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }

    Console.WriteLine("Do you want to run the program again?");
    var userChoiceString = Console.ReadLine().ToLower();
    if (userChoiceString == "no" || userChoiceString == "n")
    {
        userChoice = false;
    }
}

Console.WriteLine("Exiting program, goodbye!");