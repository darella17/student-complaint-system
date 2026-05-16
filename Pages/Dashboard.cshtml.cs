using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;
using StudentComplaintSystem.Models;

namespace StudentComplaintSystem.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Complaint> Complaints { get; set; }

        public DashboardModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Complaints = _context.Complaints.ToList();
        }
    }
}