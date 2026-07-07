using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentComplaintSystem.Data;
using StudentComplaintSystem.Models;

namespace StudentComplaintSystem.Pages
{
    public class AdminDashboardModel : PageModel
    {
        private readonly AppDbContext _context;

        public AdminDashboardModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Complaint> Complaints { get; set; } = new();

        public IActionResult OnGet(string? status, string? level, string? matricNumber, string? category)
        {
            // TEMP: bypass session completely for testing
            // (we remove authentication until page works)

            var query = _context.Complaints.AsQueryable();

            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(c => c.Status == status);

            if (!string.IsNullOrWhiteSpace(level))
                query = query.Where(c => c.Level == level);

            if (!string.IsNullOrWhiteSpace(matricNumber))
                query = query.Where(c =>
                    EF.Functions.Like(c.MatricNumber, $"%{matricNumber}%"));

            if (!string.IsNullOrWhiteSpace(category))
                query = query.Where(c => c.Category == category);

            Complaints = query.ToList();

            return Page();
        }
    }
}