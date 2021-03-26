using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SM.Entity.Model.System
{
    public class LogHistory
    {
        [Key]
        public long Id { get; set; }
        public string LogContent { get; set; }

        [StringLength(16)]
        public string IP { get; set; }

        [StringLength(32)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string Functional { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
    }
}
