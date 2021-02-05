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

    }
}
