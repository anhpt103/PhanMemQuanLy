using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class MasterUnit
    {
        [ForeignKey("Master")]
        [Required]
        public int MasterId { get; set; }

        [Required]
        public int UnitCode { get; set; }
    }
}
