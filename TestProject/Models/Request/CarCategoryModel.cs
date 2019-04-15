using System;

namespace TestProject.Models.Request
{
    public class CarCategoryModel
    {
        public string Name { get; set; }

        public int? Ordinal { get; set; }

        public string ObjectStatus { get; set; }

        public DateTime? TimeStamp { get; set; }
    }
}
