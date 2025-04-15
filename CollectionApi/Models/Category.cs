using System.ComponentModel.DataAnnotations;

namespace CollectionApi.Models;
public class Category
{
    [Key]
    public Guid CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public required string CatergoryUrl { get; set; }
}
