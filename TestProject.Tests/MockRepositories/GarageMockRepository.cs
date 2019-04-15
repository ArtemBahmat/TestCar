using Moq;
using TestProject.Data;
using TestProject.Data.Entities;
using TestProject.Repositories;
using TestProject.Tests.Common;

namespace TestProject.Tests.MockRepositories
{
    public class GarageMockRepository : MockRepository<GarageEntity, GarageRepository>
    {
        public GarageMockRepository(bool callBase = true)
        {
            var dbContext = new Mock<CarDbContext>().Object;
            MockRepo = new Mock<GarageRepository>(dbContext);
            QueryableCollection = Constants.GarageConstants.GetMockCollection();
            Setup();
            MockRepo.CallBase = callBase;
        }

        protected sealed override void Setup()
        {
            base.Setup();

            // Setup additional methods of GarageRepository if any
        }
    }
}
