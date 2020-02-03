using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using StackExchange.Redis;

namespace CaseWebsites.Data
{
    public class RedisConnectionFactory
    {

        private static readonly Lazy<ConnectionMultiplexer> Connection;

        static RedisConnectionFactory()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var redisConnectionString = configuration.GetSection("RedisSettings:ConnectionString").Value;

                        
            var options = ConfigurationOptions.Parse(redisConnectionString);

            Connection = new Lazy<ConnectionMultiplexer>(()=> ConnectionMultiplexer.Connect(options));
        }


        public static ConnectionMultiplexer GetConnection() => Connection.Value;
    }
}
