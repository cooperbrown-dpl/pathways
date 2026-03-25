using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieDbDemo
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Director { get; set; } = string.Empty;
        public double Rating { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new();
    }

    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MovieDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using var context = new MovieContext();
            SeedData(context);

            // TODO: Write your code here for the 5 activities
            Console.WriteLine("Movie Database loaded successfully!");


            // 1. List All Movies with Genre
            // Task: Display all movies showing Title, Year, Director, Rating, and Genre.
            var allMovies = context.Movies.Include(m => m.Genre).ToList();
            Console.WriteLine("All Movies:");
            foreach (var movie in allMovies)
            {
                Console.WriteLine($"{movie.Title} ({movie.ReleaseYear}) - Directed by {movie.Director}, Rating: {movie.Rating}, Genre: {movie.Genre?.Name}");
            }

            // 2. Find Movie by Title
            // ask: Search and display details of the movie "Inception".
            var inception = context.Movies
                .Include(m => m.Genre)
                .FirstOrDefault(m => m.Title == "Inception");

            if (inception != null)
            {
                Console.WriteLine($"\nDetails of 'Inception':");
                Console.WriteLine($"{inception.Title} ({inception.ReleaseYear}) - Directed by {inception.Director}, Rating: {inception.Rating}, Genre: {inception.Genre?.Name}");
            }
            else
            {
                Console.WriteLine("\n'Inception' not found in the database.");
            }

            // 3. Add a New Movie
            // Task: Add a new movie called "Oppenheimer" (2023, Christopher Nolan, Rating 8.4, Genre: Drama).
            var dramaGenre = context.Genres.FirstOrDefault(g => g.Name == "Drama");

            var newMovie = new Movie
            {
                Title = "Oppenheimer",
                ReleaseYear = 2023,
                Director = "Christopher Nolan",
                Rating = 8.4,
                GenreId = dramaGenre.Id
            };

            context.Movies.Add(newMovie);
            context.SaveChanges();
            Console.WriteLine("\nAdded 'Oppenheimer' to the database.");

            // 4. Update Movie Rating
            // Task: Change the rating of "The Dark Knight" to 9.2.
            var darkKnight = context.Movies.FirstOrDefault(m => m.Title == "The Dark Knight");
            if (darkKnight != null)
            {
                darkKnight.Rating = 9.2;
                context.SaveChanges();
                Console.WriteLine("Rating of The Dark Knight updated to 9.2");
            }

            // 5. Remove a Movie
            // Task: Remove the movie "Parasite" from the database.
            var parasite = context.Movies
                .FirstOrDefault(m => m.Title == "Parasite");
            if (parasite != null)
            {
                context.Movies.Remove(parasite);
                context.SaveChanges();

                Console.WriteLine("Movie 'Parasite' has been removed.");
            }

        }

        static void SeedData(MovieContext context)
        {
            if (context.Movies.Any()) return;

            var action = new Genre { Name = "Action" };
            var comedy = new Genre { Name = "Comedy" };
            var drama = new Genre { Name = "Drama" };
            var scifi = new Genre { Name = "Sci-Fi" };
            var thriller = new Genre { Name = "Thriller" };

            context.Genres.AddRange(action, comedy, drama, scifi, thriller);
            context.SaveChanges();

            var movies = new List<Movie>
            {
                new Movie { Title = "Inception", ReleaseYear = 2010, Director = "Christopher Nolan", Rating = 8.8, GenreId = scifi.Id },
                new Movie { Title = "The Dark Knight", ReleaseYear = 2008, Director = "Christopher Nolan", Rating = 9.0, GenreId = action.Id },
                new Movie { Title = "Interstellar", ReleaseYear = 2014, Director = "Christopher Nolan", Rating = 8.7, GenreId = scifi.Id },
                new Movie { Title = "Parasite", ReleaseYear = 2019, Director = "Bong Joon-ho", Rating = 8.5, GenreId = drama.Id },
                new Movie { Title = "Dune: Part Two", ReleaseYear = 2024, Director = "Denis Villeneuve", Rating = 8.6, GenreId = scifi.Id }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();
            Console.WriteLine("Database seeded with 5 movies.");
        }
    }
}