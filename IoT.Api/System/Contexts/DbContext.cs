using IoT.Api.System.Models;
using MongoDB.Driver;

namespace IoT.Api.System.Contexts
{
    public class DbContext
    {
        private readonly IMongoDatabase _database;

        //Connect to db
        public DbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("iot");
        }
        //Get collection
        public IMongoCollection<DataDocument> UserNotes => _database.GetCollection<DataDocument>("iot");
    }
}