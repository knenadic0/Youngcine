using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class PatientMedicine
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public Guid MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public Guid PharmacistId { get; set; }
        public Pharmacist Pharmacist { get; set; }

        public static async Task<PatientMedicine> GetPatientMedicineAsync(string id)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"PatientMedicine\" pm join \"Medicine\" m on pm.\"MedicineId\"=m.\"Id\" join \"Pharmacist\" p on p.\"Id\"=pm.\"PharmacistId\" " +
                $"join \"User\" u on p.\"UserId\"=u.\"Id\" where pm.\"Id\"='{id}' order by pm.\"DateFrom\" desc;";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            PatientMedicine patientMedicine = null;
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                patientMedicine = new PatientMedicine
                {
                    Id = Guid.Parse(reader[0].ToString()),
                    PatientId = Guid.Parse(reader["PatientId"].ToString()),
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
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return patientMedicine;
        }

        public async Task FinishMedicineAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"update \"PatientMedicine\" set \"DateTo\"=now() where \"Id\"='{Id}'";
            await Helper.NonQueryAsync(query);

            await Helper.CloseLocalConnectionAsync();
        }
    }
}
