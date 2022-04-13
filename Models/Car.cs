using System.ComponentModel.DataAnnotations;

namespace gregslist.Models
{
  public class Car
  {
    public int Id { get; set; }

    [Required]
    [MinLength(4)]
    public string Make { get; set; }

    [Required]
    [MinLength(4)]
    public string Model { get; set; }

    [MinLength(4)]
    public string Description { get; set; }

    [Range(0, int.MaxValue)]
    public int? Year { get; set; }

    [Range(.01, int.MaxValue)]
    public int? Price { get; set; }
  }
}