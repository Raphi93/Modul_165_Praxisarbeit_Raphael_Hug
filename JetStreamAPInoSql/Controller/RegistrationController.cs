using JetStreamAPInoSql.Models;
using JetStreamAPInoSql.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JetStreamAPInoSql.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        #region Prop und Kunstruktor
        private IRegistrationServices _regService;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(IRegistrationServices reg, ILogger<RegistrationController> logger)
        {
            _regService = reg;
            _logger = logger;
        }
        #endregion

        #region GetAll und Get
        /// <summary>
        /// Alle Werte Aulessen Ausser "Gelöscht"
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler oder alle werte leer ist</exception>
        /// <returns>IRegistration GetAll</returns>
        [HttpGet]
        public ActionResult<List<Registration>> GetAll()
        {
            {
                try
                {
                    return _regService.GetAll();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured, {ex.Message}");
                    return NotFound($"Error occured");
                }
            }
        }

        /// <summary>
        /// Auslessen per id
        /// </summary>
        /// <param name="id">Id</param>
        ///<exception cref="Exception">Datenbank fehler oder Id noch nicht existriert</exception>
        /// <returns>IRegistration Get</returns>
        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Registration> Get(string id)
        {
            try
            {
                Registration register = _regService.Get(id);
                if (register == null)
                    return NotFound();
                return register;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// Post methde Hinzufügen der Daten
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler</exception>
        /// <param name="regDTO">RegistzrtionDTO</param>
        /// <returns>Die angaben wo man gemacht hat als return</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(Registration reg)
        {
            try
            {
                _regService.Add(reg);

                return CreatedAtAction(nameof(Get), new { id = reg._id }, reg);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Put methode ändern der daten
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler oder Id noch nicht existriert</exception>
        /// <param name="id">Id</param>
        /// <param name="regDTO">RegistzrtionDTO</param>
        /// <returns>Die angaben wo man gemacht hat als return</returns>
        [HttpPut("{id}")]
        public IActionResult Update(string id, Registration reg)
        {
            try
            {
                var order = _regService.Get(id);

                if (order is null)
                {
                    return NotFound();
                }

                reg._id = order._id;
                _regService.Update(id, reg);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }
        #endregion 

        #region Delete
        /// <summary>
        /// Delete Methode die den Status Gelöscht angibt
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler oder Id noch nicht existriert</exception>
        /// <param name="id">Id</param>
        /// <returns>Die angaben wo man gemacht hat als return</returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                Registration e = _regService.Get(id);
                if (e == null)
                    return NotFound();

                e.Status = "Gelöscht";

                _regService.Update(id, e);
                return CreatedAtAction(nameof(Create), new { id = id });
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
