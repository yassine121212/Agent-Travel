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
<<<<<<< HEAD
        var currentYear = DateTime.Now.Year;
        var currentDay = DateTime.Now.Day;

        var commands = _db.Commandes.Include(s => s.id_offre).Where(c => c.id_offre.CreatedAt.Year == currentYear).ToList();
        var offres_Ann = _db.Offres.Where(c => c.CreatedAt.Year == currentYear).ToList();

        //Les commandes de jour actuel
        var commands_Day = _db.Commandes.Include(s => s.id_offre).Where(c => c.id_offre.CreatedAt.Day == currentDay && c.id_offre.CreatedAt.Year == currentYear).ToList();
        //Prévisions de ventes 
        var commands_Price_Sum = _db.Commandes.Include(s => s.id_offre)
        .Where(c => c.id_offre.CreatedAt.Year == currentYear).Sum(w => w.Total_Price);
        var commands_Price_Avg = _db.Commandes.Include(s => s.id_offre)
        .Where(c => c.id_offre.CreatedAt.Year == currentYear).Average(w => w.Total_Price);
        //Lead Conversion Rate
        var numberOfOffres = _db.Offres.Count();
        var commandes_offres = _db.Commandes.Include(s => s.id_offre).Count();
        var sum_maxPlaces_offres = _db.Offres.Sum(c => c.max_places);
        var OccupiedPlaces = commandes_offres / sum_maxPlaces_offres * 100;

        //Prévisions de ventes
        @ViewBag.forecast = Math.Round(commands_Price_Avg / commands_Price_Sum * 100, 2);
        //Lead Conversion Rate
        @ViewBag.CR = OccupiedPlaces;
        //
        @ViewBag.offf = _db.Offres.ToArray();
        Console.WriteLine("eeeeeeeeeeeeee");
        Console.WriteLine(@ViewBag.offf);
        @ViewBag.chiff_offres_Day = commands_Day.Sum(c => c.Total_Price);
        @ViewBag.chiff_offres = offres_Ann.Sum(c => c.Price_Offre);
        @ViewBag.profit = commands.Sum(c => c.Total_Price);
        @ViewBag.nb_offres = _db.Offres.Count();
        // var jsonData = JsonConvert.SerializeObject(commands_Price);
        // Console.WriteLine(jsonData);
        // var author_names = new[] { jsonData };

        // foreach (var item in author_names)
        // {
        //     Console.WriteLine(item);
        // }
        // var salesData = new[] { 100, 200, 150, 300, 250, 400, 350, 500, 450, 600, 550, 650 };
        // var periods = 12;
        // var forecast = salesData.TakeLast(periods).Average();
        // Console.WriteLine("forecast: " + forecast);
=======
>>>>>>> main
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
<<<<<<< HEAD
    public IActionResult Add_Offre()
    {
        var hotels = _db.HotelPartenairs.ToList();
        var transports = _db.TransportPartenairs.ToList();
        var guides = _db.GuidePartenairs.ToList();

        ViewBag.guides = guides;
        ViewBag.Hotels = hotels;
        ViewBag.Transports = transports;

=======
    public IActionResult Add_Offre(){
>>>>>>> main
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
     public IActionResult Add_Offre(OffreModel obj)
    {
<<<<<<< HEAD

        _db.Offres.Add(obj);
        _db.SaveChanges();
        return RedirectToAction("Display_Offres");

=======
         _db.Offres.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Display_Offres");
       
>>>>>>> main
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
