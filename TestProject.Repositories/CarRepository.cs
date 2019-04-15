using TestProject.Data;
using TestProject.Data.Entities;

namespace TestProject.Repositories
{
    public class CarRepository : BaseRepository<CarEntity>, ICarRepository
    {
        public CarRepository(CarDbContext dbContext) : base(dbContext)
        {

        }
    }
}
