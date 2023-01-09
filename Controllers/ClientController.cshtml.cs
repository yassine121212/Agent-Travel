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
    {
        return View();
    }
    public ActionResult Profile()
    {

        return View();


    }
    public IActionResult Search()
    {
        return View();
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
