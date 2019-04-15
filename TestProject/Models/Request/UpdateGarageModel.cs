using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestProject.Services.Models;

namespace TestProject.Models.Request
{
    public class UpdateGarageModel
    {
        [Required]
        public long Id { get; set; }

        public string Name { get; set; }

        public long? AreaId { get; set; }

        [Required]
        public long GarageTypeId { get; set; }

        public DateTime? TimeStamp { get; set; }

        public HashSet<Car> Cars { get; set; }
    }
}
