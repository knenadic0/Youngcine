using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public MedicineType Type { get; set; }
        public int Quantity { get; set; }
        public bool WithoutPrescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public static async Task<List<Medicine>> GetMedicinesAsync(bool prescription = false)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Medicine\"";
            if (prescription)
            {
                query += " where \"WithoutPrescription\" is true";
            }
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            List<Medicine> medicines = new List<Medicine>();
            while (await reader.ReadAsync())
            {
                medicines.Add(new Medicine()
                {
                    Id = (Guid)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Price = (float)reader["Price"],
                    Type = (MedicineType)Enum.Parse(typeof(MedicineType), reader["Type"].ToString()),
                    Quantity = (int)reader["Quantity"],
                    WithoutPrescription = (bool)reader["WithoutPrescription"],
                    Description = reader["Description"].ToString()
                });
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return medicines;
        }

        public static async Task<Medicine> GetMedicineAsync(string id)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Medicine\" where \"Id\"='{id}'";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            Medicine medicine = null;

            if (await reader.ReadAsync())
            {
                medicine = new Medicine()
                {
                    Id = (Guid)reader["Id"],
                    Name = reader["Name"].ToString(),
                    Price = (float)reader["Price"],
                    Type = (MedicineType)Enum.Parse(typeof(MedicineType), reader["Type"].ToString()),
                    Quantity = (int)reader["Quantity"],
                    WithoutPrescription = (bool)reader["WithoutPrescription"],
                    Description = reader["Description"].ToString()
                };
            }

            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return medicine;
        }

        public async Task CreateMedicineAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"insert into \"Medicine\" values(default, '{Name}', {Price}, '{Type}', {Quantity}, " +
                $"'{WithoutPrescription}', '{Description}')";
            await Helper.NonQueryAsync(query);

            await Helper.CloseLocalConnectionAsync();
        }

        public static async Task EditMedicineAsync(Medicine model)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"update \"Medicine\" set \"Name\"='{model.Name}', \"Price\"={model.Price}, \"Type\"='{model.Type}', " +
                $"\"Quantity\"={model.Quantity}, \"WithoutPrescription\"='{model.WithoutPrescription}', \"Description\"='{model.Description}' " +
                $"where \"Id\"='{model.Id}'";
            await Helper.NonQueryAsync(query);

            await Helper.CloseLocalConnectionAsync();
        }
    }
}
