using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotn.Models;
using dotn.Dto;
using dotn.Data;


namespace dotn.Controllers;

public class AdminController : Controller
{
    private readonly AplicationDbContext _db;

    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger,AplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }
     public IActionResult Display_Offres(int? id)
    {
        // if(id==null || id == 0)
        // {
        // var offreDb = _db.Offres.Find(id);
        // return View(offreDb);

        // }
              
      IEnumerable<OffreModel> objOffresList = _db.Offres;

        return View(objOffresList);
    }
    public IActionResult Add_Offre(){
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
     public IActionResult Add_Offre(OffreModel obj)
    {
         _db.Offres.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Display_Offres");
       
    }
     public IActionResult Edit_Offre(int? id)
    {
        if(id==null || id == 0)
        {
            return NotFound();
        }
        var offreDb = _db.Offres.Find(id);
        //var offreDbFirst = _db.Offres.FirstOrDefault(u=>u.Id==id);
        //var offreDbSingle = _db.Offres.SingleOrDefault(u => u.Id == id);

        if (offreDb == null)
        {
            return NotFound();
        }

        return View(offreDb);
    }
       [HttpPost]
    [ValidateAntiForgeryToken]
     public IActionResult Edit_Offre(OffreModel obj)
    {
         _db.Offres.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Display_Offres");
       
    }

    public IActionResult Delete(int? id)
    {
        var obj = _db.Offres.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Offres.Remove(obj);
            _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Display_Offres");
        
    }
    public IActionResult Display_Users()
    {
        return View();
    }
     public IActionResult Add_User()
    {
        return View();
    }
 public IActionResult Display_Partners()
    {     
       
        return View();
    }
     public IActionResult Add_Partner()
    {
        return View();
    }
    
     public IActionResult HotelPartenaire()
    {     
             IEnumerable<HotelPartenairsModel> hotels = _db.HotelPartenairs;

        return View(hotels);
    }
     public IActionResult TransportPartenaire()
    {     
                    IEnumerable<TransportPartenairsModel> transports = _db.TransportPartenairs;

        return View(transports);
    }
     public IActionResult GuidePartenaire()
    {     
                           IEnumerable<GuidePartenairsModel> Guides = _db.GuidePartenairs;

        return View(Guides);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
     public IActionResult Add_Hotel(HotelPartenairsModel obj)
    {
         _db.HotelPartenairs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("HotelPartenaire");
    }

 [HttpPost]
    [ValidateAntiForgeryToken]
     public IActionResult Add_Transport(TransportPartenairsModel obj)
    {
         _db.TransportPartenairs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("TransportPartenaire");
    }


 [HttpPost]
    [ValidateAntiForgeryToken]
     public IActionResult Add_Guide(GuidePartenairsModel obj)
    {
         _db.GuidePartenairs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("GuidePartenaire");
    }



    


    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
