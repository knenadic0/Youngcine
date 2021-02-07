using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class Visit
    {
        public Guid Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        [DataType(DataType.MultilineText)]
        public string Diagnosis { get; set; }
        [DataType(DataType.MultilineText)]
        public string Sympthoms { get; set; }
        public Guid PatientDoctorId { get; set; }
        public PatientDoctor PatientDoctor { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public string[] Medicines { get; set; }

        public static async Task<Visit> InitializeVisitAsync(string doctorId, string patientId)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"PatientDoctor\" where \"PatientId\"='{patientId}' and \"DoctorId\"='{doctorId}' and \"DateTo\" is null";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            Visit visit = null;
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                visit = new Visit()
                {
                    PatientDoctorId = (Guid)reader["Id"]
                };
                PatientDoctor patientDoctor = new PatientDoctor()
                {
                    PatientId = Guid.Parse(patientId),
                    DoctorId = Guid.Parse(doctorId)
                };
                visit.PatientDoctor = patientDoctor;
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return visit;
        }

        public async Task CreateVisitAsync()
        {
            await Helper.OpenLocalConnectionAsync();

            Guid id = Guid.NewGuid();
            string query = $"insert into \"Visit\" values('{id}', default, '{Diagnosis}', default, '{PatientDoctorId}', '{Sympthoms}')";
            await Helper.NonQueryAsync(query);

            if (Medicines != null && Medicines.Length > 0)
            {
                query = $"insert into \"Prescription\" values";
                foreach (string medicine in Medicines)
                {
                    query += $"(default, '{id}', '{medicine}', default, default),";
                }
                query = query.Substring(0, query.Length - 1);
                await Helper.NonQueryAsync(query);
            }

            await Helper.CloseLocalConnectionAsync();
        }

        public static async Task FinishDiagnoseAsync(string id)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"update \"Visit\" set \"DateTo\"=now() where \"Id\"='{id}'";
            await Helper.NonQueryAsync(query);

            await Helper.CloseLocalConnectionAsync();
        }

        public static async Task<string> GetPatientIdAsync(string id)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"select * from \"Visit\" v join \"PatientDoctor\" pd on v.\"PatientDoctorId\"=pd.\"Id\" where v.\"Id\"='{id}'";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            string patientId = null;
            if (reader.HasRows)
            {
                await reader.ReadAsync();
                patientId = reader["PatientId"].ToString();
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();

            return patientId;
        }
    }
}
