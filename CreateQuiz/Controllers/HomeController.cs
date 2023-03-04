using CreateQuiz.Context;
using CreateQuiz.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreateQuiz.Controllers
{
    public class HomeController : Controller
    {

        private readonly CreateQuizDBContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(CreateQuizDBContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            #region Db'ye user ekleme

           // AppUser user = new()
           // {
           //     UserName = "sezen",
           //     Email = "bestesyildirim@gmail.com",
           //     Id = Guid.NewGuid().ToString(),
           //     NormalizedUserName ="Sezen"

           // };

           //await  _userManager.CreateAsync(user, "Sezen.123");

           // var userList = _userManager.Users.ToList();
            #endregion
            return View();
        }


    }
}