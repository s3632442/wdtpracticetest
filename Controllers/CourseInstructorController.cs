using EdInstitution.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace EdInstitution.Controllers
{
    public class CourseInstructorController : Controller
    {
        private readonly InstitutionContext _context;

        public CourseInstructorController(InstitutionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var instructors = await _context.Instructors
                .Include(i => i.CourseAssignments)
                    .ThenInclude(ca => ca.Course)
                .ToListAsync();

            int pageNumber = page ?? 1; // If no page number is specified, default to 1
            int pageSize = 4; // Number of records per page

            var pagedInstructors = instructors.ToPagedList(pageNumber, pageSize);

            var courses = await _context.Courses
                .Include(course => course.Department)
                .Include(course => course.Enrollments)
                    .ThenInclude(enrollment => enrollment.Student)
                .ToListAsync();

            var pagedCourses = courses.ToPagedList(pageNumber, pageSize);

            var coursesViewModel = new CoursesViewModel
            {
                Courses = pagedCourses
            };

            var instructorsViewModel = new InstructorsViewModel
            {
                Instructors = pagedInstructors
            };

            var viewModel = new CoursesAndInstructorsViewModel
            {
                Courses = coursesViewModel,
                Instructors = instructorsViewModel
            };

            return View(viewModel);
        }




    }
}
