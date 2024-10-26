using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : BaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _appDbContext;
        public EfRepository(ApplicationDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
