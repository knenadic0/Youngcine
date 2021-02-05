using Microsoft.AspNetCore.Mvc;
using Mladacina.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Controllers
{
    public class DoctorController : Controller
    {
        #region Medicine

        public async Task<IActionResult> Medicine()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Doctor)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Medicine> medicines = await Models.Medicine.GetMedicinesAsync();
            return View("Medicine/Index", medicines);
        }

        #endregion Medicine
    }
}
