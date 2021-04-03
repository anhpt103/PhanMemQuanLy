using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Identity.Models
{
    public class DbOption
    {
        [Key]
        public virtual int Id { get; set; }
        public int TypeMasters { get; set; }

        [StringLength(5)]
        public string ValueMapping { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
    }
}
