using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;

public class ProfessorService : IProfessorService
{
    private readonly IProfessorRepository _professorRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IUserRepository _userRepository;

    public ProfessorService(IProfessorRepository professorRepository, ISubjectRepository subjectRepository)
    {
        _professorRepository = professorRepository;
        _subjectRepository = subjectRepository; // Asegúrate de que esta línea esté presente
    }

    

    public async Task<List<SubjectDto>> GetSubjectsByProfessorId(int professorId)
    {
        var subjects = await _subjectRepository.GetSubjectsByProfessorIdAsync(professorId);
        return subjects.Select(s => new SubjectDto
        {
            SubjectId = s.SubjectId,
            Title = s.Title,
            Description = s.Description,
            ProfessorId = s.ProfessorId
        }).ToList();
    }

    public async Task<List<ClientDto>> GetClientsEnrolledInMySubjects(int professorId)
    {
        // Llama al repositorio para obtener los clientes inscritos en las materias del profesor
        var clients = _professorRepository.GetClientsEnrolledInMySubjects(professorId);

        // Mapea los resultados a la lista de ClientDto
        return clients.Select(c => new ClientDto
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            UserName = c.UserName
        }).ToList();
    }
}


