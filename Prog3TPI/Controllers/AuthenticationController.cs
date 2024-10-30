using Application.DTOs.Requests;
using Application.Interfaces;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoP3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICustomAuthentication _customAuthentication;

        public AuthenticationController(IConfiguration configuration, ICustomAuthentication customAuthentication)
        {
            _configuration = configuration; 
            _customAuthentication = customAuthentication;
        }

        [HttpPost("Authenticate")]
        public async Task<ActionResult<string>> Authenticate([FromBody] AuthenticationRequest authenticationRequest)
        {
            try
            {
                string token = await _customAuthentication.AutenticarAsync(authenticationRequest);
                return Ok(token);
            }
            catch (NotAllowedException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
