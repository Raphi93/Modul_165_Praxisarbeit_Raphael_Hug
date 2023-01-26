using Microsoft.Extensions.Options;
using MongoDB.Driver;
using JetStreamServiceNoSqlAPI.Models;
using MongoDB.Bson.IO;

namespace JetStreamServiceNoSqlAPI.Service 
{
    public class RegistrationServicesNoSql : IRegistrationServices
    {
        private readonly IMongoCollection<Registration> _regi;
        private readonly ILogger<RegistrationServicesNoSql> _logger;

        public RegistrationServicesNoSql(IOptions<SkiServiceJetStreamDatabaseSetting> jetStreamDatabaseSettings, ILogger<RegistrationServicesNoSql> logger)
        {
            var mongoClient = new MongoClient(
            jetStreamDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                jetStreamDatabaseSettings.Value.DatabaseName);

            _regi = mongoDatabase.GetCollection<Registration>(
                jetStreamDatabaseSettings.Value.ServicesCollectionName);
            _logger = logger;
        }

        public List<Registration> GetAll()
        {
            try
            {
                return _regi.Find(x => x.Status != "Gelöscht").Sort(Builders<Registration>.Sort.Ascending(x => x.Priority)).ToList();
            }
            catch (MongoException ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return null;
            }
        }

        public Registration Get(string id)
        {
            try
            {
                return _regi.Find(x => x._id == id).FirstOrDefault();
            }
            catch (MongoException ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return null;
            }
        }

        public void Add(Registration reg)
        {
            try
            {
                _regi.InsertOne(reg);
            }
            catch (MongoException ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return;
            }
        }

        public void Update(string id, Registration reg)
        {
            try
            {
                _regi.ReplaceOne(x => x._id == id, reg);
            }
            catch (MongoException ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return;
            }
        }
    }
}
