using System.ComponentModel.DataAnnotations;
using MAS_DeliveryService.Api.Domain;
using MAS_DeliveryService.Api.Domain.Clients;
using MAS_DeliveryService.Api.Domain.Couriers;
using MAS_DeliveryService.Api.Domain.Deliveries;
using MAS_DeliveryService.Api.Domain.DriversLicenses;
using MAS_DeliveryService.Api.Domain.Enums;
using MAS_DeliveryService.Api.Domain.Items;
using MAS_DeliveryService.Api.Domain.Managers;
using MAS_DeliveryService.Api.Domain.OrderItems;
using MAS_DeliveryService.Api.Domain.Orders;
using MAS_DeliveryService.Api.Domain.PackageItems;
using MAS_DeliveryService.Api.Domain.Packages;
using MAS_DeliveryService.Api.Domain.People;
using MAS_DeliveryService.Api.Domain.Static;
using MAS_DeliveryService.Api.Domain.Workers;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Contexts;

public class Context : DbContext
{
    protected Context()
    {
    }

    public Context(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<DriversLicense> DriversLicenses { get; set; }
    public DbSet<Courier> Couriers { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<PackageItem> PackageItems { get; set; }
    public DbSet<Static> Static { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source=DeliveryService.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var people = new List<Person>
        {
            new Person("Jan", "Kowalski", "555666555"),
            new Person("Nathan", "Drake", "444555666"),
            new Person("John", "Marston", "555444555"),
            new Person("Sam", "Fisher", "111222333"),
        };
        var clients = new List<Client>
        {
            new Client("marston@gmail.com", people[2].Id),
            new Client("fisher@gmail.com", people[3].Id)
        };
        var couriers = new List<Courier>()
        {
            new Courier(people[0].Id, DateTime.Now, 30.0m, ContractType.Contractor),
            new Courier(people[3].Id, DateTime.Now, 5000.0m, ContractType.Employee)
        };
        var items = new List<Item>
        {
            new Item("Asbestos", 10.0m),
            new Item("Bricks", 34.7m),
            new Item("Pen", 0.1m),
            new Item("Water bottle", 1.0m)
        };
        var orders = new List<Order>
        {
            new Order("Building Company", "Example 87, Warsaw, Poland", clients.First().Id),
            new Order("Amazon.com", "Example 32, Warsaw, Poland", clients[1].Id)
        };
        var orderItems = new List<OrderItem>
        {
            new OrderItem(orders.First().Id, items.First().Id),
            new OrderItem(orders.First().Id, items[1].Id),
            new OrderItem(orders.First().Id, items[3].Id),
            new OrderItem(orders[1].Id, items[3].Id),
            new OrderItem(orders[1].Id, items[2].Id),
        };
        
        modelBuilder.Entity<Static>().HasData(new Static(35.0m, 21));
        modelBuilder.Entity<Person>().HasData(people);
        modelBuilder.Entity<Manager>().HasData(new Manager(people[1].Id, DateTime.Now, 3500.0m, ContractType.Employee, "Harvard"));
        modelBuilder.Entity<Courier>().HasData(couriers);
        modelBuilder.Entity<Client>().HasData(clients);
        modelBuilder.Entity<Item>().HasData(items);
        modelBuilder.Entity<Order>().HasData(orders);
        modelBuilder.Entity<OrderItem>().HasData(orderItems);
        modelBuilder.Entity<DriversLicense>().HasData(new DriversLicense(DateTime.Now, new HashSet<LicenseCategory> { LicenseCategory.B }, couriers.First().Id));
        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        AutoValidate();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        AutoValidate();
        return base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Metoda dodająca automatyczną walidację na podstawie
    /// walidatorów (funkcjonalność ta jest domyślnie wyłączona w Entityframework). 
    /// Wywoływana przy próbie zapisu danych do bazy danych.
    /// </summary>
    private void AutoValidate()
    {
        ChangeTracker.Entries().Where(e => e.State is EntityState.Added or EntityState.Modified).Select(e => e.Entity)
            .ToList().ForEach(entity => Validator.ValidateObject(entity, new ValidationContext(entity), validateAllProperties: true));
    }
}