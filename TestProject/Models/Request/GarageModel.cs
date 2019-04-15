using System;

namespace TestProject.Models.Request
{
    public class GarageModel
    {
        public string Name { get; set; }

        public long? AreaId { get; set; }

        public long GarageTypeId { get; set; }

        public DateTime? TimeStamp { get; set; }
    }
}
