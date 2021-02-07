using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mladacina.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Mladacina.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment HostEnvironment { get; }

        public HomeController(IWebHostEnvironment hostEnvironment)
        {
            HostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View("Index", user);
        }

        [HttpGet]
        [Route("[controller]/Picture/Change")]
        public async Task<IActionResult> ChangePicture()
        {
            User model = HttpContext.Session.GetObjectFromJson<User>("User");
            if (model == null)
            {
                return RedirectToAction("Login");
            }

            Image image = new Image()
            {
                User = model
            };
            return View(image);
        }

        [HttpPost]
        [Route("[controller]/Picture/Change")]
        public async Task<IActionResult> ChangePicture(Image model)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            if (model.File.Length > 0)
            {
                model.User = user;
                string filePath = model.User.Id.ToString() + ".jpg";
                filePath = Path.Combine(HostEnvironment.WebRootPath, "media", "pictures", "profile", filePath);
                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    await model.File.CopyToAsync(stream);
                }
                filePath = Path.GetRandomFileName();
                filePath = Path.Combine("D:", filePath);
                using (FileStream stream = System.IO.File.Create(filePath))
                {
                    await model.File.CopyToAsync(stream);
                }
                await model.ChangePictureAsync(filePath);
                System.IO.File.Delete(filePath);

                TempData["AlertType"] = "success";
                TempData["AlertMessage"] = "Picture successfully changed. You can log in now.";
                return RedirectToAction("Logout");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("[controller]/Picture/Remove")]
        public async Task<IActionResult> RemovePicture()
        {
            User model = HttpContext.Session.GetObjectFromJson<User>("User");
            if (model == null)
            {
                return RedirectToAction("Login");
            }

            await model.RemovePictureAsync();
            System.IO.File.Delete(Path.Combine(HostEnvironment.WebRootPath, "media", "pictures", "profile", model.Id.ToString() + ".jpg"));

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = "Picture successfully removed. You can log in now.";
            return RedirectToAction("Logout");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") != null)
            {
                return RedirectToAction("Index");
            }

            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Login", "Inocorrect email or password.");
                return View("Login", model);
            }

            try
            {
                Tuple<int, object> userRole = await model.LoginUserAsync();
                if (userRole.Item1 == -1)
                {
                    ModelState.AddModelError("Login", "Inocorrect email or password.");
                    return View("Login", model);
                }

                HttpContext.Session.SetObjectAsJson("UserRole", userRole.Item2);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Login", "Inocorrect email or password.");
                return View("Login", model);
            }

            HttpContext.Session.SetObjectAsJson("User", model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            try
            {
                await Models.User.RegisterUserAsync(model);
            }
            catch (PostgresException e)
            {
                ModelState.AddModelError("Register", e.MessageText);
                return View("Register", model);
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Successfully registered. You can now log in.";
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
