namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class s_Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public s_Person()
        {
            t_Directors = new HashSet<t_Directors>();
            t_Education = new HashSet<t_Education>();
            t_EmploymentHistory = new HashSet<t_EmploymentHistory>();
            t_Judge = new HashSet<t_Judge>();
            t_Shareholders = new HashSet<t_Shareholders>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Entityid { get; set; }

        [StringLength(32)]
        public string FullName_En { get; set; }

        [StringLength(32)]
        public string FullName_Cn { get; set; }

        [StringLength(16)]
        public string Surname { get; set; }

        [StringLength(16)]
        public string GivenNames { get; set; }

        [StringLength(16)]
        public string Alias_En { get; set; }

        [StringLength(16)]
        public string Alias_Cn { get; set; }

        [StringLength(16)]
        public string Nickname { get; set; }

        public int? Gender { get; set; }

        public DateTime? Birthdate { get; set; }

        public int? MaritalStatus { get; set; }

        [StringLength(32)]
        public string ChineseCode { get; set; }

        [StringLength(32)]
        public string Nationality { get; set; }

        [StringLength(32)]
        public string PlaceBirth { get; set; }

        public int? Show { get; set; }

        [StringLength(32)]
        public string DataGradeID { get; set; }

        public virtual s_Entity s_Entity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Directors> t_Directors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Education> t_Education { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_EmploymentHistory> t_EmploymentHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Judge> t_Judge { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_Shareholders> t_Shareholders { get; set; }
    }
}
