using Domain.Entites;
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
            var client = _appDbContext.Clients
                        .Include(c => c.Enrollments)
                        .ThenInclude(a => a.Subject)
                        .SingleOrDefault(c => c.Id == clientId);

            if (client == null)
                throw new KeyNotFoundException($"Client with ID {clientId} not found.");
            return client.Enrollments.Select(e => e.Subject).ToList();
        }

    }
}
