using System.ComponentModel.DataAnnotations;
using MAS_DeliveryService.Api.Domain;
using MAS_DeliveryService.Api.Domain.Clients;
using MAS_DeliveryService.Api.Domain.Couriers;
using MAS_DeliveryService.Api.Domain.Deliveries;
using MAS_DeliveryService.Api.Domain.DriversLicenses;
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
        modelBuilder.Entity<Static>().HasData(new Static(35.0m, 21));
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