using System;

namespace TestProject.Data.Entities
{
    public class BaseEntity : IIdentifiedEntity
    {
        public long Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string CreatedFrom { get; set; }

        public string ModifiedFrom { get; set; }

        public long? ModifiedRevCounter { get; set; }
    }
}
