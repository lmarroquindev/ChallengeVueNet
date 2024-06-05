using BackendChallenge.Core.Dtos.Input;
using BackendChallenge.Core.Dtos.Output;
using BackendChallenge.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BackendChallenge.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly ILogger<PermissionTypeController> _logger;
        private readonly IPermissionService _permissionService;
        public PermissionController(ILogger<PermissionTypeController> logger,
                                    IPermissionService permissionService)
        {
            _logger = logger;
            _permissionService = permissionService;
        }


        /// <summary>
        /// Retrieves a list of objects of type <see cref="PermissionOutputDto"/>.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PermissionOutputDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListAsync()
        {
            try
            {
                List<PermissionOutputDto> result = await _permissionService.GetListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(((ex.InnerException == null) ? $"StackTrace: {ex.StackTrace}" : $"Message: {ex.InnerException.Message}. StackTrace: {ex.InnerException.StackTrace}"));
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + ((ex.InnerException == null) ? "" : " InnerException:" + ex.InnerException.Message));
            }
        }

        /// <summary>
        /// Retrieves an object of type <see cref="PermissionOutputDto"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the permission.</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PermissionOutputDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            try
            {
                PermissionOutputDto result = await _permissionService.GetByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(((ex.InnerException == null) ? $"StackTrace: {ex.StackTrace}" : $"Message: {ex.InnerException.Message}. StackTrace: {ex.InnerException.StackTrace}"));
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + ((ex.InnerException == null) ? "" : " InnerException:" + ex.InnerException.Message));
            }
        }

        /// <summary>
        /// Creates a new Permission record in the database.
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PermissionOutputDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] PermissionCreateInputDto inputData)
        {
            try
            {
                PermissionOutputDto result = await _permissionService.CreateAsync(inputData);

                return CreatedAtRoute("GetAsync", new { id = result.Id }, result);
            }

            catch (Exception ex)
            {
                _logger.LogError(((ex.InnerException == null) ? $"StackTrace: {ex.StackTrace}" : $"Message: {ex.InnerException.Message}. StackTrace: {ex.InnerException.StackTrace}"));
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + ((ex.InnerException == null) ? "" : " InnerException:" + ex.InnerException.Message));
            }
        }

        /// <summary>
        /// Update an existing Permission record in the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PermissionOutputDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id,
                                                     [FromBody] PermissionUpdateInputDto inputData)
        {
            try
            {
                PermissionOutputDto result = await _permissionService.UpdateAsync(id, inputData);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(((ex.InnerException == null) ? $"StackTrace: {ex.StackTrace}" : $"Message: {ex.InnerException.Message}. StackTrace: {ex.InnerException.StackTrace}"));
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + ((ex.InnerException == null) ? "" : " InnerException:" + ex.InnerException.Message));
            }
        }

        /// <summary>
        /// Delete an existing Permission record from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _permissionService.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(((ex.InnerException == null) ? $"StackTrace: {ex.StackTrace}" : $"Message: {ex.InnerException.Message}. StackTrace: {ex.InnerException.StackTrace}"));
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + ((ex.InnerException == null) ? "" : " InnerException:" + ex.InnerException.Message));
            }
        }
    }
}
