using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Scratch.CoalesceScratch.Data.Auth;
using Scratch.CoalesceScratch.Data.Models;

namespace Scratch.CoalesceScratch.Web.Pages;

public class ConfirmEmail(UserManager<User> userManager, SignInManager<User> signInManager) : PageModel
{
    public const string InvalidError = "The link is no longer valid.";

    public async Task<IActionResult> OnGetAsync(string userId, string code, string? newEmail)
    {
        if (
            string.IsNullOrWhiteSpace(userId) || 
            string.IsNullOrWhiteSpace(code) || 
            (await userManager.FindByIdAsync(userId)) is not { } user
        )
        {
            ModelState.AddModelError("", InvalidError);
            return Page();
        }

        var result = string.IsNullOrWhiteSpace(newEmail)
            ? await userManager.ConfirmEmailAsync(user, code)
            : await userManager.ChangeEmailAsync(user, newEmail, code);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", InvalidError);
            return Page();
        }

        if (User.GetUserId() == user.Id)
        {
            // The verifying user is already signed in. Refresh their session
            // so they see the new email.
            await signInManager.RefreshSignInAsync(user);
        }
        else
        {
            // A different user was signed in. Sign the user out so they don't get confused.
            await signInManager.SignOutAsync();
        }

        return Page();
    }
}
