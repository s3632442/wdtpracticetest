using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EdInstitution.Data;
using X.PagedList;


namespace EdInstitution.Controllers
{
    public class InstructorController : Controller
    {
        private readonly InstitutionContext _context;

        public InstructorController(InstitutionContext context)
        {
            _context = context;
        }

 public async Task<IActionResult> ListInstructors(int? page)
{
    var instructors = await _context.Instructors
        .Include(i => i.CourseAssignments)
            .ThenInclude(ca => ca.Course)
        .ToListAsync();

    int pageNumber = page ?? 1; // If no page number is specified, default to 1
    int pageSize = 4; // Number of records per page

    var pagedInstructors = instructors.ToPagedList(pageNumber, pageSize);

    var viewModel = new InstructorsViewModel
    {
        Instructors = pagedInstructors
    };

    return View(viewModel);
}

        

    }
}
