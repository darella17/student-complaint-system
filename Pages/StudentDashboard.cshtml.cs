using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;
using StudentComplaintSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentComplaintSystem.Pages
{
    public class StudentDashboardModel : PageModel
    {
        private readonly AppDbContext _context;

        public StudentDashboardModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Complaint> Complaints { get; set; } = new();

        public void OnGet(string? status)
        {
            var query = _context.Complaints.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(c => c.Status == status);
            }

            Complaints = query.ToList();
        }
    }
}