using JetStreamServiceNoSqlAPI.Models;

namespace JetStreamServiceNoSqlAPI.Service
{
    public interface IJwtService
    {
        string CreateToken(string username);
        List<User> Login();
    }
}
