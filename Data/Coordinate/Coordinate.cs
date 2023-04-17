using System.ComponentModel.DataAnnotations;

namespace TravelingSalesman.Data.Coordinate;

public class Coordinate
{
    [Key]
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public string? Name { get; set; }
}