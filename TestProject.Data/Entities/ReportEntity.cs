using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TestProject.Data.Entities
{
    public class ReportEntity: BaseEntity
    {
        private ILazyLoader LazyLoader { get; set; }
        private GarageEntity _garage;

        public ReportEntity() { }

        public ReportEntity(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        public string Notes { get; set; }

        public string ReportTimePeriod { get; set; }

        [ForeignKey(nameof(Garage))]
        public long GarageId { get; set; }

        public virtual GarageEntity Garage
        {
            get => LazyLoader.Load(this, ref _garage);
            set => _garage = value;
        }
    }
}
