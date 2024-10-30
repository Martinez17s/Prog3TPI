using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ClientRepository : EfRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<Subject> GetClientSubjects(int clientId)
        {
            var subjects = _appDbContext.Enrollments
                        .Where(e => e.ClientId == clientId)
                        .Include(e => e.Subject)
                        .Select(e => e.Subject)
                        .ToList();

            if (!subjects.Any())
                throw new KeyNotFoundException($"No subjects found for client with ID {clientId}.");

            return subjects;
        }

    }
}
