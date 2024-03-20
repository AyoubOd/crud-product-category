using System.ComponentModel.DataAnnotations;

namespace tp11.Models;

public class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required] public string Name { get; set; }
}