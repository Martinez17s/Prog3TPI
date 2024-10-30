using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
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
        var subjects = await Task.FromResult(_clientService.GetClientSubjects(clientId));
        var subjectsDto = new List<SubjectDto>();
        
        foreach (var subject in subjects)
        {
            var subjectDto = new SubjectDto()
            {
                SubjectId = subject.SubjectId,
                Title = subject.Title,
                Description = subject.Description,
                ProfessorId = subject.ProfessorId
            };
            subjectsDto.Add(subjectDto);
        }
        return subjectsDto;
    }
}
}
