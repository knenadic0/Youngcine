using Microsoft.AspNetCore.Http;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class Image
    {
        public IFormFile File { get; set; }
        public User User { get; set; }

        public async Task ChangePictureAsync(string path)
        {
            await Helper.OpenLocalConnectionAsync();

            string query = $"update \"User\" set \"Picture\"=lo_import('{path}') where \"Id\"='{User.Id}'";
            await Helper.NonQueryAsync(query);
            query = $"select * from \"User\" where \"Id\"='{User.Id}'";
            NpgsqlDataReader reader = await Helper.QueryAsync(query);
            if (await reader.ReadAsync())
            {
                User.Picture = (uint)reader["Picture"];
            }
            await reader.CloseAsync();
            await Helper.CloseLocalConnectionAsync();
        }
    }
}
