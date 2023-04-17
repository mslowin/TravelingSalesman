using Microsoft.EntityFrameworkCore;

namespace TravelingSalesman.Data.Coordinate;

public class CoordinateContext : DbContext
{
    public DbSet<Coordinate>? Coordinates { get; set; }

    private readonly IConfiguration _configuration;
    public CoordinateContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("CoordinatesDB"));
    }
}