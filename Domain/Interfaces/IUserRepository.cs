using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUserNameAsync(string userName);
        Task<Professor> GetProfessorByIdAsync(int professorId, CancellationToken cancellationToken = default);
        Task<Client> GetClientByIdAsync(int clientId, CancellationToken cancellationToken = default);
    }
}
