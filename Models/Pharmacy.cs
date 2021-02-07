using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class Pharmacy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }

        public static async Task<List<Pharmacy>> GetPharmaciesAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Pharmacy\"";
            NpgsqlDataReader reader = await Helper.QueryAsync(query, true);
            List<Pharmacy> pharmacies = new List<Pharmacy>();
            while (await reader.ReadAsync())
            {
                Pharmacy pharmacy = new Pharmacy()
                {
                    Id = Guid.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                };
                string[] address = reader["Location"].ToString().Replace("(", string.Empty).Replace(")", string.Empty).Trim().Split(',');
                pharmacy.Street = address[0].Replace("\"", string.Empty);
                pharmacy.Number = int.Parse(address[1]);
                pharmacy.City = address[2].Replace("\"", string.Empty);
                pharmacies.Add(pharmacy);
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return pharmacies;
        }
    }
}
