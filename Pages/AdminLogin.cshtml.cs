using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentComplaintSystem.Pages
{
    public class AdminLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "1234")
            {
                HttpContext.Session.SetString("Admin", "true");
                return RedirectToPage("/AdminDashboard");
            }

            ErrorMessage = "Invalid login";
            return Page();
        }
    }
}