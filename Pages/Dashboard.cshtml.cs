using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;
using StudentComplaintSystem.Models;

namespace StudentComplaintSystem.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly AppDbContext _context;

        public List<Complaint> Complaints { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? StatusFilter { get; set; }

        public DashboardModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            var query = _context.Complaints.AsQueryable();

            if (!string.IsNullOrEmpty(StatusFilter))
            {
                query = query.Where(c => c.Status == StatusFilter);
            }

            Complaints = query.ToList();
        }
    }
}