using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;
using StudentComplaintSystem.Models;

namespace StudentComplaintSystem.Pages
{
    public class QualityControlReportModel : PageModel
    {
        private readonly AppDbContext _context;

        public QualityControlReportModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Complaint> Complaints { get; set; } = new();

        public Dictionary<string, int> CategoryStats { get; set; } = new();

        public void OnGet()
        {
            Complaints = _context.Complaints.ToList();

            CategoryStats = Complaints
                .GroupBy(c => c.Category)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}