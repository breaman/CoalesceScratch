using Scratch.CoalesceScratch.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Scratch.CoalesceScratch.Web.Pages;

public class SignOutModel(SignInManager<User> signInManager) : PageModel
{
    public async Task<IActionResult> OnGet()
    {
        await signInManager.SignOutAsync();
        return Redirect("/");
    }

    public async Task<IActionResult> OnPost()
    {
        await signInManager.SignOutAsync();
        return Redirect("/");
    }
}
