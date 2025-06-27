using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAccessories.Models;

public class Client
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClientId { get; set; }
    [Required]
    [MaxLength (150)]
    public string Name { get; set; }
    public Order Order { get; set; }
}