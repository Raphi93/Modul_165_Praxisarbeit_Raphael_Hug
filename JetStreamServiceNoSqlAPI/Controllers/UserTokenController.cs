using JetStreamServiceNoSqlAPI.Models;
using JetStreamServiceNoSqlAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetStreamServiceNoSqlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        #region Prop und Kunst
        public List<User> Users { get; set; } = new List<User>();
        private readonly IJwtService _jwtService;
        private readonly ILogger<UserTokenController> _logger;

        public UserTokenController(IJwtService jwtservice, ILogger<UserTokenController> logger)
        {
            _jwtService = jwtservice;
            _logger = logger;
        }
        #endregion

        #region Login
        /// <summary>
        /// Gibt den JWT-Token
        /// </summary>
        /// IStatusService GettAll
        /// <param name="user">Name und Passwort</param>
        /// <returns>Token</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] User user)
        {
            try
            {
                Users = _jwtService.Login();

                foreach (User key in Users)
                {
                    if (user.Name == key.Name && user.Password == key.Password)
                    {
                        return new JsonResult(new { token = _jwtService.CreateToken(user.Name) });
                    }
                    else
                    {
                        return Unauthorized("Invalid Credentials");
                    }
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }
        #endregion
    }
}
