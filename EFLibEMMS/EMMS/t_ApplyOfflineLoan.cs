namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ApplyOfflineLoan
    {
        [Key]
        [StringLength(32)]
        public string ApplyListID { get; set; }

        [StringLength(32)]
        public string ApplyID { get; set; }

        [StringLength(32)]
        public string FullName_En { get; set; }

        [StringLength(32)]
        public string FullName_Cn { get; set; }

        [StringLength(32)]
        public string NumberID { get; set; }

        public virtual t_ApplySouch t_ApplySouch { get; set; }
    }
}
