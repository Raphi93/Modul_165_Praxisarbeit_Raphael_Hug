using JetStreamAPInoSql.Models;

namespace JetStreamAPInoSql.Service
{
    public interface IRegistrationServices
    {
        public List<Registration> GetAll();
        public Registration Get(string id);
        public void Add(Registration reg);
        public void Update(string id, Registration reg);
    }
}
