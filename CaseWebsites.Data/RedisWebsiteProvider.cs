using System;
using StackExchange.Redis;

namespace CaseWebsites.Data
{
    public class RedisWebsiteProvider : IWebsiteProvider
    {


        private  readonly IDatabase _database;
        public RedisWebsiteProvider()
        {
            var connection = RedisConnectionFactory.GetConnection();

            _database = connection.GetDatabase();
        }


        public dynamic GetWebsiteById(string id)
        {

            var x = _database.StringGet(id);
            return x;
        }
    }
}
