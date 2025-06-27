using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAccessories.Models;

public class Seller
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SellerId { get; set; }
    [Required]
    [MaxLength (150)]
    public string Name { get; set; }
    public string Position { get; set; }
    public Order Order { get; set; }
}