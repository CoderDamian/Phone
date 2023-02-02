using Microsoft.AspNetCore.Mvc;
using MyPhone.ApplicationService.Contracts;
using MyPhone.DTO.DTOs;

namespace MyPhone.RESTful.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            this._personService = personService;
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDTO>> Get()
        {
            return await _personService.GetAll().ConfigureAwait(false);
        }

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetByID(int ID)
        {
            try
            {
                PersonDTO personDTO = await _personService.GetByID(ID).ConfigureAwait(false);

                if (personDTO == null)
                    return BadRequest();

                return Ok(personDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            await _personService.Delete(ID).ConfigureAwait(false);

            await _personService.SaveAsync().ConfigureAwait(false);

            return Accepted();
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody]PersonCreateDTO personDTO)
        {
            if (personDTO == null)
                throw new NullReferenceException(nameof(personDTO));

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _personService.Add(personDTO).ConfigureAwait(false);

                await _personService.SaveAsync().ConfigureAwait(false);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("{ID}")]
        public async Task<IActionResult> Update([FromBody] PersonUpdateDTO personDTO, int ID)
        {
            if (personDTO == null)
                throw new NullReferenceException(nameof(personDTO));

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _personService.Update(ID, personDTO).ConfigureAwait(false);

                await _personService.SaveAsync().ConfigureAwait(false);

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