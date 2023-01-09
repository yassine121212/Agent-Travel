using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace dotn.Models;

public class UserModel
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(35)]
    public string Name_User { get; set; }
    [Required]
    [MaxLength(35)]
    public string LastName_User { get; set; }
    [Required]
    [MaxLength(45)]
    public string Adress { get; set; }
    [Required]
    [Phone]
    public string Phone { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [DataType(DataType.ImageUrl)]
    public string? Picture_User { get; set; }
    [Required]
    [DataType(DataType.Password)]

    public string Password { get; set; }

    [DefaultValue(false)]
    public bool? is_Admin { get; set; }
    [DefaultValue(false)]
    public bool? is_Actived { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}