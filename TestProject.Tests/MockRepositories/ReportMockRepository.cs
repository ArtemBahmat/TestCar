using Moq;
using TestProject.Data;
using TestProject.Data.Entities;
using TestProject.Repositories;
using TestProject.Tests.Common;

namespace TestProject.Tests.MockRepositories
{
    public class ReportMockRepository : MockRepository<ReportEntity, ReportRepository>
    {
        public ReportMockRepository(bool callBase = true)
        {
            var dbContext = new Mock<CarDbContext>().Object;
            MockRepo = new Mock<ReportRepository>(dbContext);
            QueryableCollection = Constants.ReportConstants.GetMockCollection();
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
