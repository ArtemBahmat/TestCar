using System.Collections.Generic;
using TestProject.Services.Models;

namespace TestProject.Services
{
    public interface IReportService: IBaseService<Report>
    {
        List<Area> GetAreas();

        Dictionary<string, List<Report>> GetReportsByArea(long areaId);
    }
}
