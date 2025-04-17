using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollectionApi.Models;
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public required string CategoryUrl { get; set; }
}
