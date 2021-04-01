using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Image
    {
        [Key]
        public virtual long Id { get; set; }

        [StringLength(200)]
        public string ImageTitle { get; set; }

        public byte[] ImageData { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
    }
}
