using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;
using StudentComplaintSystem.Models;

namespace StudentComplaintSystem.Pages
{
    public class SubmitComplaintModel : PageModel
    {
        private readonly AppDbContext _context;

        public SubmitComplaintModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string StudentName { get; set; }

        [BindProperty]
        public string MatricNumber { get; set; }

        [BindProperty]
        public string Level { get; set; }

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Description { get; set; }

        public IActionResult OnPost()
        {
            var complaint = new Complaint
            {
                StudentName = StudentName,
                MatricNumber = MatricNumber,
                Level = Level,
                Title = Title,
                Description = Description,
                Status = "Pending",
                DateSubmitted = DateTime.Now
            };

            _context.Complaints.Add(complaint);
            _context.SaveChanges();

            return RedirectToPage("/StudentDashboard");
        }
    }
}