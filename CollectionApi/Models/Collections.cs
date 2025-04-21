using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionApi.Models;
public class Collections
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ItemId { get; set; }
    public required string ItemName { get; set; }
    public required string Description { get; set; }
    public required string ImagePath { get; set; }
    public required Category Category { get; set; }
    public required float Price { get; set; }
    public int Quantity { get; set; }
    public DateTime? PostedDate { get; set; }
    public bool IsVisible { get; set; }
}

