using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAccessories.Models;

public class OrderComposition
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    [Required]
    [MaxLength (150)]
    public int Quantity { get; set; }
    public List<OrderComposition> OrderCompositions { get; set; }
}