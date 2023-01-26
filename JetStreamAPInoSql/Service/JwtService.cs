using JetStreamAPInoSql.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JetStreamAPInoSql.Service
{
    public class JwtService : IJwtService
    {
        #region Prop und Kunstruktor
        private readonly IMongoCollection<User> _user;
        private readonly SymmetricSecurityKey _key;
        private readonly ILogger<JwtService> _logger;

        public JwtService(IConfiguration config, IOptions<SkiServiceJetStreamDatabaseSetting> jetStreamDatabaseSettings, ILogger<JwtService> logger)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var mongoClient = new MongoClient(
            jetStreamDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                jetStreamDatabaseSettings.Value.DatabaseName);

            _user = mongoDatabase.GetCollection<User>(
                jetStreamDatabaseSettings.Value.UserCollectionName);
            _logger = logger;
        }
        #endregion

        #region Create Token
        public string CreateToken(string username)
        {
            try
            {
                //Creating Claims. You can add more information in these claims. For example email id.
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, username)
                };

                //Creating credentials. Specifying which type of Security Algorithm we are using
                var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

                //Creating Token description
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                //Finally returning the created token
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Login
        public List<User> Login()
        {
            try
            {
                return _user.Find(_ => true).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                throw new Exception(ex.Message);
                Console.WriteLine(ex.Message, ex);
            }
        }
        #endregion

    }
}
