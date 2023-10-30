#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Association
{
    [Key]
    public int AssociationId { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public Product? Product { get; set; }
    public Category? Category { get; set; }
}