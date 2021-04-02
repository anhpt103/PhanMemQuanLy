using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Master : AuditableBaseEntity
    {
        // Identity for Masters. 
        [Required]
        public int TypeMasters { get; set; }

        [StringLength(50)]
        [Required]
        public string Key { get; set; }

        [StringLength(500)]
        [Required]
        public string Value { get; set; }

        public long? Parent { get; set; }

        [StringLength(250)]
        public string Describe { get; set; }
    }
}
