using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string SN { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public static async Task<Patient> GetPatientAsync(string id)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Patient\" p join \"User\" u on p.\"UserId\"=u.\"Id\" where p.\"Id\"='{id}';";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            Patient patient = null;
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                patient = new Patient()
                {
                    Id = Guid.Parse(reader[0].ToString()),
                    UserId = Guid.Parse(reader["UserId"].ToString()),
                    SN = reader["SN"].ToString()
                };
                User patientUser = new User()
                {
                    Id = patient.UserId,
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    DOB = (DateTime)reader["DOB"],
                    Sex = (Sex)Enum.Parse(typeof(Sex), reader["Sex"].ToString())
                };
                patient.User = patientUser;
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return patient;
        }

        public static async Task<List<Patient>> GetPatientsAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Patient\" p join \"User\" u on p.\"UserId\"=u.\"Id\"";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            List<Patient> patients = new List<Patient>();
            while (await reader.ReadAsync())
            {
                Patient patient = new Patient()
                {
                    Id = Guid.Parse(reader[0].ToString()),
                    UserId = Guid.Parse(reader["UserId"].ToString()),
                    SN = reader["SN"].ToString()
                };
                User patientUser = new User()
                {
                    Id = patient.UserId,
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    DOB = (DateTime)reader["DOB"],
                    Sex = (Sex)Enum.Parse(typeof(Sex), reader["Sex"].ToString())
                };
                patient.User = patientUser;
                patients.Add(patient);
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return patients;
        }

        public async Task<List<PatientDoctor>> GetPatientDoctorsAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"PatientDoctor\" pd join \"Doctor\" d on pd.\"DoctorId\"=d.\"Id\" join \"User\" u on d.\"UserId\"=u.\"Id\" " +
                $"where pd.\"PatientId\"='{Id}' order by pd.\"DateFrom\" desc;";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            List<PatientDoctor> patientDoctors = new List<PatientDoctor>();
            while (await reader.ReadAsync())
            {
                PatientDoctor patientDoctor = new PatientDoctor()
                {
                    Id = Guid.Parse(reader[0].ToString()),
                    PatientId = this.Id,
                    Patient = this,
                    DateFrom = DateTime.Parse(reader["DateFrom"].ToString()),
                    DoctorId = Guid.Parse(reader["DoctorId"].ToString()),
                };
                if (reader["DateTo"] != DBNull.Value)
                {
                    string dateTo = reader["DateTo"].ToString();
                    patientDoctor.DateTo = DateTime.Parse(dateTo);
                }
                Doctor doctor = new Doctor()
                {
                    Id = Guid.Parse(reader[5].ToString()),
                    UserId = Guid.Parse(reader["UserId"].ToString())
                };
                if (reader["ActiveSince"] != DBNull.Value)
                {
                    string activeSine = reader["ActiveSince"].ToString();
                    doctor.ActiveSince = DateTime.Parse(activeSine);
                }
                User doctorUser = new User()
                {
                    Id = doctor.UserId,
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                doctor.User = doctorUser;
                patientDoctor.Doctor = doctor;
                patientDoctors.Add(patientDoctor);
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return patientDoctors;
        }

        public async Task DoctorEntryAsync(PatientDoctor model)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"insert into \"PatientDoctor\" values(default, '{Id}', '{model.DoctorId}', default, default)";
            await Helper.NonQueryAsync(query);

            await Helper.CloseLocalConnectionAsync();
        }

        public async Task<List<Doctor>> GetPharmaciesAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"PatientDoctor\" pd join \"Doctor\" d on pd.\"DoctorId\"=d.\"Id\" where pd.\"PatientId\"='{Id}' and pd.\"DateTo\" is null;";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            List<PatientDoctor> patientDoctors = new List<PatientDoctor>();
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                Guid doctorId = Guid.Parse(reader["DoctorId"].ToString());
                await reader.CloseAsync();
                await Helper.CloseLocalConnectionAsync();
                List<Doctor> result = await Doctor.GetDoctorsAsync();
                return result.Where(p => p.Id != doctorId).ToList();
            }
            else
            {
                await reader.CloseAsync();
                await Helper.CloseLocalConnectionAsync();
                return await Doctor.GetDoctorsAsync();
            }
        }

        public async Task<List<PatientMedicine>> GetPatientWithoutPrescriptionMedicinesAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"PatientMedicine\" pm join \"Medicine\" m on pm.\"MedicineId\"=m.\"Id\" join \"Pharmacist\" p on p.\"Id\"=pm.\"PharmacistId\" " +
                $"join \"User\" u on p.\"UserId\"=u.\"Id\" where pm.\"PatientId\"='{Id}' order by pm.\"DateFrom\" desc;";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            List<PatientMedicine> patientMedicines = new List<PatientMedicine>();
            while (await reader.ReadAsync())
            {
                PatientMedicine patientMedicine = new PatientMedicine
                {
                    Id = Guid.Parse(reader[0].ToString()),
                    PatientId = this.Id,
                    Patient = this,
                    DateFrom = DateTime.Parse(reader["DateFrom"].ToString()),
                    MedicineId = Guid.Parse(reader["MedicineId"].ToString()),
                    PharmacistId = Guid.Parse(reader["PharmacistId"].ToString())
                };
                if (reader["DateTo"] != DBNull.Value)
                {
                    string dateTo = reader["DateTo"].ToString();
                    patientMedicine.DateTo = DateTime.Parse(dateTo);
                }
                Medicine medicine = new Medicine()
                {
                    Id = patientMedicine.MedicineId,
                    Name = reader["Name"].ToString(),
                    Price = (float)reader["Price"],
                    Type = (MedicineType)Enum.Parse(typeof(MedicineType), reader["Type"].ToString()),
                    Quantity = (int)reader["Quantity"],
                    WithoutPrescription = (bool)reader["WithoutPrescription"],
                    Description = reader["Description"].ToString()
                };
                Pharmacist pharmacist = new Pharmacist()
                {
                    Id = Guid.Parse(reader[5].ToString()),
                    UserId = Guid.Parse(reader["UserId"].ToString())
                };
                if (reader["ActiveSince"] != DBNull.Value)
                {
                    string activeSine = reader["ActiveSince"].ToString();
                    pharmacist.ActiveSince = DateTime.Parse(activeSine);
                }
                User pharmacistUser = new User()
                {
                    Id = pharmacist.UserId,
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                pharmacist.User = pharmacistUser;
                patientMedicine.Pharmacist = pharmacist;
                patientMedicine.Medicine = medicine;
                patientMedicines.Add(patientMedicine);
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return patientMedicines;
        }

        public async Task<List<Prescription>> GetPatientPrescriptionMedicinesAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Prescription\" pr join \"Medicine\" m on pr.\"MedicineId\"=m.\"Id\" join \"Visit\" v on pr.\"VisitId\"=v.\"Id\" " +
                $"join \"PatientDoctor\" pd on v.\"PatientDoctorId\"=pd.\"Id\" where pd.\"PatientId\"='{Id}' order by v.\"DateFrom\" desc, m.\"Name\";";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            List<Prescription> prescriptions = new List<Prescription>();
            while (await reader.ReadAsync())
            {
                Prescription prescription = new Prescription()
                {
                    Id = Guid.Parse(reader[0].ToString()),
                    MedicineId = Guid.Parse(reader["MedicineId"].ToString()),
                    VisitId = Guid.Parse(reader["VisitId"].ToString()),
                };
                if (reader[3] != DBNull.Value)
                {
                    string dateFrom = reader[3].ToString();
                    prescription.DateFrom = DateTime.Parse(dateFrom);
                }
                if (reader[4] != DBNull.Value)
                {
                    string dateTo = reader[4].ToString();
                    prescription.DateTo = DateTime.Parse(dateTo);
                }
                Medicine medicine = new Medicine()
                {
                    Id = prescription.MedicineId,
                    Name = reader["Name"].ToString(),
                    Price = (float)reader["Price"],
                    Type = (MedicineType)Enum.Parse(typeof(MedicineType), reader["Type"].ToString()),
                    Quantity = (int)reader["Quantity"],
                    WithoutPrescription = (bool)reader["WithoutPrescription"],
                    Description = reader["Description"].ToString()
                };
                Visit visit = new Visit()
                {
                    Id = prescription.VisitId,
                    Diagnosis = reader["Diagnosis"].ToString()
                };
                prescription.Visit = visit;
                prescription.Medicine = medicine;
                prescriptions.Add(prescription);
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return prescriptions;
        }

        public static async Task<List<Visit>> GetPacientVisitsAsync(string id)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Visit\" v join \"PatientDoctor\" pd on v.\"PatientDoctorId\"=pd.\"Id\" join \"Doctor\" d on pd.\"DoctorId\"=d.\"Id\" " +
                $"join \"User\" u on d.\"UserId\"=u.\"Id\" where pd.\"PatientId\"='{id}' order by v.\"DateFrom\" desc;";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            List<Visit> visits = new List<Visit>();
            while (await reader.ReadAsync())
            {
                Visit visit = new Visit()
                {
                    Id = Guid.Parse(reader[0].ToString()),
                    Diagnosis = reader["Diagnosis"].ToString(),
                    Sympthoms = reader["Sympthoms"].ToString(),
                    DateFrom = (DateTime)reader[1],
                    PatientDoctorId = Guid.Parse(reader["PatientDoctorId"].ToString())
                };
                if (reader[3] != DBNull.Value)
                {
                    string dateTo = reader[3].ToString();
                    visit.DateTo = DateTime.Parse(dateTo);
                }
                PatientDoctor patientDoctor = new PatientDoctor()
                {
                    PatientId = Guid.Parse(id),
                    DoctorId = Guid.Parse(reader["DoctorId"].ToString()),
                };
                User doctorUser = new User()
                {
                    Id = Guid.Parse(reader[14].ToString()),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                Doctor doctor = new Doctor()
                {
                    Id = Guid.Parse(reader[11].ToString()),
                    UserId = doctorUser.Id,
                    User = doctorUser
                };
                patientDoctor.Doctor = doctor;
                visit.PatientDoctor = patientDoctor;

                visits.Add(visit);
            }
            await reader.CloseAsync();

            foreach (Visit visit in visits)
            {
                query = $"select * from \"Prescription\" p join \"Medicine\" m on p.\"MedicineId\"=m.\"Id\" where p.\"VisitId\"='{visit.Id}'";
                NpgsqlDataReader prescriptionReader = await Helper.QueryAsync(query);
                List<Prescription> prescriptions = new List<Prescription>();
                while (await prescriptionReader.ReadAsync())
                {
                    Medicine medicine = new Medicine()
                    {
                        Id = (Guid)prescriptionReader[5],
                        Name = prescriptionReader["Name"].ToString(),
                        Price = (float)prescriptionReader["Price"],
                        Type = (MedicineType)Enum.Parse(typeof(MedicineType), prescriptionReader["Type"].ToString()),
                        Quantity = (int)prescriptionReader["Quantity"],
                        WithoutPrescription = (bool)prescriptionReader["WithoutPrescription"],
                        Description = prescriptionReader["Description"].ToString()
                    };
                    Prescription prescription = new Prescription()
                    {
                        Id = (Guid)prescriptionReader[0],
                        VisitId = visit.Id,
                        MedicineId = (Guid)prescriptionReader["MedicineId"],
                        Medicine = medicine,
                    };
                    if (prescriptionReader["DateFrom"] != DBNull.Value)
                    {
                        string dateFrom = prescriptionReader["DateFrom"].ToString();
                        prescription.DateFrom = DateTime.Parse(dateFrom);
                    }
                    if (prescriptionReader["DateTo"] != DBNull.Value)
                    {
                        string dateTo = prescriptionReader["DateTo"].ToString();
                        prescription.DateTo = DateTime.Parse(dateTo);
                    }
                    prescriptions.Add(prescription);
                }
                await prescriptionReader.CloseAsync();
                visit.Prescriptions = prescriptions;
            }
            await Helper.CloseLocalConnectionAsync();

            return visits;
        }
    }
}
