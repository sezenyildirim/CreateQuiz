using CreateQuiz.DTOS;
using CreateQuiz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CreateQuiz.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if(user == null)
            {
                TempData["userName"] = loginDTO.UserName;
                TempData["password"] = loginDTO.Password;
                TempData["errors"] = "Kullanıcı bulunamadı!";
                return RedirectToAction("Login", "Auth");
            }
            bool result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);

            if(!result)
            {
                TempData["userName"] = loginDTO.UserName;
                TempData["password"] = loginDTO.Password;
                TempData["errors"] = "Şifre hatalı!";
                return RedirectToAction("Login", "Auth");
            }
            return RedirectToAction("Index", "Home");
        }
    

    }
}
