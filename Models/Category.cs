using System.ComponentModel.DataAnnotations;

namespace tp11.Models;

public class Category
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
}