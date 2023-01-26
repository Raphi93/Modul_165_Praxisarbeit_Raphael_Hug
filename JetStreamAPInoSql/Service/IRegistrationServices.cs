using JetStreamAPInoSql.Models;

namespace JetStreamAPInoSql.Service
{
    /// <summary>
    /// Interface für Registration
    /// </summary>
    public interface IRegistrationServices
    {
        public List<Registration> GetAll();
        public Registration Get(string id);
        public void Add(Registration reg);
        public void Update(string id, Registration reg);
    }
}
