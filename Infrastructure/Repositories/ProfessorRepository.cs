using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProfessorRepository : EfRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<User> GetClientsEnrolledInMySubjects(int professorId)
        {
            var professor = _appDbContext.Users
                .FirstOrDefault(p => p.Id == professorId && p.Role == UserRole.Professor);

            if (professor == null)
            {
                throw new KeyNotFoundException($"Professor with ID {professorId} not found.");
            }

            var subjects = _appDbContext.Subjects
                .Where(s => s.ProfessorId == professorId)
                .ToList();

            if (!subjects.Any())
            {
                throw new KeyNotFoundException($"Professor with ID {professorId} has no subjects assigned.");
            }

            var clients = _appDbContext.Users
                .Where(u => u.Role == UserRole.Client &&
                       _appDbContext.Enrollments.Any(e =>
                           subjects.Select(s => s.SubjectId).Contains(e.SubjectId) &&
                           e.ClientId == u.Id))
                .ToList();

            if (!clients.Any())
            {
                throw new KeyNotFoundException($"No clients found enrolled in subjects of professor with ID {professorId}.");
            }

            return clients;
        }
    }
}
