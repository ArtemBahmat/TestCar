using TestProject.Data;
using TestProject.Data.Entities;

namespace TestProject.Repositories
{
    public class CarCategoryRepository: BaseRepository<CarCategoryEntity>, ICarCategoryRepository
    {
        public CarCategoryRepository(CarDbContext dbContext) : base(dbContext)
        {

        }
    }
}
