using Microsoft.EntityFrameworkCore;
using System;

var context = new CrmContext();
SeedData(context);

Console.WriteLine("EF CRM Database is ready!\n");

// TODO: Write your 10 activities here below

//Activity 1: List all customers with their order count
var allCustomersOrderCounts = context.Customers.Include(c => c.Orders).ToList();

foreach (var c in allCustomersOrderCounts)
{
    Console.WriteLine($"{c.FirstName} {c.LastName} has {c.Orders.Count()} orders");
}

//Activity 2: Show full details of Liam Chen
var liam = context.Customers.FirstOrDefault(c => c.FirstName == "Liam");

Console.WriteLine("Liam info:");
Console.WriteLine($"{liam.FirstName} {liam.LastName} {liam.Phone} email: {liam.Email} DOB: {liam.DateOfBirth} Orders: {liam.Orders.Count()}");

//Activity 3: Add a new customer
var newCustomer = new Customer
{
    FirstName = "Bob",
    LastName = "Bobberson",
    Email = "Bob@bob.com",
    Phone = "444-4444",
    DateOfBirth = new DateTime(1990, 8, 12)
};

context.Customers.Add(newCustomer);
context.SaveChanges();
Console.WriteLine($"{newCustomer.FirstName} has been added to the database.");

//Activity 4: Add an order for Emma Johnson
var emma = context.Customers
    .FirstOrDefault(c => c.FirstName == "Emma");

var order = new Order
{
    OrderDate = DateTime.Now,
    TotalAmount = 149.99m,
    Status = "Completed",
    CustomerId = emma.Id
};

context.Orders.Add(order);
context.SaveChanges();
Console.WriteLine($"New order added for Emma, Order ID {order.Id}, Customer ID: {order.CustomerId} added.");

//Activity 5: List all completed orders X
var allCompletedOrders = context.Orders.Where(o => o.Status == "Completed").ToList();

Console.WriteLine("Completed orders:");
foreach (var o in allCompletedOrders)
{
    Console.WriteLine($"- {o.Id}");
}

//Activity 6: Update Sophia’s phone number
var sophia = context.Customers.FirstOrDefault(c => c.Email == "sophia.r@email.com");
sophia.Phone = "888-8888";
context.SaveChanges();
Console.WriteLine($"Sophia's phone number has been updated to {sophia.Phone}.");

//Activity 7: Show total revenue from all orders
var totalRevenue = context.Orders.Sum(o => o.TotalAmount);
Console.WriteLine($"Total revenue: ${totalRevenue}");

//Activity 8: Find customers born after 1995
var bornAfter1995 = context.Customers.Where(c => c.DateOfBirth > new DateTime(1995, 12, 31));

foreach (var c in bornAfter1995)
{
    Console.WriteLine($"{c.FirstName} was born after 1995.");
}

//Activity 9: Remove Liam Chen X
var removeLiam = context.Customers.FirstOrDefault(c => c.Email == "liam.chen@email.com");
context.Customers.Remove(removeLiam);
context.SaveChanges();
Console.WriteLine("Liam Chen has been removed.");

//Activity 10: List all customers sorted by last name X
var customersByLastName = context.Customers.OrderBy(c => c.LastName).ToList();

foreach (var c in customersByLastName)
{
    Console.WriteLine($"- {c.LastName}, {c.FirstName}");
}


// ====================== HELPER METHOD ======================
void SeedData(CrmContext ctx)
{
    if (ctx.Customers.Any()) return;

    var customers = new List<Customer>
    {
        new Customer
        {
            FirstName = "Emma", LastName = "Johnson", Email = "emma.j@email.com",
            Phone = "555-1234", DateOfBirth = new DateTime(1995, 3, 15),
            Orders = new List<Order>
            {
                new Order { OrderDate = DateTime.Now.AddDays(-30), TotalAmount = 249.99m, Status = "Completed" },
                new Order { OrderDate = DateTime.Now.AddDays(-5),  TotalAmount = 89.50m,  Status = "Pending" }
            }
        },
        new Customer
        {
            FirstName = "Liam", LastName = "Chen", Email = "liam.chen@email.com",
            Phone = "555-5678", DateOfBirth = new DateTime(1988, 7, 22),
            Orders = new List<Order> { new Order { OrderDate = DateTime.Now.AddDays(-15), TotalAmount = 1249.00m, Status = "Completed" } }
        },
        new Customer
        {
            FirstName = "Sophia", LastName = "Rodriguez", Email = "sophia.r@email.com",
            Phone = "555-9012", DateOfBirth = new DateTime(2000, 11, 8)
        }
    };

    ctx.Customers.AddRange(customers);
    ctx.SaveChanges();
    Console.WriteLine("Seeded 3 customers with sample orders.\n");
}

// ====================== MODELS & CONTEXT ======================
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public List<Order> Orders { get; set; } = new();
}

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
}

public class CrmContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("CrmDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
    }
}