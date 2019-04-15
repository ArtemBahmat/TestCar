using System;

namespace TestProject.Services.Models
{
   public class CarCategory : BaseModel
    {
        public string Name { get; set; }

        public int? Ordinal { get; set; }

        public string ObjectStatus { get; set; }

        public DateTime? TimeStamp { get; set; }
    }
}
