using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

var context = new BookContext();

// TODO: Complete the 4 activities below


// Activity 1: Add books synchronously
//Write a method called AddBooksSync() that adds three books to the database using synchronous EF Core methods.
void AddBooksSync()
{
    var books = new List<Book>
    {
        new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937 },
        new Book { Title = "Dune", Author = "Frank Herbert", Year = 1965 },
        new Book { Title = "1984", Author = "George Orwell", Year = 1949 }
    };

    context.Books.AddRange(books);
    context.SaveChanges();

    System.Console.WriteLine("3 Books have been added the Sync way.");
}

AddBooksSync();

// Activity 2: Load books synchronously
//Write a method called LoadBooksSync() that retrieves all books and prints them.
void LoadBooksSync()
{
    var allBooks = context.Books.ToList();
    System.Console.WriteLine("All books in the db:");

    foreach (var b in allBooks)
    {
        System.Console.WriteLine($"- {b.Title}");
    }
}

LoadBooksSync();

// Activity 3: Save movies asynchronously
// Write a method called SaveMoviesAsync() that saves the movies using await and async file operations.
async Task SaveMoviesAsync()
{
    var books = new List<Book>
        {
            new Book { Title = "The Hobbit 2", Author = "J.R.R. Tolkien", Year = 1937 },
            new Book { Title = "Dune 2", Author = "Frank Herbert", Year = 1965 },
            new Book { Title = "1984 v2", Author = "George Orwell", Year = 1949 }
        };

    await context.Books.AddRangeAsync(books);
    await context.SaveChangesAsync();
    System.Console.WriteLine("3 Books have been added the Sync way.");

    var allBooks = context.Books.ToList();
    System.Console.WriteLine("All books in the db:");

    foreach (var b in allBooks)
    {
        System.Console.WriteLine($"- {b.Title}");
    }
}

SaveMoviesAsync();

// Activity 4: Load books asynchronously
// Write a method called LoadBooksAsync() that retrieves and displays books using await.
async Task LoadBooksAsync()
{
    var allBooks = await context.Books.ToListAsync();

    System.Console.WriteLine("Books loaded with async:");
    foreach (var b in allBooks)
    {
        System.Console.WriteLine($"- {b.Title}");
    }
}

LoadBooksAsync();

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public int Year { get; set; }
}

public class BookContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("BooksDb");
    }
}