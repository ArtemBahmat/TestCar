namespace TestProject.Services.Models
{
    public class Car: BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ObjectStatus { get; set; } // todo enum??

        public long? GarageId { get; set; }
        
        public long? CategoryId { get; set; }
    }
}
