using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentComplaintSystem.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string email, string password)
        {
            // temporary login check (we will improve later)
            if (email == "admin@gmail.com" && password == "1234")
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}