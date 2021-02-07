using Microsoft.AspNetCore.Mvc;
using Mladacina.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Controllers
{
    public class DoctorController : Controller
    {
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

        #region Patients

        public async Task<IActionResult> Patients()
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

            Doctor doctor = HttpContext.Session.GetObjectFromJson<Doctor>("UserRole");
            List<Patient> patients = await doctor.GetPatientsAsync();
            return View("Patients/Index", patients);
        }

        [HttpGet]
        [Route("[controller]/Patients/Visits/{id}")]
        public async Task<IActionResult> PatientView(string id)
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

            List<Visit> model = await Patient.GetPacientVisitsAsync(id);
            ViewData["Patient"] = await Patient.GetPatientAsync(id);
            return View("Patients/View", model);
        }

        public async Task<IActionResult> FinishDiagnose(string id)
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

            try
            {
                await Visit.FinishDiagnoseAsync(id);
            }
            catch (PostgresException e)
            {
                TempData["AlertType"] = "danger";
                TempData["AlertMessage"] = e.MessageText;
                string patientId = await Visit.GetPatientIdAsync(id);
                return RedirectToAction("PatientView", new { id = patientId });
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = "Diagnose marked as healed.";
            string patient = await Visit.GetPatientIdAsync(id);
            return RedirectToAction("PatientView", new { id = patient });
        }

        [HttpGet]
        [Route("[controller]/Patients/Visits/Create")]
        public async Task<IActionResult> VisitCreate(string id)
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

            Doctor doctor = HttpContext.Session.GetObjectFromJson<Doctor>("UserRole");
            Visit model = await Visit.InitializeVisitAsync(doctor.Id.ToString(), id);
            ViewData["Medicine"] = await Models.Medicine.GetMedicinesAsync();
            ViewData["Patient"] = await Patient.GetPatientAsync(id);
            return View("Patients/Visits/Create", model);
        }

        [HttpPost]
        [Route("[controller]/Patients/Visits/Create")]
        public async Task<IActionResult> VisitCreate(Visit model)
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

            try
            {
                await model.CreateVisitAsync();
            }
            catch (PostgresException e)
            {
                ViewData["Medicine"] = await Models.Medicine.GetMedicinesAsync();
                ViewData["Patient"] = await Patient.GetPatientAsync(model.Id.ToString());
                ModelState.AddModelError("CreateVisit", e.MessageText);
                return View("Patients/Visits/Create", model);
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Visit successfully created.";
            return RedirectToAction("PatientView", new { id = model.Id.ToString() });
        }

        #endregion Patients

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

        #region Visits

        public async Task<IActionResult> Visits()
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

            Doctor doctor = HttpContext.Session.GetObjectFromJson<Doctor>("UserRole");
            List<Visit> model = await doctor.GetVisitsAsync();
            return View("Visits/Index", model);
        }

        #endregion Visits
    }
}
