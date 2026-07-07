using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;

namespace StudentComplaintSystem.Pages
{
    public class ConfirmResolutionModel : PageModel
    {
        private readonly AppDbContext _context;

        public ConfirmResolutionModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            var complaint = _context.Complaints.FirstOrDefault(c => c.Id == id);

            if (complaint == null)
            {
                return NotFound();
            }

            complaint.StudentConfirmed = true;

            _context.SaveChanges();

            return RedirectToPage("/StudentDashboard");
        }
    }
}