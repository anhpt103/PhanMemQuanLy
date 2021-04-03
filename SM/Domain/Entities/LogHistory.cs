using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class LogHistory
    {
        [Key]
        public long Id { get; set; }

        [StringLength(2000)]
        public string LogContent { get; set; }

        [StringLength(30)]
        public string Functional { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
    }
}
