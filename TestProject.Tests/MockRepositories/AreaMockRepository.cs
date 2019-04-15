using Moq;
using TestProject.Data;
using TestProject.Data.Entities;
using TestProject.Repositories;
using TestProject.Tests.Common;

namespace TestProject.Tests.MockRepositories
{
    public class AreaMockRepository : MockRepository<AreaEntity, AreaRepository>
    {
        public AreaMockRepository(bool callBase = true)
        {
            var dbContext = new Mock<CarDbContext>().Object;
            MockRepo = new Mock<AreaRepository>(dbContext);
            QueryableCollection = Constants.AreaConstants.GetMockCollection();
            Setup();
            MockRepo.CallBase = callBase;
        }

        protected sealed override void Setup()
        {
            base.Setup();

            // Setup additional methods of AreaRepository if any
        }
    }
}
