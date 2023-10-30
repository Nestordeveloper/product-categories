#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "El nombre de la categoría es requerido.")]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Association> Products { get; set; } = new List<Association>();

}