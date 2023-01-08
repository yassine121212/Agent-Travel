using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotn.Models;

namespace dotn.Controllers;

public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
     public IActionResult Display_Offres()
    {
        return View();
    }
     public IActionResult Add_Offre()
    {
        return View();
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


    


    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
