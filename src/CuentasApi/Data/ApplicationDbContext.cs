namespace CuentasApi.Data;
using CuentasApi.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        /* FakeData.Init(10); */
    }

    public DbSet<User> Users => this.Set<User>();
    public DbSet<Account> Accounts => this.Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<User>()
            .HasMany(u => u.Accounts)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<User>().HasData(FakeData.Users);
        modelBuilder.Entity<Account>().HasData(FakeData.Accounts);
    }
}
