using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotn.Models;

public class CommandeModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [ForeignKey("IdUser")]
    public UserModel id_user { get; set; }
    [Required]
    [ForeignKey("IdOffre")]
    public OffreModel id_offre { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    public double Total_Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}