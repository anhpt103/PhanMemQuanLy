using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SM.Entity.Model
{
    public class IdentityModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdatedAt { get; set; }

        [StringLength(32)]
        public string CreatedBy { get; set; }

        [StringLength(32)]
        public string LastUpdatedBy { get; set; }

        [Required]
        [StringLength(2)]
        public string UnitCode { get; set; }
    }
}
