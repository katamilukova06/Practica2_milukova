using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAccessories.Models;

public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    [Required]
    [MaxLength (150)]
    public string Name { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }
    public OrderComposition OrderComposition { get; set; }
}