
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEnrollmentRepository : IBaseRepository<Enrollment>
    {
        Task<Enrollment> GetByIdWithDetailsAsync(int id);
        Task<List<Enrollment>> GetAllWithDetailsAsync();
    }
}
