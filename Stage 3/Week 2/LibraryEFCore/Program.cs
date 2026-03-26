using Microsoft.EntityFrameworkCore;
using System;

var context = new LibraryContext();
SeedData(context);

Console.WriteLine("Library Database is ready!\n");

// TODO: Add your activities here below
// Activity 1: List all books
// Task: Display the title and author of every book.
System.Console.WriteLine("----- Activity 1 -----");
var titleAndAuthor = context.Books.ToList();
foreach (var b in titleAndAuthor)
{
    Console.WriteLine($"Book: {b.Title}, Written By: {b.Author}");
}

// Activity 2: Show books by Fantasy genre
// Task: List only the books that belong to the "Fantasy" genre.
System.Console.WriteLine("----- Activity 2 -----");
var fantasyGenre = context.Books.Where(b => b.Genre == "Fantasy").ToList();
System.Console.WriteLine("Books in the fantasy Genre:");
foreach (var b in fantasyGenre)
{
    System.Console.WriteLine($"- {b.Title}");
}

// Activity 3: Add a new book
// Task: Add a new book titled "1984" by George Orwell, published in 1949, genre "Fiction".
System.Console.WriteLine("----- Activity 3 -----");
var newBook = new Book
{
    Title = "1984",
    Author = "George Orwell",
    Year = 1949,
    Genre = "Fiction"
};

context.Books.Add(newBook);
context.SaveChanges();

titleAndAuthor = context.Books.ToList();
foreach (var b in titleAndAuthor)
{
    Console.WriteLine($"Book: {b.Title}, Written By: {b.Author}");
}

// Activity 4: Update book year
// Task: Change the publication year of "Dune" to 1966.
System.Console.WriteLine("----- Activity 4 -----");
var changeYear = context.Books.FirstOrDefault(b => b.Title == "Dune");
changeYear.Year = 1966;

titleAndAuthor = context.Books.ToList();
foreach (var b in titleAndAuthor)
{
    Console.WriteLine($"Book: {b.Title}, Written By: {b.Author}, Year published: {b.Year}");
}

// Activity 5: Show books published after 1950
// Task: List the title and year of all books published after 1950.
var after1950 = context.Books.Where(b => b.Year > 1950);
System.Console.WriteLine("All books published after 1950:");
foreach (var b in after1950)
{
    System.Console.WriteLine($"- {b.Title}, published: {b.Year}");
}

// ====================== SEED DATA ======================
void SeedData(LibraryContext ctx)
{
    if (ctx.Books.Any()) return;

    var books = new List<Book>
    {
        new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937, Genre = "Fantasy" },
        new Book { Title = "Dune", Author = "Frank Herbert", Year = 1965, Genre = "Sci-Fi" },
        new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813, Genre = "Romance" },
        new Book { Title = "The Alchemist", Author = "Paulo Coelho", Year = 1988, Genre = "Fiction" },
        new Book { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Year = 1997, Genre = "Fantasy" }
    };

    ctx.Books.AddRange(books);
    ctx.SaveChanges();
    Console.WriteLine("5 books seeded successfully.\n");
}

// ====================== MODELS ======================
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Genre { get; set; } = string.Empty;
}

public class LibraryContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("LibraryDb");
    }
}