using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoP3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminPolicy")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserRequest request)
        {
            return Ok(await _userService.CreateAsync(request));
        }

        [HttpGet("GetUserbyId/{id}")]
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
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllAsync());
        }

        [HttpPut("UpdateUser/{id}")]
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
