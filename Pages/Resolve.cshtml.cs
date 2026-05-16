using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;

namespace StudentComplaintSystem.Pages
{
    public class ResolveModel : PageModel
    {
        private readonly AppDbContext _context;

        public ResolveModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            var complaint = _context.Complaints.FirstOrDefault(c => c.Id == id);

            if (complaint != null)
            {
                complaint.Status = "Resolved";
                _context.SaveChanges();
            }

            return RedirectToPage("/AdminDashboard");
        }
    }
}