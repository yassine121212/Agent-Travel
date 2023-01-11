using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using dotn.Data;
using dotn.Models;
using System.Text;
namespace dotn.Controllers;
using X.PagedList;

public class ClientController : Controller
{
    private readonly ILogger<ClientController> _logger;
    private readonly AplicationDbContext _db;

    public ClientController(ILogger<ClientController> logger, AplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    { HttpContext.Session.Clear();
  IEnumerable<OffreModel> offredata = _db.Offres;
        return View(offredata);
    }
    
    public ActionResult Profile()
    {
         HttpContext.Session.Clear();
       
        return View();

    }
    
    [HttpGet]
    public ActionResult Search(int ? isinter,int? id,int Minprice, string villedest,string villedp,int Adult,int Enfant,int Maxprice, string Dest, string Depart, int Hotel, int page = 1, int pageSize = 2)
    {  if (!string.IsNullOrEmpty(villedest)){
        HttpContext.Session.SetString("ville",villedest);}
        if(!string.IsNullOrEmpty(villedp)){
          HttpContext.Session.SetString("villedep",villedp);}
          if(Adult!=0 ){
            HttpContext.Session.SetInt32("nbAdult",Adult);}
              if(Enfant!=0 ){
            HttpContext.Session.SetInt32("nbEnf",Enfant);}
               if(id!=null){
            HttpContext.Session.SetInt32("idofrre", (int)id);}
                if(isinter!=null){
            HttpContext.Session.SetString("intern","Maroc");}
            
        
        
        IEnumerable<OffreModel> data = GetData(Minprice, Maxprice, Hotel, Dest, Depart);
        PagedList<OffreModel> model = new PagedList<OffreModel>(data, page, pageSize);
        return View(model);
    }

    private List<OffreModel> GetData(int Minprice, int Maxprice, int Hotel, string Dest, string Depart)
    {
        //int price = Int32.Parse(prixmin);
        var query = _db.Offres.Include(d => d.id_Hotel).Include(d => d.id_Transport).AsQueryable();
if (!string.IsNullOrEmpty(HttpContext.Session.GetString("ville")))
{query = query.Where(d => d.Ville_Arrivee.Contains(HttpContext.Session.GetString("ville")));
    
}
if (!string.IsNullOrEmpty(HttpContext.Session.GetString("villedep")))
{query = query.Where(d => d.City.Contains(HttpContext.Session.GetString("villedep")));
    
}
if ( HttpContext.Session.GetInt32("idofrre")!=null)
{query = query.Where(d => d.Id==HttpContext.Session.GetInt32("idofrre"));
    
}
if (!string.IsNullOrEmpty(HttpContext.Session.GetString("intern")))
{query = query.Where(d => d.Pays.Contains(HttpContext.Session.GetString("intern")));
    
}
        if (Minprice != 0)
        {
            query = query.Where(d => d.Price_Offre >= Minprice);
        }
        if (Maxprice != 0)
        {
            query = query.Where(d => d.Price_Offre <= Maxprice);
        }
        if (Hotel != 0)
        {
            query = query.Where(d => d.id_Hotel.Rating == Hotel);
        }
        DateTime dt, dst;
        if (DateTime.TryParse(Depart, out dt))
        {
            query = query.Where(s => s.Date_Begin.Date == dt.Date);


        }
        if (DateTime.TryParse(Dest, out dst))
        {
            query = query.Where(s => s.Date_End.Date == dst.Date);


        }
        return query.ToList();

    }
    
    public ActionResult Logout()
    {
        HttpContext.Session.Clear();//remove session
        return RedirectToAction("Login");
    }
    public ActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Login(string Email, string Password)
    {
        if (ModelState.IsValid)
        {



            var data = _db.Users.Where(s => s.Email.Equals(Email) && s.Password.Equals(GetMD5(Password))).ToList();
            if (data.Count() > 0)
            {
                HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
                HttpContext.Session.SetInt32("id", data.FirstOrDefault().Id);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Login");
            }
        }
        return View();
    }

    public ActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(UserModel _user)
    {
        if (ModelState.IsValid)
        {
            var check = _db.Users.FirstOrDefault(s => s.Email == _user.Email);
            if (check == null)
            {
                _user.Password = GetMD5(_user.Password);
                _db.Users.Add(_user);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.error = "Email already exists";
                return View();
            }


        }
        return View();


    }
    public static string GetMD5(string str)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] fromData = Encoding.UTF8.GetBytes(str);
        byte[] targetData = md5.ComputeHash(fromData);
        string byte2String = null;

        for (int i = 0; i < targetData.Length; i++)
        {
            byte2String += targetData[i].ToString("x2");

        }
        return byte2String;
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}