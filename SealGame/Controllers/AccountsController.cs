using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SealGame.Core.Domain;
using SealGame.Core.Dto.AccountsDtos;
using SealGame.Data;
using SealGame.Models.Accounts;

namespace SealGame.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUserDto> _userManager;
        private readonly SignInManager<ApplicationUserDto> _signInManager;
        private readonly DatabaseTaskDbContext _context;
        public AccountsController
            (UserManager<ApplicationUserDto> userManager,
            SignInManager<ApplicationUserDto> signInManager,
            DatabaseTaskDbContext context
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> AddPassword()
        {
            var user = await _userManager.GetUserAsync(User);
            var userHasPassword = await _userManager.HasPasswordAsync(user);
            if (userHasPassword)
            {
                RedirectToAction("ChangePassword");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPassword(AddPassWordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userManager.AddPasswordAsync(user, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return View("AddPasswordConfirmation");
            }
            return View(model);
        }
    }
}
