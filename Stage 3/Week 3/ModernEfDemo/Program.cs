using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Modern C# Features Practice Started\n");

// 10. Combine everything in Main flow
// In your top-level statements, call all the above methods in order using await.
//System.Console.WriteLine("----- Activity 10 -----");

await using var db = new AppDbContext();

System.Console.WriteLine("----- Activity 1 -----");
await SeedData(db);
System.Console.WriteLine("----- Activity 2 -----");
await GetAllProducts(db);
System.Console.WriteLine("----- Activity 3 -----");
AllProductsOver100(db);
System.Console.WriteLine("----- Activity 4 -----");
productsWithCategoryNames(db);
System.Console.WriteLine("----- Activity 5 -----");
AddNewProduct(db);
System.Console.WriteLine("----- Activity 6 -----");
increasePhonePrice(db);
System.Console.WriteLine("----- Activity 7-----");
DeleteProduct(db);
System.Console.WriteLine("----- Activity 8 -----");
CountProductsPerCategory(db);
System.Console.WriteLine("----- Activity 9 -----");
MostExpensive(db);

// TODO: Complete the 10 activities below

// 1. Seed some initial data (Async)
// Create an async method called SeedData that adds 2 categories and 4 products. Save changes asynchronously.
async Task SeedData(AppDbContext db)
{
    if (await db.Categories.AnyAsync()) return;

    var electronics = new Category { Name = "Electronics" };
    var books = new Category { Name = "Books" };

    db.Categories.AddRange(electronics, books);
    await db.SaveChangesAsync();

    db.Products.AddRange(
        new Product { Name = "Laptop", Price = 599.99m, CategoryId = electronics.Id },
        new Product { Name = "Phone", Price = 699.99m, CategoryId = electronics.Id },
        new Product { Name = "Harry Potter", Price = 19.99m, CategoryId = books.Id },
        new Product { Name = "The Hobbit", Price = 14.99m, CategoryId = books.Id }
    );

    await db.SaveChangesAsync();
    System.Console.WriteLine("Data seeded successfully.");
}

// 2. Get all products asynchronously
// Write an async method to retrieve and print all product names.

async Task GetAllProducts(AppDbContext db)
{
    var allProducts = await db.Products.ToListAsync();
    System.Console.WriteLine("All products in database:");
    foreach (var p in allProducts)
    {
        System.Console.WriteLine($"- {p.Name}");
    }
}

// 3. Filter products by price using LINQ
// Find and print all products that cost more than 100 using LINQ and async.
async Task AllProductsOver100(AppDbContext db)
{
    var over100 = db.Products.Where(p => p.Price > 100);
    System.Console.WriteLine("Items in db that cost over 100:");
    foreach (var p in over100)
    {
        System.Console.WriteLine($"{p.Name} cost: {p.Price}");
    }
}

// 4. Include related data (Category)
// Retrieve all products with their category names using Include and async.
async Task productsWithCategoryNames(AppDbContext db)
{
    var productsWithCatNames = await db.Products
        .Include(p => p.Category)
        .ToListAsync();
    System.Console.WriteLine("Products and their category names:");
    foreach (var p in productsWithCatNames)
    {
        System.Console.WriteLine($"{p.Name} in {p.Category.Name} category");
    }
}

// 5. Add a new product asynchronously
// Add a new product called "Tablet" priced at 399.99 in the Electronics category.

async Task AddNewProduct(AppDbContext db)
{
    var electronics = await db.Categories.FirstAsync(c => c.Name == "Electronics");
    var tablet = new Product { Name = "Tablet", Price = 399.99m, CategoryId = electronics.Id };
    db.Products.Add(tablet);
    await db.SaveChangesAsync();
    var allProducts = await db.Products.ToListAsync();
    foreach (var p in allProducts)
    {
        System.Console.WriteLine($"{p.Name} in {p.Category.Name} category");
    }
}

// 6. Update a product price
// Find the product "Phone" and increase its price by 50 using async.

async Task increasePhonePrice(AppDbContext db)
{
    var phone = await db.Products.FirstOrDefaultAsync(p => p.Name == "Phone");
    System.Console.WriteLine($"Phone price before: {phone.Price}");
    phone.Price += 50.00m;
    await db.SaveChangesAsync();
    System.Console.WriteLine($"Phone price after: {phone.Price}");
}

// 7. Delete a product
// Delete the product named "Clean Code" using async.

async Task DeleteProduct(AppDbContext db)
{
    var cleanCodeBook = await db.Products.FirstOrDefaultAsync(p => p.Name == "Harry Potter");
    db.Products.Remove(cleanCodeBook);
    await db.SaveChangesAsync();

    var allProducts = await db.Products.ToListAsync();
    foreach (var p in allProducts)
    {
        System.Console.WriteLine($"{p.Name} in {p.Category.Name} category");
    }
}

// 8. Count products per category using LINQ
// Show how many products are in each category.

async Task CountProductsPerCategory(AppDbContext db)
{
    var counts = await db.Categories
        .Select(c => new
        {
            Category = c.Name,
            Count = c.Products.Count()
        })
        .ToListAsync();

    foreach (var item in counts)
    {
        System.Console.WriteLine($"{item.Category} category count is {item.Count}.");
    }
}

// 9. Find the most expensive product
// Use LINQ to find and display the most expensive product.
async Task MostExpensive(AppDbContext db)
{
    var mostExpensive = await db.Products
        .OrderByDescending(p => p.Price)
        .FirstOrDefaultAsync();

    System.Console.WriteLine($"Most expensive item is {mostExpensive.Name}, it costs: {mostExpensive.Price}");
}

class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}

class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new();
}

class AppDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("ModernDemoDb");
    }
}