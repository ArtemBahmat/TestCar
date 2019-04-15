using System;

namespace TestProject.Services.Models
{
    public class BaseModel
    {
        public long Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string CreatedFrom { get; set; }

        public string ModifiedFrom { get; set; }

        public long? ModifiedRevCounter { get; set; }
    }
}
