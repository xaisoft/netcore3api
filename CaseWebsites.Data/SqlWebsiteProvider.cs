using System;
using System.Data.SqlClient;
using Dapper;

namespace CaseWebsites.Data
{
    public class SqlWebsiteProvider : IWebsiteProvider
    {
        
        private readonly string _connectionString;

        public SqlWebsiteProvider(string connectionString)
        {
            _connectionString = connectionString;
        }
        public dynamic GetWebsiteById(string id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
               var person = connection.Query("SELECT TOP 1 * FROM PERSON");
               return person;
            }
        }
    }
}
