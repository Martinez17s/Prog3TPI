using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoP3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserRequest request)
        {
            return Ok(await _userService.CreateAsync(request));
        }

        [HttpGet("GetUserbyId/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> GetUserbyId([FromRoute] int id)
        {
            try
            {
                return Ok(await _userService.GetUserByIdAsync(id));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Policy = "ClientPolicyOrAdminPolicy")]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }

        
        [HttpPut("UpdateUser/{id}")]
        [Authorize(Policy = "ClientPolicyOrAdminPolicy")]
        public async Task<ActionResult<UserDto>> UpdateUser([FromBody] UpdateUserRequest request, int id)
        {
            try
            {
                return Ok(await _userService.UpdateAsync(request, id));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }

        }

        [HttpDelete("DeleteUser/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }

        }


    }
}
