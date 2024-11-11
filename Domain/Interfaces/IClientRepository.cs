using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Enrollment>> GetClientEnrollments(int clientId); // Método para obtener las inscripciones
    }
}