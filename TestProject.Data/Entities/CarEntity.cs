using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Data.Entities
{
    public class CarEntity : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ObjectStatus { get; set; }
     
        public DateTime? TimeStamp { get; set; }

        [ForeignKey(nameof(Garage))]
        public long GarageId { get; set; }

        public virtual GarageEntity Garage { get; set; }

        [ForeignKey(nameof(Category))]
        public long CategoryId { get; set; }

        public virtual CarCategoryEntity Category { get; set; }

        [ForeignKey(nameof(CarImpactClass))]
        public long? ImpactClass_Index { get; set; }
        
        public virtual  CarImpactClassEntity CarImpactClass { get; set; }

        [ForeignKey(nameof(CarProbabilityClass))]
        public long? ProbabilityClass_Index { get; set; }

        public virtual  CarProbabilityClassEntity CarProbabilityClass { get; set; }
    }
}
