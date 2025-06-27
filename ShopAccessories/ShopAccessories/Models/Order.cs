using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAccessories.Models;

public class Order
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }
    [Required]
    [MaxLength (150)]
    public int ClientId { get; set; }
    public int SellerId { get; set; }
    public int DatePurchase { get; set; }
    public OrderComposition OrderComposition { get; set; }
    public List<Client> Orders { get; set; }
}