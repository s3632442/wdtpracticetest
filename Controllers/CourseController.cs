using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EdInstitution.Models;
using EdInstitution.Data;
using Microsoft.EntityFrameworkCore;

namespace EdInstitution.Controllers;

public class CourseController : Controller
{

    private readonly InstitutionContext _context;

    private readonly ILogger<CourseController> _logger;

    public CourseController(ILogger<CourseController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult>  ListCourses()
    {
        
        var viewModel = new CoursesViewModel{
            courses = await _context.Courses.ToListAsync()
        };

        return View(viewModel);
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
