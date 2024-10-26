
using Domain.Entites;

namespace Domain.Interfaces
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Task<List<Subject>> GetSubjectsByProfessorIdAsync(int professorId, CancellationToken cancellationToken = default);
    }
}
