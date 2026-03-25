using Microsoft.EntityFrameworkCore;
using System;

var context = new ShopContext();
SeedData(context);

Console.WriteLine("eCommerce Database is ready!\n");

// TODO: Write your 5 easy activities here

// Activity 1: List all products
// Show the name, price, and stock of every product in the database.
System.Console.WriteLine("----- Activity 1 -----");
var allProducts = context.Products.ToList();

foreach (var p in allProducts)
{
    Console.WriteLine($"Name: {p.Name} Price: {p.Price} Category: {p.Category} Stock: {p.Stock}");
}


// Activity 2: Show only Electronics products X
// Display the name and price of all products in the "Electronics" category.
System.Console.WriteLine("----- Activity 2 -----");
var electronics = context.Products.Where(p => p.Category == "Electronics").ToList();

Console.WriteLine("All products in electronics category: ");
foreach (var p in electronics)
{
    Console.WriteLine($"Name: {p.Name}, Price: {p.Price}");
}

// Activity 3: Add a new product X
// Add a new product called "Blue Pen" with price 2.99, category "Stationery", and stock 150.
System.Console.WriteLine("----- Activity 3 -----");
var newProduct = new Product
{
    Name = "Dog food",
    Price = 50.0m,
    Category = "Pets",
    Stock = 20
};

context.Products.Add(newProduct);
context.SaveChanges();
System.Console.WriteLine("Dog food has been added to Products.");


// Activity 4: Update stock of a product
// Find the "Coffee Mug" and change its stock to 200.
System.Console.WriteLine("----- Activity 4 -----");
var coffeeMug = context.Products.FirstOrDefault(p => p.Name == "Coffee Mug");
coffeeMug.Stock = 200;
context.SaveChanges();
System.Console.WriteLine($"Coffee stock updated to {coffeeMug.Stock}.");

// Activity 5: Show products that cost less than $20
// List the name and price of all products that cost less than 20 dollars.
System.Console.WriteLine("----- Activity 5 -----");
var productsUnder20 = context.Products.Where(p => p.Price < 20).ToList();

System.Console.WriteLine("Products that cost less than $20:");
foreach (var p in productsUnder20)
{
    Console.WriteLine($"{p.Name}: ${p.Price}");
}



// ====================== SEED DATA ======================
void SeedData(ShopContext ctx)
{
    if (ctx.Products.Any()) return;

    var products = new List<Product>
    {
        new Product { Name = "Wireless Headphones", Price = 79.99m, Category = "Electronics", Stock = 25 },
        new Product { Name = "Coffee Mug", Price = 12.99m, Category = "Home", Stock = 120 },
        new Product { Name = "Notebook", Price = 5.49m, Category = "Stationery", Stock = 80 },
        new Product { Name = "USB Cable", Price = 8.99m, Category = "Electronics", Stock = 60 },
        new Product { Name = "Water Bottle", Price = 15.99m, Category = "Sports", Stock = 45 }
    };

    ctx.Products.AddRange(products);
    ctx.SaveChanges();
    Console.WriteLine("5 products seeded successfully.\n");
}

// ====================== MODELS ======================
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
    public int Stock { get; set; }
}

public class ShopContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ShopDb");
    }
}