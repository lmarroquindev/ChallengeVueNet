using BackendChallenge.Core.Dtos.Output;
using BackendChallenge.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly ILogger<PermissionTypeController> _logger;
        private readonly IPermissionTypeService _permissionTypeService;
        public PermissionTypeController(ILogger<PermissionTypeController> logger,
                                        IPermissionTypeService permissionTypeService)
        {
            _logger = logger;
            _permissionTypeService = permissionTypeService;
        }


        /// <summary>
        /// Retrieves a list of objects of type <see cref="PermissionTypeOutputDto"/>.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PermissionTypeOutputDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetListAsync()
        {
            try
            {
                List<PermissionTypeOutputDto> result = await _permissionTypeService.GetListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(((ex.InnerException == null) ? $"StackTrace: {ex.StackTrace}" : $"Message: {ex.InnerException.Message}. StackTrace: {ex.InnerException.StackTrace}"));
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + ((ex.InnerException == null) ? "" : " InnerException:" + ex.InnerException.Message));
            }
        }

        /// <summary>
        /// Retrieves an object of type <see cref="PermissionTypeOutputDto"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the permission type.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PermissionTypeOutputDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
        {
            try
            {
                PermissionTypeOutputDto result = await _permissionTypeService.GetByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(((ex.InnerException == null) ? $"StackTrace: {ex.StackTrace}" : $"Message: {ex.InnerException.Message}. StackTrace: {ex.InnerException.StackTrace}"));
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message + ((ex.InnerException == null) ? "" : " InnerException:" + ex.InnerException.Message));
            }
        }
    }
}
