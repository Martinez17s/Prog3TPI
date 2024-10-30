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
    [Authorize(Policy = "AdminPolicy")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }


        [HttpPost("CreateSubject")]
        public async Task<ActionResult<SubjectDto>> CreateSubject([FromBody] SubjectCreateRequest request)
        {
            var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
                return Forbid();

            return Ok(await _subjectService.CreateAsync(request));
        }

        [HttpGet("GetSubject/{id}")]
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
        public async Task<ActionResult<List<SubjectDto>>> GetAllSubjects()
        {
            return Ok(await _subjectService.GetAllAsync());
        }

        [HttpPut("UpdateSubject/{id}")]
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