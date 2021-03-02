using Microsoft.Azure.Amqp.Framing;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightsProject
{
    public class CountryDAOPGSQL : ICountryDAO
    {
        void IBasicDB<Country>.Add(Country t)
        {
            throw new NotImplementedException();
        }

        Country IBasicDB<Country>.Get()
        {
            throw new NotImplementedException();
        }

        List<Country> IBasicDB<Country>.GetAll()
        {
            throw new NotImplementedException();
        }

        void IBasicDB<Country>.Remove(long id)
        {
            throw new NotImplementedException();
        }

        void IBasicDB<Country>.Update(Country t)
        {
            throw new NotImplementedException();
        }
        private static void a_sp_insert_country(string conn_string, string country_name)
        {
            using var conn = new NpgsqlConnection(conn_string);
            {
                conn.Open();
                string sp_name = "a_sp_insert_country";
                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue(sp_name, country_name);



            }
        }
    }
}



