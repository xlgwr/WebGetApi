namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ReportOnlineLoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_ReportOnlineLoan()
        {
            t_ResultOnlineLand = new HashSet<t_ResultOnlineLand>();
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
        public virtual ICollection<t_ResultOnlineLand> t_ResultOnlineLand { get; set; }

        public virtual t_TaskOnlineLoan t_TaskOnlineLoan { get; set; }
    }
}
