using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoRental.Services.Interfaces;
using VideoRental.ViewModels.UserViewModels;

namespace VideoRental_OnlineStore.Controllers
{
    public class UserController : Controller
    {
        public IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            UserLoginViewModel emptyUserLoginViewModel = new UserLoginViewModel();
            return View(emptyUserLoginViewModel);
        }

        [HttpPost]

        public IActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = _userService.GetAllUsers()
                                       .FirstOrDefault(x => x.CardNumber == model.CardNumber && x.FullName == model.FullName);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("UserFullName", user.FullName);


                    return RedirectToAction("ListMovies","Movie");
                }
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            
            int userId = _userService.RegisterNewUser(model);
            return RedirectToAction("Login");
        }

    }
}
