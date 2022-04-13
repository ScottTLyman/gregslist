using System.ComponentModel.DataAnnotations;

namespace gregslist.Models
{
  public class House
  {
    public int Id { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int? Bedrooms { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? Bathrooms { get; set; }
    [MinLength(3)]
    public string Description { get; set; }

    [Range(0, int.MaxValue)]
    public int? Year { get; set; }

    [Required]
    [Range(.01, int.MaxValue)]
    public int? Price { get; set; }
  }
}