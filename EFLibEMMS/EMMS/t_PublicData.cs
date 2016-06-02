namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_PublicData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_PublicData()
        {
            t_PublicRelation = new HashSet<t_PublicRelation>();
        }

        [Key]
        [StringLength(32)]
        public string PublicID { get; set; }

        [Required]
        [StringLength(32)]
        public string Entityid { get; set; }

        [Required]
        [StringLength(64)]
        public string PName { get; set; }

        [StringLength(32)]
        public string Tel { get; set; }

        [StringLength(32)]
        public string Fax { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(128)]
        public string Address { get; set; }

        [StringLength(64)]
        public string WebSite { get; set; }

        [StringLength(32)]
        public string param1 { get; set; }

        [StringLength(32)]
        public string param2 { get; set; }

        [StringLength(32)]
        public string param3 { get; set; }

        [StringLength(32)]
        public string param4 { get; set; }

        [StringLength(32)]
        public string param5 { get; set; }

        [StringLength(32)]
        public string param6 { get; set; }

        [StringLength(32)]
        public string param7 { get; set; }

        [StringLength(32)]
        public string param8 { get; set; }

        [StringLength(32)]
        public string param9 { get; set; }

        [StringLength(32)]
        public string param10 { get; set; }

        [StringLength(32)]
        public string param11 { get; set; }

        [StringLength(32)]
        public string param12 { get; set; }

        [StringLength(32)]
        public string param13 { get; set; }

        [StringLength(32)]
        public string param14 { get; set; }

        [StringLength(32)]
        public string param15 { get; set; }

        public int? Show { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_PublicRelation> t_PublicRelation { get; set; }
    }
}
