using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class Prescription
    {
        public Guid Id { get; set; }
        public Guid VisitId { get; set; }
        public Visit Visit { get; set; }
        public Guid MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public static async Task<Prescription> GetPrescriptionAsync(string id)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Prescription\" pr join \"Medicine\" m on pr.\"MedicineId\"=m.\"Id\" join \"Visit\" v on pr.\"VisitId\"=v.\"Id\" " +
                $"join \"PatientDoctor\" pd on v.\"PatientDoctorId\"=pd.\"Id\" join \"Doctor\" d on pd.\"DoctorId\"=d.\"Id\" " +
                $"join \"User\" u on d.\"UserId\"=u.\"Id\" where pr.\"Id\"='{id}' order by v.\"DateFrom\" desc, m.\"Name\";";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            Prescription prescription = null;
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                prescription = new Prescription()
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
                    Diagnosis = reader["Diagnosis"].ToString(),
                    Sympthoms = reader["Sympthoms"].ToString()
                };
                User doctorUser = new User()
                {
                    Id = (Guid)reader[26],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };
                Doctor doctor = new Doctor()
                {
                    Id = (Guid)reader[23],
                    UserId = doctorUser.Id,
                    User = doctorUser
                };
                PatientDoctor patientDoctor = new PatientDoctor()
                {
                    Id = (Guid)reader[18],
                    DoctorId = doctor.Id,
                    Doctor = doctor
                };
                visit.PatientDoctor = patientDoctor;
                prescription.Visit = visit;
                prescription.Medicine = medicine;
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return prescription;
        }

        public async Task FinishPrescriptionAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"update \"Prescription\" set \"DateTo\"=now() where \"Id\"='{Id}'";
            await Helper.NonQueryAsync(query);

            await Helper.CloseLocalConnectionAsync();
        }
    }
}
