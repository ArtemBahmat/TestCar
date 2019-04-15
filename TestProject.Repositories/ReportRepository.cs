using TestProject.Data;
using TestProject.Data.Entities;

namespace TestProject.Repositories
{
    public class ReportRepository: BaseRepository<ReportEntity>, IReportRepository
    {
        public ReportRepository(CarDbContext dbContext): base(dbContext) { }
    }
}
