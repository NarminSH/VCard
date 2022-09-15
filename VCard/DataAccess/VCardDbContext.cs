using System;
using Microsoft.EntityFrameworkCore;


public class VCardDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("server=localhost,1433;uid=sa;database=VCard;pwd=your_password123;");
        }
    }
    public DbSet<Card> vCards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}


