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
    [Required]
    [DataType(DataType.Text)]
    public string Review { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string City { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string Pays { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date_End { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date_Begin { get; set; }
    [Required]
    [ForeignKey("IdHotel")]
    public HotelPartenairsModel id_Hotel { get; set; }
    [Required]
    [ForeignKey("IdTransport")]
    public TransportPartenairsModel id_Transport { get; set; }
    [Required]
    [ForeignKey("IdGuide")]
    public GuidePartenairsModel id_Guide { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}