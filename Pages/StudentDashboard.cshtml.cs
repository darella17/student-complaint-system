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

        public List<Complaint> Complaints { get; set; }

        public void OnGet()
        {
            Complaints = _context.Complaints.ToList();
        }
    }
}