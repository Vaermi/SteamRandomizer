using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamRandomizer.src.Services
{
    public class MongoService
    {
        private readonly IMongoDatabase _database;

        public MongoService(string connectionUri, string databaseName)
        {
            var client = new MongoClient(connectionUri);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
   
}
