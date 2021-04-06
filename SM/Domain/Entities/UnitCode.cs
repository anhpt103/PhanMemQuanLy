using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UnitCode
    {
        [Key]
        [StringLength(3)]
        [Required]
        public virtual string Id { get; set; }

        [StringLength(150)]
        [Required]
        public string Name { get; set; }

        [StringLength(3)]
        public string Parent { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(150)]
        public string Describe { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        [Description("XÓA LOGIC 0: CHƯA XÓA _ 1: ĐÃ XÓA")]
        public bool IsDelete { get; set; }
    }
}
