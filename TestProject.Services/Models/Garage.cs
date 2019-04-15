using System;
using System.Collections.Generic;

namespace TestProject.Services.Models
{
    public class Garage: BaseModel
    {
        public string Name { get; set; }
        
        public long? AreaId { get; set; }

        public long GarageTypeId { get; set; }

        public DateTime? TimeStamp { get; set; }

        public HashSet<Car> Cars { get; set; }
    }
}
