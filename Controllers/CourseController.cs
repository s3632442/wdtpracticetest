using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EdInstitution.Models;
using EdInstitution.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using X.PagedList; // Make sure to include this namespace for X.PagedList

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

        public async Task<IActionResult> ListCourses(int? page)
        {
            var courses = await _context.Courses
                .Include(course => course.Department)
                .Include(course => course.Enrollments)
                    .ThenInclude(enrollment => enrollment.Student)
                .ToListAsync();

            int pageNumber = page ?? 1; // If no page number is specified, default to 1
            int pageSize = 4; // Number of records per page

            var pagedCourses = courses.ToPagedList(pageNumber, pageSize);

            var viewModel = new CoursesViewModel
            {
                Courses = pagedCourses
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
