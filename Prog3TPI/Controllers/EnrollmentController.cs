using Application.DTOs.Requests;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoP3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EnrollmentController : ControllerBase
    {

        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("CreateEnrollment")]
        [Authorize(Policy = "ClientPolicyOrAdminPolicy")]
        public async Task<ActionResult<EnrollmentDto>> CreateEnrollment([FromBody] EnrollmentCreateRequest request)
        {
            return Ok(await _enrollmentService.CreateAsync(request));
        }


        [HttpGet("GetEnrollment/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> GetEnrollment([FromRoute] int id)
        {
            try
            {
                return Ok(await _enrollmentService.GetEnrollmentAsync(id));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("GetAllEnrollment")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<List<EnrollmentDto>>> GetAllEnrollment()
        {
            return Ok(await _enrollmentService.GetAllAsync());
        }

        [HttpPut("UpdateEnrollment/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<EnrollmentDto>> UpdateEnrollment([FromBody] EnrollmentDto enrollmentDto, int id)
        {
            try
            {
                return Ok(await _enrollmentService.UpdateAsync(enrollmentDto, id));
            }
            catch (Exception ex)
            {
                return NotFound($"{ex.Message}");
            }
        }

        [HttpDelete("DeleteEnrollment/{id}")]
        [Authorize(Policy = "ClientPolicyOrAdminPolicy")]
        public async Task<ActionResult> DeleteEnrollment([FromRoute] int id)
        {
            try
            {
                await _enrollmentService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound($"{ex.Message}");
            }
        }
    }
}
