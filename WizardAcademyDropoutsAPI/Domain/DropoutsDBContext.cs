namespace WizardAcademyDropouts.Domain;

using Entities;
using Extensions;
using Microsoft.EntityFrameworkCore;

public class DropoutsDBContext : DbContext
{
    // private readonly string _connectionString;

    public DbSet<Character> Characters { get; set; }
    public DbSet<Failure> Failures { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Knack> Knacks { get; set; }

    // public DropoutsDBContext(IConfiguration configuration)
    // {
    //     _connectionString = configuration.GetConnectionString("DefaultConnection")
    //     ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");;
    // }

    public DropoutsDBContext(DbContextOptions<DropoutsDBContext> options) : base(options) { }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer(_connectionString).EnableDetailedErrors();
    // }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.BuildSelectEntity<Failure>("Failures");
        modelBuilder.BuildSelectEntity<Knack>("Knacks");
    }
}