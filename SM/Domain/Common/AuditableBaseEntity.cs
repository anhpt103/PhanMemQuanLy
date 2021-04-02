using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        [Key]
        public virtual int Id { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }

        [Description("XÓA LOGIC 0: CHƯA XÓA _ 1: ĐÃ XÓA")]
        public bool IsDelete { get; set; }

        [StringLength(3)]
        [Required]
        public string UnitCode { get; set; }
    }
}
