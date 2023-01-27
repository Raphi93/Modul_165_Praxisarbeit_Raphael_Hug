using JetStreamAPInoSql.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace JetStreamAPInoSql.Service
{
    /// <summary>
    /// Registrationen Logik
    /// </summary>
    public class RegistrationServicesNoSql : IRegistrationServices
    {

        #region Prop und Kunstrucktor
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
        #endregion

        #region GetAll und Gets
        /// <summary>
        /// Gint alle Daten bei Registration  aus
        /// </summary>
        /// <exception cref="MongoException"></exception>
        /// <returns>Liste aler Regitrationen</returns>
        public List<Registration> GetAll()
        {
            try
            {
                var get = _regi.Find(x => x.Status != "Gelöscht").Sort(Builders<Registration>.Sort.Ascending(x => x.Status)).ToList();
                return get;
            }
            catch (MongoException ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return null;
            }
        }
        /// <summary>
        /// Gibt nur den bestimte Daten aus per id
        /// </summary>
        /// <exception cref="MongoException"></exception>
        /// <returns>Liste id Regitrationen</returns>
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
        #endregion

        #region Add
        /// <summary>
        /// Ein Kunde Hinzufügen
        /// </summary>
        /// <exception cref="MongoException"></exception>
        /// <param name="reg"></param>
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
        #endregion

        #region Update
        /// <summary>
        /// Ein Kunde Updaten
        /// </summary>
        /// <exception cref="MongoException"></exception>
        /// <param name="id"></param>
        /// <param name="reg"></param>
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
        #endregion

    }
}
