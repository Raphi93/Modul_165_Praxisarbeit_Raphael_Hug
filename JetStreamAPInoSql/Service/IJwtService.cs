using JetStreamAPInoSql.Models;

namespace JetStreamAPInoSql.Service
{
    /// <summary>
    /// Interface für JWT Token
    /// </summary>
    public interface IJwtService
    {
        string CreateToken(string username);
        List<User> Login();
    }
}
