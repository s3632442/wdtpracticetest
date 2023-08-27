using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdInstitution.Data;
using EdInstitution.Models;
using System.Threading.Tasks;

namespace EdInstitution.Controllers
{
    public class EditCourseController : Controller
    {
        private readonly InstitutionContext _context;

        public EditCourseController(InstitutionContext context)
        {
            _context = context;
        }

        // ... other actions ...

        public async Task<IActionResult> EditCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View("~/Views/Course/EditCourse.cshtml", course);
        }

        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> EditCourse(int id, [Bind("CourseID,Title,Credits,DepartmentID")] Course course)
{
    if (id != course.CourseID)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(course);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CourseExists(course.CourseID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        // Redirect to the appropriate action method in CourseController
        return RedirectToAction("ListCourses", "Course");
    }
    return View(course);
}


        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
    }
}
