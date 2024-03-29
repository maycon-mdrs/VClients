using Microsoft.EntityFrameworkCore;
using VClients.Api.Models;

namespace VClients.Api.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<AdressModel> Adresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /* CLIENT */
        modelBuilder.Entity<ClientModel>()
            .HasKey(c => c.Id);
        modelBuilder.Entity<ClientModel>()
            .HasOne(c => c.Adress)
            .WithOne()
            .HasForeignKey<AdressModel>(a => a.Id);

        modelBuilder.Entity<ClientModel>()
            .Property(c => c.FullName)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<ClientModel>()
            .Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<ClientModel>()
            .Property(c => c.Phone)
            .HasMaxLength(20)
            .IsRequired();

        modelBuilder.Entity<ClientModel>()
            .Property(c => c.CreatedAt)
            .IsRequired();

        /* ADRESS */
        modelBuilder.Entity<AdressModel>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<AdressModel>()
            .Property(a => a.Address)
            .HasMaxLength(255)
            .IsRequired();

        modelBuilder.Entity<AdressModel>()
            .Property(a => a.City)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<AdressModel>()
            .Property(a => a.State)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<AdressModel>()
            .Property(a => a.Zip)
            .HasMaxLength(20)
            .IsRequired();

        modelBuilder.Entity<AdressModel>()
            .Property(a => a.Country)
            .HasMaxLength(50)
            .IsRequired();

        /* POPULATING DATABASE */
        modelBuilder.Entity<ClientModel>().HasData(
            new ClientModel
            {
                Id = 1,
                FullName = "John Doe",
                Phone = "1234567890",
                Email = "user@gmail.com",
                CreatedAt = DateTime.Now,
                Adress = new AdressModel
                {
                    Id = 1,
                    Address = "1234 Main St",
                    City = "New York",
                    State = "NY",
                    Zip = "10001",
                    Country = "USA"
                }
            },
            new ClientModel
            {
                Id = 2,
                FullName = "Jane Doe",
                Phone = "0987654321",
                Email = "Jane@gmail.com",
                CreatedAt = DateTime.Now,
                Adress = new AdressModel
                {
                    Id = 2,
                    Address = "5678 Main St",
                    City = "Los Angeles",
                    State = "CA",
                    Zip = "90001",
                    Country = "USA"
                }
            }
        );
    }
}