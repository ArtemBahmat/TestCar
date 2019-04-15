using System.Collections.Generic;

namespace TestProject.Services.Models
{
    public class Report: BaseModel
    {
        public string Notes { get; set; }

        public string ReportTimePeriod { get; set; }

        public long? GarageId { get; set; }

        public List<Car> Cars { get; set; }
    }
}
