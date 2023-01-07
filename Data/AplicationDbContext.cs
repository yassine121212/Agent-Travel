using dotn.Models;
namespace dotn.Data;
using Microsoft.EntityFrameworkCore;
public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<OffreModel> Offres { get; set; }
    public DbSet<GuidePartenairsModel> GuidePartenairs { get; set; }
    public DbSet<TransportPartenairsModel> TransportPartenairs { get; set; }
    public DbSet<HotelPartenairsModel> HotelPartenairs { get; set; }
}