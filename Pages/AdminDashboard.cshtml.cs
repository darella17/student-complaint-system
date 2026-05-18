using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentComplaintSystem.Data;
using StudentComplaintSystem.Models;
using System.Linq;

public class AdminDashboardModel : PageModel
{
    private readonly AppDbContext _context;

    public AdminDashboardModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Complaint> Complaints { get; set; } = new List<Complaint>();

    public IActionResult OnGet()
    {
        // 🔐 CHECK IF ADMIN IS LOGGED IN
        var isAdmin = HttpContext.Session.GetString("Admin");

        if (isAdmin != "true")
        {
            return RedirectToPage("/AdminLogin");
        }

        // load data only if admin
        Complaints = _context.Complaints.ToList();

        return Page();
    }
}