using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public DateTime? ActiveSince { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public static async Task<List<Doctor>> GetDoctorsAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Doctor\" d join \"User\" u on d.\"UserId\"=u.\"Id\"";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            List<Doctor> doctors = new List<Doctor>();
            while (await reader.ReadAsync())
            {
                Doctor doctor = new Doctor()
                {
                    Id = Guid.Parse(reader["Id"].ToString()),
                    UserId = Guid.Parse(reader["UserId"].ToString()),
                };
                User doctorUser = new User()
                {
                    Id = doctor.UserId,
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                doctor.User = doctorUser;
                doctors.Add(doctor);
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return doctors;
        }

        public async Task<List<Patient>> GetPatientsAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"PatientDoctor\" pd join \"Patient\" p on pd.\"PatientId\"=p.\"Id\" join \"User\" u on p.\"UserId\"=u.\"Id\" " +
                $"where pd.\"DoctorId\"='{Id}' and pd.\"DateTo\" is null order by pd.\"DateFrom\" desc;";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            List<Patient> patients= new List<Patient>();
            while (await reader.ReadAsync())
            {
                Patient patient = new Patient()
                {
                    Id = Guid.Parse(reader[5].ToString()),
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

        public async Task<List<Visit>> GetVisitsAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Visit\" v join \"PatientDoctor\" pd on v.\"PatientDoctorId\"=pd.\"Id\" join \"Patient\" p on pd.\"PatientId\"=p.\"Id\" " +
                $"join \"User\" u on p.\"UserId\"=u.\"Id\" where pd.\"DoctorId\"='{Id}' order by v.\"DateFrom\" desc;";
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
                    PatientId = Guid.Parse(reader["PatientId"].ToString()),
                    DoctorId = Id,
                };
                User patientUser = new User()
                {
                    Id = Guid.Parse(reader[14].ToString()),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                Patient patient = new Patient()
                {
                    Id = Guid.Parse(reader[11].ToString()),
                    UserId = patientUser.Id,
                    User = patientUser
                };
                patientDoctor.Patient = patient;
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
