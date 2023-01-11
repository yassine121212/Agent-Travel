using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace dotn.Models;

public class HotelPartenairsModel
{
    [Key]
    public int IdHotel { get; set; }
    [Required]
    [MaxLength(35)]
    public string Name_Hotel { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string City_Hotel { get; set; }
    [DefaultValue(0)]
    public int Rating { get; set; }

    [Required]
    [DataType(DataType.ImageUrl)]
    public string Picture_Hotel { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}