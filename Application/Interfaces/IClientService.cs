using Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<List<SubjectEnrollmentDto>> GetClientSubjects(int clientId); // Cambia SubjectDto por SubjectEnrollmentDto
    }
}
