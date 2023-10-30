#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "El nombre del producto es requerido.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "La descripción es requerida.")]
    public string Description { get; set; }
    [Required(ErrorMessage = "El precio es requerido.")]
    public int Price { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> Categories { get; set; } = new List<Association>();
}