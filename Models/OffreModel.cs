using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotn.Models;

public class OffreModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string Title_Offre { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public double Price_Offre { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string Description_Offre { get; set; }
    [Required]
    [DataType(DataType.ImageUrl)]
    public string Picture_Offre { get; set; }
    [DataType(DataType.Text)]
    public string? Review { get; set; }
    [MaxLength(25)]
    public string? City { get; set; }
    [MaxLength(25)]
    public string? Ville_Arrivee { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string Pays { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date_End { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date_Begin { get; set; }
    [ForeignKey("IdHotel")]
    public HotelPartenairsModel? id_Hotel { get; set; }
    [ForeignKey("IdTransport")]
    public TransportPartenairsModel? id_Transport { get; set; }
    [ForeignKey("IdGuide")]
    public GuidePartenairsModel? id_Guide { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}