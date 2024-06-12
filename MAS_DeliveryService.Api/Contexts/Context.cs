using MAS_DeliveryService.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace MAS_DeliveryService.Api.Contexts;

public class Context : DbContext
{
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

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source=DeliveryService.db");
}