using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SubjectRepository : EfRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<Subject>> GetSubjectsByProfessorIdAsync(int professorId, CancellationToken cancellationToken = default)
        {
            return await _appDbContext.Subjects
                .Where(subject => subject.ProfessorId == professorId)
                .ToListAsync(cancellationToken);
        }
    }
}
