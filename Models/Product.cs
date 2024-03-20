using System.ComponentModel.DataAnnotations;

namespace tp11.Models;

public class Product
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Desc { get; set; }
    [Required]
    public int Qte { get; set; }
    
    public Category Category { get; set; }
    
    public Guid CategoryId { get; set; }
}