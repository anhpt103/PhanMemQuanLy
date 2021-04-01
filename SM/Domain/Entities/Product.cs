using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product : AuditableBaseEntity
    {
        [StringLength(200)]
        public string Name { get; set; }

        public int IndustryId { get; set; }
        public int KindOfMerId { get; set; }
        public int GroupOfMerId { get; set; }
        public int SupplierId { get; set; }
        public int? ShelvesId { get; set; }
        public int? PackingId { get; set; }
        public int? TaxInId { get; set; }
        public int? TaxOutId { get; set; }
        public int? ImageId { get; set; }

        [StringLength(500)]
        public string Barcode { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
    }
}
