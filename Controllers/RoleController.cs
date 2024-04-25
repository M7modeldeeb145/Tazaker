using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tazaker.ViewModels;

namespace Tazaker.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserRoleVM userRoleVM)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole(userRoleVM.Name);
                var result = await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "InvalidRole");
                }
            }
            return View(userRoleVM);
        }
    }
}
