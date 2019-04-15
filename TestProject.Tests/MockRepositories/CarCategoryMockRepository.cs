using Moq;
using TestProject.Data;
using TestProject.Data.Entities;
using TestProject.Repositories;
using TestProject.Tests.Common;

namespace TestProject.Tests.MockRepositories
{
    public class CarCategoryMockRepository : MockRepository<CarCategoryEntity, CarCategoryRepository>
    {
        public CarCategoryMockRepository(bool callBase = true)
        {
            var dbContext = new Mock<CarDbContext>().Object;
            MockRepo = new Mock<CarCategoryRepository>(dbContext);
            QueryableCollection = Constants.CarCategoryConstants.GetMockCollection();
            Setup();
            MockRepo.CallBase = callBase;
        }

        protected sealed override void Setup()
        {
            base.Setup();

            // Setup additional methods of CarCategoryRepository if any
        }
    }
}
