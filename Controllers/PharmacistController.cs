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
    public class PharmacistController : Controller
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
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Patient> patients = await Patient.GetPatientsAsync();
            return View("Patients/Index", patients);
        }

        [HttpGet]
        [Route("[controller]/Patients/View/{id}")]
        public async Task<IActionResult> PatientView(string id)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            Patient patient = await Patient.GetPatientAsync(id);
            dynamic medicines = new ExpandoObject();
            medicines.WithoutPrescription = await patient.GetPatientWithoutPrescriptionMedicinesAsync();
            medicines.WithPrescription = await patient.GetPatientPrescriptionMedicinesAsync();
            ViewData["Patient"] = patient;
            return View("Patients/View", medicines);
        }

        public async Task<IActionResult> PrescriptionIssue(string id)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await Prescription.StartPrescriptionAsync(id);
            }
            catch (PostgresException e)
            {
                TempData["AlertType"] = "danger";
                TempData["AlertMessage"] = e.MessageText;
                Tuple<string, string> tuple = await Prescription.GetPatientIdAsync(id);
                return RedirectToAction("PatientView", new { id = tuple.Item1 });
            }

            Tuple<string, string> model = await Prescription.GetPatientIdAsync(id);
            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Prescription medicine {model.Item2} marked as issued.";
            return RedirectToAction("PatientView", new { id = model.Item1 });
        }

        [HttpGet]
        [Route("[controller]/Patients/Medicine/Add")]
        public async Task<IActionResult> MedicineAdd(string id)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            Patient patient = await Patient.GetPatientAsync(id);
            ViewData["Medicine"] = await Models.Medicine.GetMedicinesAsync(true);
            ViewData["Patient"] = patient;
            PatientMedicine model = new PatientMedicine()
            {
                PatientId = patient.Id
            };
            return View("Patients/Medicine/Create", model);
        }

        [HttpPost]
        [Route("[controller]/Patients/Medicine/Add")]
        public async Task<IActionResult> MedicineAdd(PatientMedicine model)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            Pharmacist pharmacist = HttpContext.Session.GetObjectFromJson<Pharmacist>("UserRole");
            try
            {
                model.PharmacistId = pharmacist.Id;
                await model.CreatePatientMedicineAsync();
            }
            catch (PostgresException e)
            {
                ViewData["Medicine"] = await Models.Medicine.GetMedicinesAsync();
                ViewData["Patient"] = await Patient.GetPatientAsync(model.Id.ToString());
                TempData["AlertType"] = "danger";
                TempData["AlertMessage"] = e.MessageText;
                return RedirectToAction("PatientView", new { id = model.PatientId.ToString() });
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Medicine successfully issued.";
            return RedirectToAction("PatientView", new { id = model.PatientId.ToString() });
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
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Medicine> medicines = await Models.Medicine.GetMedicinesAsync();
            return View("Medicine/Index", medicines);
        }

        [HttpGet]
        [Route("[controller]/Medicine/Create")]
        public async Task<IActionResult> MedicineCreate()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("Medicine/Create");
        }

        [HttpPost]
        [Route("[controller]/Medicine/Create")]
        public async Task<IActionResult> MedicineCreate(Medicine model)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await model.CreateMedicineAsync();
            }
            catch (PostgresException e)
            {
                ModelState.AddModelError("CreateMedicine", e.MessageText);
                return View("Medicine/Create", model);
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Medicine {model.Name} successfully created.";
            return RedirectToAction("Medicine");
        }

        [HttpGet]
        [Route("[controller]/Medicine/Edit/{id}")]
        public async Task<IActionResult> MedicineEdit(string id)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            Medicine model = await Models.Medicine.GetMedicineAsync(id);
            return View("Medicine/Create", model);
        }

        [HttpPost]
        [Route("[controller]/Medicine/Edit/{id}")]
        public async Task<IActionResult> MedicineEdit(Medicine model)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await Models.Medicine.EditMedicineAsync(model);
            }
            catch (PostgresException e)
            {
                ModelState.AddModelError("EditMedicine", e.MessageText);
                return View("Medicine/Create", model);
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Medicine {model.Name} successfully edited.";
            return RedirectToAction("Medicine");
        }

        #endregion Medicine

        #region Career

        [Route("[controller]/Career")]
        public async Task<IActionResult> Pharmacies()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            Pharmacist pharmacist = HttpContext.Session.GetObjectFromJson<Pharmacist>("UserRole");
            List<PharmacistCareer> careers = await pharmacist.GetPharmacistCareersAsync();
            return View("Career/Index", careers);
        }

        [HttpGet]
        [Route("[controller]/Career/Start")]
        public async Task<IActionResult> CareerStart()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            List<Pharmacy> pharmacies = await Pharmacy.GetPharmaciesAsync();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (Pharmacy pharmacy in pharmacies)
            {
                listItems.Add(new SelectListItem
                {
                    Value = pharmacy.Id.ToString(),
                    Text = $"{pharmacy.Name} ({pharmacy.Street} {pharmacy.Number}, {pharmacy.City})"
                });
            }
            ViewData["Pharmacies"] = listItems;
            return View("Career/Create");
        }

        [HttpPost]
        [Route("[controller]/Career/Start")]
        public async Task<IActionResult> CareerStart(PharmacistCareer model)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            Pharmacist pharmacist = HttpContext.Session.GetObjectFromJson<Pharmacist>("UserRole");
            try
            {
                await pharmacist.CareerEntryAsync(model);
            }
            catch (PostgresException e)
            {
                ModelState.AddModelError("CareerStart", e.MessageText);
                return View("Career/Create", model);
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Career successfully started.";
            return RedirectToAction("Pharmacies");
        }

        [HttpGet]
        [Route("[controller]/Career/Change")]
        public async Task<IActionResult> CareerChange()
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            Pharmacist pharmacist = HttpContext.Session.GetObjectFromJson<Pharmacist>("UserRole");
            List<Pharmacy> pharmacies = await pharmacist.GetPharmaciesAsync();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (Pharmacy pharmacy in pharmacies)
            {
                listItems.Add(new SelectListItem
                {
                    Value = pharmacy.Id.ToString(),
                    Text = $"{pharmacy.Name} ({pharmacy.Street} {pharmacy.Number}, {pharmacy.City})"
                });
            }
            ViewData["Pharmacies"] = listItems;
            return View("Career/Create");
        }

        [HttpPost]
        [Route("[controller]/Career/Change")]
        public async Task<IActionResult> CareerChange(PharmacistCareer model)
        {
            User user = HttpContext.Session.GetObjectFromJson<User>("User");
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else if (user.Role != Role.Pharmacist)
            {
                return RedirectToAction("Index", "Home");
            }

            Pharmacist pharmacist = HttpContext.Session.GetObjectFromJson<Pharmacist>("UserRole");
            try
            {
                await pharmacist.CareerEntryAsync(model);
            }
            catch (PostgresException e)
            {
                ModelState.AddModelError("CareerStart", e.MessageText);
                return View("Career/Create", model);
            }

            TempData["AlertType"] = "success";
            TempData["AlertMessage"] = $"Career successfully changed.";
            return RedirectToAction("Pharmacies");
        }

        #endregion Career
    }
}
