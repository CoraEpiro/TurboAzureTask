using Microsoft.EntityFrameworkCore;
using TurboAzureTask.Models;

namespace TurboAzureTask.Context;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
    {
    }

    public DbSet<Car> Car { get; set; }
}