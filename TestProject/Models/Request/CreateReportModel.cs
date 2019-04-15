using System.ComponentModel.DataAnnotations;

namespace TestProject.Models.Request
{
    public class CreateReportModel
    {
        [Required]
        public long GarageId { get; set; }

        [Required]
        public string Notes { get; set; }

        public string CreatedFrom { get; set; }

        [Required]
        public string ReportTimePeriod { get; set; }
    }
}
