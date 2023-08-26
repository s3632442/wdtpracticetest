using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EdInstitution.Models;

namespace EdInstitution.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public string wobbledonk() => "touch me wobbledonk";


    ///Home/Welcome?name=booz&numTimes=77
    public string Welcome(string name, int numTimes) => $"hello {name}, Numtimes is {numTimes}.";

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
