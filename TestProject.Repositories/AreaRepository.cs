using TestProject.Data;
using TestProject.Data.Entities;

namespace TestProject.Repositories
{
    public class AreaRepository: BaseRepository<AreaEntity>, IAreaRepository
    {
        public AreaRepository(CarDbContext dbContext) : base(dbContext)
        {

        }
    }
}
