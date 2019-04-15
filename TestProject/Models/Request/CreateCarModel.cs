using System.ComponentModel.DataAnnotations;

namespace TestProject.Models.Request
{
    public class CreateCarModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ObjectStatus { get; set; }

        [Required]
        public long GarageId { get; set; }

        [Required]
        public long CategoryId { get; set; }

        public string CreatedFrom { get; set; }
    }
}
