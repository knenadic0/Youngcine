using Microsoft.AspNetCore.Http;
using Npgsql;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [DisplayName("Date of birth")]
        [Required(ErrorMessage = "Please enter date of birth")]
        public DateTime DOB { get; set; }
        public Sex Sex { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public uint Picture { get; set; }
        [DisplayName("Picture file")]
        public IFormFile PictureFile { get; set; }
        public Role Role { get; set; } = Role.Patient;
        [DisplayName("Active since")]
        public DateTime? ActiveSince { get; set; }
        [DisplayName("Social number")]
        public string SN { get; set; }

        public static async Task RegisterUserAsync(User model)
        {
            await Helper.OpenLocalConnectionAsync();

            Guid uuid = Guid.NewGuid();
            string query = $"insert into \"User\" values('{uuid}', '{model.FirstName}', '{model.LastName}', '{model.Email}', '{SHA256(model.Password)}', " +
                $"'{model.DOB.ToDatabaseDate()}', '{model.Sex}', ROW('{model.Street}', '{model.Number}', '{model.City}'));";
            await Helper.NonQueryAsync(query);

            switch (model.Role)
            {
                case Role.Patient:
                    query = $"insert into \"Patient\" values(default, '{uuid}', '{model.SN}');";
                    break;
                case Role.Pharmacist:
                    query = $"insert into \"Pharmacist\" values (default, '{uuid}', '{(model.ActiveSince.HasValue ? model.ActiveSince.Value.ToDatabaseDate() : string.Empty)}');";
                    break;
                case Role.Doctor:
                    query = $"insert into \"Doctor\" values (default, '{uuid}', '{(model.ActiveSince.HasValue ? model.ActiveSince.Value.ToDatabaseDate() : string.Empty)}');";
                    break;
            }
            try
            {
                await Helper.NonQueryAsync(query);
            }
            catch (PostgresException e)
            {
                query = $"delete from \"User\" where \"Id\"='{uuid}'";
                await Helper.NonQueryAsync(query);
                throw e;
            }

            await Helper.CloseLocalConnectionAsync();
        }

        public async Task<Tuple<int, object>> LoginUserAsync()
        {
            await Helper.OpenLocalConnectionAsync();
            string query;

            if (Id == Guid.Empty)
            {
                query = $"select * from \"User\" where \"Email\"='{Email}' and \"Password\"='{SHA256(Password)}'";
            }
            else
            {
                query = $"select * from \"User\" where \"Id\"='{Id}'";
            }

            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            int role = -1;
            object roleObject = null;
            await reader.ReadAsync();
            Id = (Guid)reader["Id"];
            FirstName = reader["FirstName"].ToString();
            LastName = reader["LastName"].ToString();
            if (reader["Picture"] != DBNull.Value)
            {
                Picture = (uint)reader["Picture"];
            }
            await reader.CloseAsync();

            query = $"select * from \"Patient\" where \"UserId\"='{Id}'";
            reader = await Helper.QueryAsync(query);
            if (reader.HasRows)
            {
                role = 1;
                Role = Role.Patient;

                await reader.ReadAsync();
                Patient patient = new Patient()
                {
                    Id = (Guid)reader["Id"],
                    SN = reader["SN"].ToString()
                };
                roleObject = patient;
                await reader.CloseAsync();
            }
            await reader.CloseAsync();

            query = $"select * from \"Pharmacist\" where \"UserId\"='{Id}'";
            reader = await Helper.QueryAsync(query);
            if (reader.HasRows)
            {
                role = 2;
                Role = Role.Pharmacist;

                await reader.ReadAsync();
                Pharmacist pharmacist = new Pharmacist()
                {
                    Id = (Guid)reader["Id"],
                    ActiveSince = (DateTime)reader["ActiveSince"]
                };
                roleObject = pharmacist;
                await reader.CloseAsync();
            }
            await reader.CloseAsync();

            query = $"select * from \"Doctor\" where \"UserId\"='{Id}'";
            reader = await Helper.QueryAsync(query);
            if (reader.HasRows)
            {
                role = 3;
                Role = Role.Doctor;

                await reader.ReadAsync();
                Doctor doctor = new Doctor()
                {
                    Id = (Guid)reader["Id"],
                    ActiveSince = (DateTime)reader["ActiveSince"]
                };
                roleObject = doctor;
                await reader.CloseAsync();
            }
            await reader.CloseAsync();

            await Helper.CloseLocalConnectionAsync();
            return await Task.FromResult(Tuple.Create(role, roleObject));
        }

        public async Task RemovePictureAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            Picture = 0;
            string query = $"update \"User\" set \"Picture\"=null where \"Id\"='{Id}'";
            await Helper.NonQueryAsync(query);
            query = $"select lo_unlink(\"Picture\") from \"User\" where \"Id\"='{Id}'";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            await reader.ReadAsync();
            await reader.CloseAsync();

            await Helper.CloseLocalConnectionAsync();
        }

        private static string SHA256(string randomString)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
