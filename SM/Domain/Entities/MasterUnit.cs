using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class MasterUnit
    {
        [ForeignKey("Master")]
        [Required]
        public long MasterId { get; set; }

        [StringLength(3)]
        [Required]
        public string UnitCode { get; set; }

        public virtual Master Master { get; set; }
    }
}
