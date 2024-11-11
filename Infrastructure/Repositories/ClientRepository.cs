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

        public async Task<List<Enrollment>> GetClientEnrollments(int clientId)
        {
            return await _appDbContext.Enrollments
                .Include(e => e.Subject)
                .Where(e => e.ClientId == clientId)
                .ToListAsync();
        }
    }
}
