using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace dotn.Models;

public class TransportPartenairsModel
{
    [Key]
    public int IdTransport { get; set; }
    [Required]
    [MaxLength(35)]
    public string Name_Transport { get; set; }
    [Required]
    [MaxLength(20)]
    public string Classe { get; set; }
    [Required]
    [MaxLength(25)]
    public string Category { get; set; }
    [Required]
    [DataType(DataType.ImageUrl)]
    public string Picture_Transport { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public ICollection<OffreModel> Offres { get; set; }
}