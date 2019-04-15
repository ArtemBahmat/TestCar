using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Data.Entities
{
    public class IdentifiedNameValueEntity : IIdentifiedEntity
    {
        [Key]
        [Column("Index")]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
