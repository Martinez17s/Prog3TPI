using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
        }
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(p => p.UserName == userName);
        }
        public async Task<Professor> GetProfessorByIdAsync(int professorId, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Professors.FindAsync(new object[] { professorId }, cancellationToken);
        }
        public async Task<Client> GetClientByIdAsync(int clientId, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Clients.FindAsync(new object[] { clientId }, cancellationToken);
        }
    }
}
