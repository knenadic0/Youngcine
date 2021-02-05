using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mladacina.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Mladacina.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<User>("User") == null)
            {
                return RedirectToAction("Login");
            }

            return View("Index", HttpContext.Session.GetObjectFromJson<User>("User"));
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
                Tuple<int, object> userRole = await Models.User.LoginUserAsync(model);
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
