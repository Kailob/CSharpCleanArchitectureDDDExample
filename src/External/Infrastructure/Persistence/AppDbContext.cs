using System.Reflection;
using Domain.DeviceAggregate;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

/// <summary>
/// Application db context
/// </summary>
public class AppDbContext
    : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Devices db set.
    /// </summary>
    /// <value></value>
    public DbSet<Device> Devices { get; set; } = null!;

    /// <summary>
    /// On Model Creation.
    /// </summary>
    /// <param name="modelBuilder">Entity Framework Model Builder</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new DeviceConfigurations());
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}