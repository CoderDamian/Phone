using Microsoft.AspNetCore.Mvc;
using MyPhone.ApplicationService.Contracts;
using MyPhone.ApplicationService.DTOs;

namespace MyPhone.RESTful.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            this._personService = personService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<PersonDTO>> Get()
        {
            return await _personService.GetAll().ConfigureAwait(false);
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            await _personService.Delete(ID).ConfigureAwait(false);

            return Accepted();
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromQuery]PersonCreateDTO personDTO)
        {
            if (personDTO == null)
                throw new NullReferenceException(nameof(personDTO));

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _personService.Add(personDTO).ConfigureAwait(false);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("{ID}")]
        public async Task<IActionResult> Update([FromQuery] PersonUpdateDTO personDTO, int ID)
        {
            if (personDTO == null)
                throw new NullReferenceException(nameof(personDTO));

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _personService.Update(ID, personDTO).ConfigureAwait(false);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}