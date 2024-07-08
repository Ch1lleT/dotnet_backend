
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Db;

public class DatabaseContext : DbContext{

    protected readonly string connectionString = "Server=localhost; User ID=root; Password=root; Database=newdotnet";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey("ProductId");
    }

    internal void Find(int id)
    {
        throw new NotImplementedException();
    }

    public DbSet<User> Users {get;set;}
    public DbSet<Product> Products {get;set;}
    
} 