using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public static class Helper
    {
        public static string connectionString;

        private static NpgsqlConnection connection = null;

        public static async Task<bool> OpenLocalConnectionAsync()
        {
            try
            {
                if (connection == null)
                {
                    connection = new NpgsqlConnection(connectionString);
                }

                await connection.OpenAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task CloseLocalConnectionAsync()
        {
            try
            {
                await connection.CloseAsync();
            }
            catch (Exception)
            {

            }
        }

        public static async Task<int> NonQueryAsync(string nonQuery)
        {
            NpgsqlCommand command = new NpgsqlCommand(nonQuery, connection);
            return await command.ExecuteNonQueryAsync();
        }

        public static async Task<NpgsqlDataReader> QueryAsync(string Query, bool unknown = false)
        {
            NpgsqlCommand command = new NpgsqlCommand(Query, connection);
            command.AllResultTypesAreUnknown = unknown;
            return await command.ExecuteReaderAsync();
        }

        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static string ToNormalDate(this DateTime datetime)
        {
            return datetime.ToString("dd.MM.yyyy");
        }

        public static string ToDatabaseDate(this DateTime datetime)
        {
            return datetime.ToString("yyyy-MM-dd");
        }

        public static bool HasProperty(ExpandoObject obj, string propertyName)
        {
            return ((IDictionary<String, object>)obj).ContainsKey(propertyName);
        }
    }
}
