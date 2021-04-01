using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common
{
    public abstract class AuditableBaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public string CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? LastModified { get; set; }

        [Description("XÓA LOGIC 0: CHƯA XÓA _ 1: ĐÃ XÓA")]
        public bool IsDelete { get; set; }
    }
}
