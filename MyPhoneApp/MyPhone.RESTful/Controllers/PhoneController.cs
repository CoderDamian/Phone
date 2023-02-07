using Microsoft.AspNetCore.Mvc;
using MyPhone.ApplicationService.Contracts;
using MyPhone.DTO.DTOs;
using System.Linq.Expressions;

namespace MyPhone.RESTful.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : ControllerBase
    {
        private readonly ILogger<PhoneController> _logger;
        private readonly IPhoneService _phoneService;

        public PhoneController(ILogger<PhoneController> logger, IPhoneService phoneService)
        {
            this._logger = logger;
            this._phoneService = phoneService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _phoneService.Delete(id).ConfigureAwait(false);

                await _phoneService.SaveAsync();

                return Accepted();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<PhoneDTO>? phonesDTO;

                phonesDTO = _phoneService.GetPhonesWithOwner();

                if (!phonesDTO.Any())
                    return BadRequest();

                return Ok(phonesDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                PhoneDTO phoneDTO = await _phoneService.GetByID(id).ConfigureAwait(false);

                return Ok(phoneDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] PhoneCreateDTO phoneDTO)
        {
            try
            {
                await _phoneService.Add(phoneDTO).ConfigureAwait(false);

                await _phoneService.SaveAsync().ConfigureAwait(false);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]PhoneUpdateDTO phoneDTO, int id)
        {
            if (phoneDTO == null)
                throw new NullReferenceException(nameof(phoneDTO));

            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _phoneService.Update(id, phoneDTO).ConfigureAwait(false);

                await _phoneService.SaveAsync().ConfigureAwait(false);

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
