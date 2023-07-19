
using LoginApplication.Models;
using LoginApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISignUpRepository _repository;

        public HomeController(ILogger<HomeController> logger,ISignUpRepository repository)
        {
            _logger = logger;
            _repository = repository;  
        }

        //Home Page
        public IActionResult Index()
        {
            return View();
        }

        //GET-User SignUp
        public IActionResult SignUp()
        {
            return View();
        }

        //POST-User SignUp
        [HttpPost]
        public IActionResult SignUp(SignUp signUp)
        {
                _repository.Add(signUp);
                TempData["Success"] = "User SignUp Succefully";
                return RedirectToAction(nameof(Index));  
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([Bind("Email", "NewPassword")]SignUp signUp)
        {
            List<SignUp> userList = _repository.GetAll().ToList();
            foreach (var item in userList)
            {
                if(item.Email==signUp.Email && item.NewPassword == signUp.NewPassword)
                {
                    return RedirectToAction(nameof(Welcome));
                }
            }
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }
        //Display All User in Tab
        public IActionResult UserInfo()
        {
            List<SignUp> signUps =_repository.GetAll().ToList();
            return View(signUps);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}