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

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source=DeliveryService.db");
}