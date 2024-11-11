using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<SubjectEnrollmentDto>> GetClientSubjects(int clientId)
        {
            var enrollments = await _clientRepository.GetClientEnrollments(clientId);
            var subjectsDto = new List<SubjectEnrollmentDto>();

            foreach (var enrollment in enrollments)
            {
                var subjectDto = new SubjectEnrollmentDto()
                {
                    EnrollmentId = enrollment.EnrollmentId, // Incluye el EnrollmentId
                    SubjectId = enrollment.Subject.SubjectId,
                    Title = enrollment.Subject.Title,
                    Description = enrollment.Subject.Description,
                    ProfessorId = enrollment.Subject.ProfessorId
                };
                subjectsDto.Add(subjectDto);
            }
            return subjectsDto;
        }
    }
}
