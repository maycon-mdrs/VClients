using Microsoft.EntityFrameworkCore;
using VClients.Api.Models;

namespace VClients.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<FullAddress> Address { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /* RELATION */
        modelBuilder.Entity<Customer>()
            .HasOne(c => c.FullAddress)
            .WithOne(a => a.Customer)
            .HasForeignKey<FullAddress>(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        /* CLIENT */
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Customer>()
            .Property(c => c.FullName)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Customer>()
            .Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Customer>()
            .Property(c => c.Phone)
            .HasMaxLength(20)
            .IsRequired();

        modelBuilder.Entity<Customer>()
            .Property(c => c.CreatedAt)
            .IsRequired();

        modelBuilder.Entity<Customer>()
            .Property(c => c.UpdatedAt)
            .IsRequired(false);
        
        /* ADDRESS */
        modelBuilder.Entity<FullAddress>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<FullAddress>()
            .Property(a => a.Address)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<FullAddress>()
            .Property(a => a.City)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<FullAddress>()
            .Property(a => a.State)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<FullAddress>()
            .Property(a => a.Zip)
            .HasMaxLength(20)
            .IsRequired();

        modelBuilder.Entity<FullAddress>()
            .Property(a => a.Country)
            .HasMaxLength(50)
            .IsRequired();

        /* POPULATING DATABASE */
        var address = new FullAddress
        {
            Id = 1,
            Address = "1234 Main St",
            City = "New York",
            State = "NY",
            Zip = "10001",
            Country = "USA", 
            CustomerId = 1,
        };

        var customer = new Customer
        {
            Id = 1,
            FullName = "John Doe",
            Phone = "1234567890",
            Email = "user@gmail.com",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        modelBuilder.Entity<FullAddress>().HasData(address);
        modelBuilder.Entity<Customer>().HasData(customer);
    }
}