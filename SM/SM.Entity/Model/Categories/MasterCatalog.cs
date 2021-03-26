using System.ComponentModel.DataAnnotations;

namespace SM.Entity.Model.System
{
    public class MasterCatalog : IdentityModel
    {
        [Key]
        public int Id { get; set; }

        // Identity for catalog. 
        [Required]
        [StringLength(8)]
        public string TypeCatalog { get; set; }

        [StringLength(50)]
        [Required]
        public string Key { get; set; }

        [StringLength(250)]
        [Required]
        public string Value { get; set; }

        [StringLength(250)]
        public string Describe { get; set; }
    }
}
