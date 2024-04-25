using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tazaker.Models;
using Tazaker.ViewModels;

namespace Tazaker.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private ILogger<AccountController> logger;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Regesteration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Regesteration(ApplicationUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName,
                    Email = userVM.Email,
                    PasswordHash = userVM.Password,
                    UserName = userVM.Email,
                    PhoneNumber = userVM.PhoneNumer
                };
                var result = await userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user,true);
                    return View("Home", "Index");
                }
                return View();

            }
            return View(userVM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await userManager.FindByEmailAsync(loginVM.Email);
                if (result != null)
                {
                    bool check = await userManager.CheckPasswordAsync(result, loginVM.Password);
                    if (check)
                    {
                        await signInManager.SignInAsync(result, loginVM.RememberMe);
                        return RedirectToAction("Index", "Home");   
                    }
                    //Invalid Password
                    ModelState.AddModelError("InvalidPass", "InvalidPassword");
                }
                //Invalid User
                ModelState.AddModelError("InvalidUs", "InvalidUser");
            }
            return View(loginVM);
        }
        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
		public async Task<IActionResult> CurrentUserDetails()
		{
			var user = await userManager.GetUserAsync(User);
			if (user == null)
			{
				return RedirectToAction("Login", "Account");
			}
			return View(user);
		}
    }
}
