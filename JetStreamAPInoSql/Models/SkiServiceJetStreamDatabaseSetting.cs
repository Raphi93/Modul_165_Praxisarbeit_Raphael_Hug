namespace JetStreamAPInoSql.Models
{
    public class SkiServiceJetStreamDatabaseSetting
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ServicesCollectionName { get; set; } = null!;

        public string UserCollectionName { get; set; } = null!;
    }
}
