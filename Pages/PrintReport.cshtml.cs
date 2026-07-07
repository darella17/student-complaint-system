using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;
using StudentComplaintSystem.Models;

namespace StudentComplaintSystem.Pages
{
    public class PrintReportModel : PageModel
    {
        private readonly AppDbContext _context;

        public PrintReportModel(AppDbContext context)
        {
            _context = context;
        }

        public Complaint Complaint { get; set; }

        public IActionResult OnGet(int id)
        {
            Complaint = _context.Complaints.FirstOrDefault(c => c.Id == id);

            if (Complaint == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}