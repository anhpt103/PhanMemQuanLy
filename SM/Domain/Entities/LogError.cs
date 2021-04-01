using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class LogError
    {
        [Key]
        public long Id { get; set; }
        public string LogContent { get; set; }

        [StringLength(50)]
        public string ProcessContent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
    }
}
