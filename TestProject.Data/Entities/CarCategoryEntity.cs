using System;

namespace TestProject.Data.Entities
{
    public class CarCategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public int? Ordinal { get; set; }

        public string ObjectStatus { get; set; }

        public DateTime? TimeStamp { get; set; }
    }
}
