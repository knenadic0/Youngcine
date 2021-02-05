using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class Pharmacist
    {
        public Guid Id { get; set; }
        public DateTime? ActiveSince { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public async Task<List<PharmacistCareer>> GetPharmacistCareersAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"PharmacistCareer\" pc join \"Pharmacy\" p on pc.\"PharmacyId\"=p.\"Id\" where pc.\"PharmacistId\"='{Id}' order by pc.\"DateFrom\" desc;";
            NpgsqlDataReader reader = await Helper.QueryAsync(query, true);
            List<PharmacistCareer> pharmacistCareers = new List<PharmacistCareer>();
            while (await reader.ReadAsync())
            {
                PharmacistCareer career = new PharmacistCareer()
                {
                    Id = Guid.Parse(reader[0].ToString()),
                    PharmacistId = this.Id,
                    Pharmacist = this,
                    DateFrom = DateTime.Parse(reader["DateFrom"].ToString()),
                    PharmacyId = Guid.Parse(reader["PharmacyId"].ToString()),
                };
                if (reader["DateTo"] != DBNull.Value)
                {
                    string dateTo = reader["DateTo"].ToString();
                    career.DateTo = DateTime.Parse(dateTo);
                }
                Pharmacy pharmacy = new Pharmacy()
                {
                    Id = Guid.Parse(reader[5].ToString()),
                    Name = reader["Name"].ToString(),
                };
                string[] address = reader["Location"].ToString().Replace("(", string.Empty).Replace(")", string.Empty).Trim().Split(',');
                pharmacy.Street = address[0].Replace("\"", string.Empty);
                pharmacy.Number = int.Parse(address[1]);
                pharmacy.City = address[2].Replace("\"", string.Empty);
                career.Pharmacy = pharmacy;
                pharmacistCareers.Add(career);
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return pharmacistCareers;
        }

        public async Task CareerEntryAsync(PharmacistCareer model)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"insert into \"PharmacistCareer\" values(default, '{Id}', '{model.PharmacyId}', default, default)";
            await Helper.NonQueryAsync(query);

            await Helper.CloseLocalConnectionAsync();
        }

        public async Task<List<Pharmacy>> GetPharmaciesAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"PharmacistCareer\" pc join \"Pharmacy\" p on pc.\"PharmacyId\"=p.\"Id\" where pc.\"PharmacistId\"='{Id}' and pc.\"DateTo\" is null;";
            NpgsqlDataReader reader = await Helper.QueryAsync(query, true);
            List<PharmacistCareer> pharmacistCareers = new List<PharmacistCareer>();
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                Guid pharmacyId = Guid.Parse(reader["PharmacyId"].ToString());
                await reader.CloseAsync();
                await Helper.CloseLocalConnectionAsync();
                List<Pharmacy> result = await Pharmacy.GetPharmaciesAsync();
                return result.Where(p => p.Id != pharmacyId).ToList();
            }
            else
            {
                await reader.CloseAsync();
                await Helper.CloseLocalConnectionAsync();
                return await Pharmacy.GetPharmaciesAsync();
            }
        }
    }
}
