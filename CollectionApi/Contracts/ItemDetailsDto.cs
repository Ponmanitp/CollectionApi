using CollectionApi.Models;

namespace CollectionApi.Contracts;

public class ItemDetailsDto
{
    public required string ItemName { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required Category Category { get; set; }
    public required float Price { get; set; }
    public required int Quantity { get; set; }
    public DateTime? PostedDate { get; set; }
}
