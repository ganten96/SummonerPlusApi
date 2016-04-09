using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SummonerPlusApi.DB
{
    public class DynamicDb 
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["SP"].ConnectionString;
        public IEnumerable<T> RunProcedure<T>(string procedure, object parameters = null)
        { 
            using (var connection = new SqlConnection(connectionString))
            {
                IEnumerable<T> data = connection.Query<T>(procedure, parameters, null, true, null, CommandType.StoredProcedure);
                return data;
            }
        }

        public bool ExecuteProcedure(string procedure, object parameters = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var data = connection.Query(procedure, parameters, null, true, null, CommandType.StoredProcedure);
                return data.Count() > 0;
            }
        }
    }
}