using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EdInstitution.Models;
using EdInstitution.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; // Make sure to include this namespace for ILogger

namespace EdInstitution.Controllers
{
    public class CourseController : Controller
    {
        private readonly InstitutionContext _context;
        private readonly ILogger<CourseController> _logger;

        public CourseController(InstitutionContext context, ILogger<CourseController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> ListCourses()
        {
            var courses = await _context.Courses
                .Include(course => course.Department) // Include the Department navigation property
                .ToListAsync();

            var viewModel = new CoursesViewModel
            {
                courses = courses
            };

            return View("ListCourses", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
