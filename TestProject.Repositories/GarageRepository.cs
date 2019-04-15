using TestProject.Data;
using TestProject.Data.Entities;

namespace TestProject.Repositories
{
    public class GarageRepository : BaseRepository<GarageEntity>, IGarageRepository
    {
        public GarageRepository(CarDbContext context): base(context)
        { }
    }
}
