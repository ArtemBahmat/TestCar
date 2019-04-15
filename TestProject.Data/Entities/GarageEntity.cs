using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestProject.Data.Entities
{
    public class GarageEntity : BaseEntity
    {
        private ILazyLoader LazyLoader { get; set; }
        private ICollection<CarEntity> _cars;

        public GarageEntity() { }

        public GarageEntity(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
            Cars = new HashSet<CarEntity>();
            Reports = new HashSet<ReportEntity>();
        }

        public string Name { get; set; }

        [ForeignKey(nameof(Area))]
        public long AreaId { get; set; }

        public virtual AreaEntity Area { get; set; }

        public long GarageTypeId { get; set; }

        public DateTime? TimeStamp { get; set; }

        public HashSet<CarEntity> Cars
        {
            get => LazyLoader.Load(this, ref _cars ).ToHashSet();
            set => _cars = value;
        }

        public HashSet<ReportEntity> Reports { get; set; }
    }
}
