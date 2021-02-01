using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Mladacina.Models
{
    public class User
    {
        private NpgsqlConnection connection;

        public User()
        {
            connection = new NpgsqlConnection(Helper.connectionString);
        }

        private bool OpenLocalConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
