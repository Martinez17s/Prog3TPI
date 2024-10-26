using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;

public class ProfessorService : IProfessorService
{
    private readonly IUserRepository _userRepository;
    private readonly ISubjectRepository _subjectRepository;

    public ProfessorService(IUserRepository userRepository, ISubjectRepository subjectRepository)
    {
        _userRepository = userRepository;
        _subjectRepository = subjectRepository;
    }

    public async Task<List<ClientDto>> GetClientsEnrolledInMyActivities(int professorId)
    {
        var professor = await _userRepository.GetProfessorByIdAsync(professorId);

        if (professor == null)
        {
            throw new KeyNotFoundException($"Professor with ID {professorId} not found.");
        }

        var subjects = await _subjectRepository.GetSubjectsByProfessorIdAsync(professorId);
        var clients = subjects.SelectMany(a => a.Enrollments)
                                .Select(e => new ClientDto
                                {
                                    Id = e.Client.Id,
                                    Name = e.Client.Name,
                                    UserName = e.Client.UserName,
                                }).ToList();

        return clients;
    }

    public Task<List<ClientDto>> GetClientsEnrolledInMySubjects(int professorId)
    {
        throw new NotImplementedException();
    }
}


