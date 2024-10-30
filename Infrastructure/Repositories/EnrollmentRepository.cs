
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Enrollment> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Enrollments
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(e => e.EnrollmentId == id);
        }

        public async Task<List<Enrollment>> GetAllWithDetailsAsync()
        {
            return await _context.Enrollments
                .Include(e => e.Subject)
                .ToListAsync();
        }
    }
}
