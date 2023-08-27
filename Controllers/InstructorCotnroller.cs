using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdInstitution.Data;

namespace EdInstitution.Controllers
{
    public class InstructorController : Controller
    {
        private readonly InstitutionContext _context;

        public InstructorController(InstitutionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListInstructors()
        {
            var instructors = await _context.Instructors.ToListAsync();

            var viewModel = new InstructorsViewModel
            {
                Instructors = instructors
            };

            return View(viewModel);
        }
    }
}
