using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using test_work_fin_12.Data;
using test_work_fin_12.Models;
using test_work_fin_12.ViewModels;

namespace test_work_fin_12.Controllers {
    public class UserController : Controller {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;

        public UserController (UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context) {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Login (string returnUrl) {
            return View (new LoginVM () {
                ReturnUrl = returnUrl
            });
        }

        // Метод для проверки Логина пользователя
        [HttpPost]
        public async Task<IActionResult> Login (LoginVM loginVM) {

            if (!ModelState.IsValid) {
                return View (loginVM);
            }

            var user = await _userManager.FindByNameAsync (loginVM.UserName);

            if (user != null) {
                var result = await _signInManager.PasswordSignInAsync (user, loginVM.Password, false, false);

                if (result.Succeeded) {
                    if (string.IsNullOrEmpty (loginVM.ReturnUrl))
                        return RedirectToAction ("Index", "Home");
                    return Redirect (loginVM.ReturnUrl);
                }
            }
            ModelState.AddModelError ("", "Логин или Пароль введены не верно");
            return View (loginVM);
        }

        // Метод для Регистрации пользователя
        public IActionResult Register () {
            return View ();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register (LoginVM loginVM, string role, string returnUrl = null) {

            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid) {
                var user = new User () { UserName = loginVM.UserName };
                var result = await _userManager.CreateAsync (user, loginVM.Password);

                if (result.Succeeded) {

                    if (role == null) {
                        role = "User";
                    }

                    await _userManager.AddToRoleAsync (user, role.ToUpper ());

                    return RedirectToAction ("Index", "Home");
                }
                // return RedirectToLocal (returnUrl);
            }

            return View (loginVM);
        }

        // Метод для Выхода пользователя 
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout () {
            await _signInManager.SignOutAsync ();
            return RedirectToAction ("Index", "Home");
        }

        // Метод для создания ролей
        public async Task<IActionResult> CreateRole (string role, string id) {
            var user = await _userManager.FindByIdAsync (id);

            List<string> allRoles = new List<string> () {
                "Admin",
                "Manager",
                "User"
            };
            await _userManager.RemoveFromRolesAsync (user, allRoles);
            await _userManager.AddToRoleAsync (user, role);
            await _context.SaveChangesAsync ();
            return RedirectToAction ("Index", "Home");
        }
    }
}