using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace dotn.Models;

public class GuidePartenairsModel
{
    [Key]
    public int IdGuide { get; set; }
    [Required]
    [MaxLength(35)]
    public string Name_Guide { get; set; }
    [Required]
    [DataType(DataType.Text)]
    public string City_Guide { get; set; }
    [Required]
    [Phone]
    public int Phone_Guide { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}