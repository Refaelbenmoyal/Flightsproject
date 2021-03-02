using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    class AdministratorDAO
    {
        private static void a_sp_insert_administrator(string conn_string, string country_name)
        {
            using var conn = new NpgsqlConnection(conn_string);
            {
                conn.Open();
                string sp_name = "a_sp_insert_administrator";
                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue(sp_name, country_name);



            }
        }
    }
}
