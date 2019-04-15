using Moq;
using TestProject.Data;
using TestProject.Data.Entities;
using TestProject.Repositories;
using TestProject.Tests.Common;

namespace TestProject.Tests.MockRepositories
{
    public class CarMockRepository : MockRepository<CarEntity, CarRepository>
    {
        public CarMockRepository(bool callBase = true)
        {
            var dbContext = new Mock<CarDbContext>().Object;
            MockRepo = new Mock<CarRepository>(dbContext);
            QueryableCollection = Constants.CarConstants.GetMockCollection();
            Setup();
            MockRepo.CallBase = callBase;
        }

        protected sealed override void Setup()
        {
            base.Setup();

            // Setup additional methods of CarRepository if any
        }
    }
}
