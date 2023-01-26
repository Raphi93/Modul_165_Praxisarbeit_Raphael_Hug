using JetStreamAPInoSql.Models;

namespace JetStreamAPInoSql.Service
{
    public interface IJwtService
    {
        string CreateToken(string username);
        List<User> Login();
    }
}
