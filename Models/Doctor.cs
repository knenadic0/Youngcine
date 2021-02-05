using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
