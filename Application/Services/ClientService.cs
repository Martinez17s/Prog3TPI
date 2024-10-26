using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientService;
        public ClientService(IClientRepository clientService)
        {
            _clientService = clientService;
        }

        public async Task<List<SubjectDto>> GetClientSubjects(int clientId)
        {
            var subjects = _clientService.GetClientSubjects(clientId);
            var subjectsDto = new List<SubjectDto>();
            foreach (var subject in subjectsDto)
            {
                var activityDto = new SubjectDto()
                {
                    Title = subject.Title,
                    Description = subject.Description,
                    ProfessorId = subject.ProfessorId,
                };
                subjectsDto.Add(activityDto);
            }
            return subjectsDto;
        }
    }
}
