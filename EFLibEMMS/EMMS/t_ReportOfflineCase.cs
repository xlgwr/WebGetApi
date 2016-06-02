namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ReportOfflineCase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_ReportOfflineCase()
        {
            t_ResultOfflineCase = new HashSet<t_ResultOfflineCase>();
        }

        [Key]
        [StringLength(32)]
        public string ReportID { get; set; }

        [Required]
        [StringLength(32)]
        public string MemberID { get; set; }

        [Required]
        [StringLength(32)]
        public string TaskID { get; set; }

        [StringLength(256)]
        public string Result { get; set; }

        [StringLength(32)]
        public string EmailID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_ResultOfflineCase> t_ResultOfflineCase { get; set; }

        public virtual t_TaskOfflineCase t_TaskOfflineCase { get; set; }
    }
}
