using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;

public class ProfessorService : IProfessorService
{
    private readonly IUserRepository _userRepository;
    private readonly IProfessorRepository _professorRepository; // Agregar esto

    public ProfessorService(
        IUserRepository userRepository,
        IProfessorRepository professorRepository) // Modificar el constructor
    {
        _userRepository = userRepository;
        _professorRepository = professorRepository;
    }

    public async Task<List<ClientDto>> GetClientsEnrolledInMySubjects(int professorId)
    {
        try
        {
            var clients = _professorRepository.GetClientsEnrolledInMySubjects(professorId);

            return clients.Select(c => new ClientDto
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                UserName = c.UserName
            }).ToList();
        }
        catch (KeyNotFoundException ex)
        {
            // Log the exception
            throw;
        }
        catch (Exception ex)
        {
            // Log the exception
            throw new Exception($"Error getting clients: {ex.Message}", ex);
        }
    }
}


