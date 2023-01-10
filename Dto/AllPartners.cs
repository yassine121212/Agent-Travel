
using dotn.Models;

namespace dotn.Dto;


public class AllPartners{
    public IEnumerable<HotelPartenairsModel> Hotels { get; set; }
    public IEnumerable<TransportPartenairsModel> Transports { get; set; }
    public IEnumerable<GuidePartenairsModel> Guides { get; set; }


}