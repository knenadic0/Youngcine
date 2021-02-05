using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mladacina.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Controllers
{
    public class PatientController : Controller
    {
        #region Doctors

        [Route("[controller]/Doctors")]
        public async Task<IActionResult> Doctors()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Patient)
            {
                return RedirectToAction("Index", "Home");
            }

            Patient patient = HttpContext.Session.GetObjectFromJson<Patient>("UserRole");
            List<PatientDoctor> patientDoctors = await patient.GetPatientDoctorsAsync();
            return View("Doctors/Index", patientDoctors);
        }

        [HttpGet]
        [Route("[controller]/Doctors/Add")]
        public async Task<IActionResult> DoctorAdd()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Patient)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Doctor> doctors = await Doctor.GetDoctorsAsync();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (Doctor doctor in doctors)
            {
                listItems.Add(new SelectListItem
                {
                    Value = doctor.Id.ToString(),
                    Text = $"{doctor.User.FirstName} {doctor.User.LastName}"
                });
            }
            ViewData["Doctors"] = listItems;
            return View("Doctors/Create");
        }

        [HttpPost]
        [Route("[controller]/Doctors/Add")]
        public async Task<IActionResult> DoctorAdd(PatientDoctor model)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Patient)
            {
                return RedirectToAction("Index", "Home");
            }

            Patient patient = HttpContext.Session.GetObjectFromJson<Patient>("UserRole");
            try
            {
                await patient.DoctorEntryAsync(model);
            }
            catch (PostgresException e)
            {
                ModelState.AddModelError("DoctorAdd", e.MessageText);
                return View("Doctors/Create", model);
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Doctor successfully added.";
            return RedirectToAction("Doctors");
        }

        [HttpGet]
        [Route("[controller]/Doctors/Change")]
        public async Task<IActionResult> DoctorChange()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Patient)
            {
                return RedirectToAction("Index", "Home");
            }

            Patient patient = HttpContext.Session.GetObjectFromJson<Patient>("UserRole");
            List<Doctor> doctors = await patient.GetPharmaciesAsync();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (Doctor doctor in doctors)
            {
                listItems.Add(new SelectListItem
                {
                    Value = doctor.Id.ToString(),
                    Text = $"{doctor.User.FirstName} {doctor.User.LastName}"
                });
            }
            ViewData["Doctors"] = listItems;
            return View("Doctors/Create");
        }

        [HttpPost]
        [Route("[controller]/Doctors/Change")]
        public async Task<IActionResult> DoctorChange(PatientDoctor model)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Patient)
            {
                return RedirectToAction("Index", "Home");
            }

            Patient patient = HttpContext.Session.GetObjectFromJson<Patient>("UserRole");
            try
            {
                await patient.DoctorEntryAsync(model);
            }
            catch (PostgresException e)
            {
                ModelState.AddModelError("DoctorChange", e.MessageText);
                return View("Doctors/Create", model);
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Doctor successfully changed.";
            return RedirectToAction("Doctors");
        }

        #endregion Doctors

        #region Medicine

        public async Task<IActionResult> Medicine()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Patient)
            {
                return RedirectToAction("Index", "Home");
            }

            Patient patient = HttpContext.Session.GetObjectFromJson<Patient>("UserRole");
            dynamic medicines = new ExpandoObject();
            medicines.WithoutPrescription = await patient.GetPatientWithoutPrescriptionMedicinesAsync();
            return View("Medicine/Index", medicines);
        }

        [HttpGet]
        [Route("[controller]/Medicine/View/{id}")]
        public async Task<IActionResult> MedicineEdit(string id)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Patient)
            {
                return RedirectToAction("Index", "Home");
            }

            PatientMedicine model = await PatientMedicine.GetPatientMedicineAsync(id);
            return View("Medicine/Edit", model);
        }

        [HttpPost]
        [Route("[controller]/Medicine/View/{id}")]
        public async Task<IActionResult> MedicineEdit(PatientMedicine model)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Patient)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await model.FinishMedicineAsync();
            }
            catch (PostgresException e)
            {
                ModelState.AddModelError("EditPatientMedicine", e.MessageText);
                return View("Medicine/Edit", model);
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Medicine {model.Medicine.Name} marked as done taking.";
            return RedirectToAction("Medicine");
        }

        #endregion Medicine
    }
}
