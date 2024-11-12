using Application.DTOs.Requests;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ProyectoP3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }


        [HttpPost("CreateSubject")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<SubjectDto>> CreateSubject([FromBody] SubjectCreateRequest request)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();

            return Ok(await _subjectService.CreateAsync(request));
        }

        [HttpGet("GetSubject/{id}")]
        [Authorize(Policy = "ClientPolicyOrAdminPolicy")]
        public async Task<ActionResult> GetSubject([FromRoute] int id)
        {
            try
            {
                return Ok(await _subjectService.GetSubjectAsync(id));
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpGet("GetAllSubjects")]
        [Authorize(Policy = "ClientPolicyOrAdminPolicy")]
        public async Task<ActionResult<List<SubjectDto>>> GetAllSubjects()
        {
            return Ok(await _subjectService.GetAllAsync());
        }

        [HttpPut("UpdateSubject/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<SubjectDto>> UpdateSubject([FromBody] SubjectDto subjectDto, int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();

            try
            {
                return Ok(await _subjectService.UpdateAsync(subjectDto, id));
            }
            catch (Exception ex)
            {
                return NotFound($"{ex.Message}");
            }
        }

        [HttpDelete("DeleteSubject/{id}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult> DeleteSubject([FromRoute] int id)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();

            try
            {
                await _subjectService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound($"{ex.Message}");
            }
        }

    }
}