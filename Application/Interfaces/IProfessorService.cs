using Application.DTOs;

namespace Application.Interfaces
{
    public interface IProfessorService
    {
        Task<List<ClientDto>> GetClientsEnrolledInMySubjects(int professorId);
    }
}