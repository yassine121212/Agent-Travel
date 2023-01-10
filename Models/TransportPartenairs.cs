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

    [MaxLength(25)]
    public string? Ville_depart { get; set; }
    [MaxLength(25)]
    public string? Ville_Arrivee { get; set; }
    public DateTime? heure_depart { get; set; }
    public DateTime? heure_Arrivee { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}