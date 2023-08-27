using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdInstitution.Data;
using EdInstitution.Models;
using System.Threading.Tasks;

namespace EdInstitution.Controllers
{
    public class EditInstructorController : Controller
    {
        private readonly InstitutionContext _context;

        public EditInstructorController(InstitutionContext context)
        {
            _context = context;
        }

        // ... other actions ...

        public async Task<IActionResult> EditInstructor(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View("~/Views/Instructor/EditInstructor.cshtml", instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditInstructor(int id, [Bind("ID,FirstName,LastName,HireDate")] Instructor instructor)
        {
            if (id != instructor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                // Redirect to the appropriate action method in InstructorController
                return RedirectToAction("ListInstructors", "Instructor");
            }
            return View(instructor);
        }


        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.ID == id);
        }
    }
}
