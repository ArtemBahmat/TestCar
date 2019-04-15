using System.ComponentModel.DataAnnotations;

namespace TestProject.Models.Request
{
    public class UpdateCarModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ObjectStatus { get; set; }

        public long? GarageId { get; set; }

        public long? CategoryId { get; set; }
    }
}
