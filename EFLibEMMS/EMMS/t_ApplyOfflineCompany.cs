namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ApplyOfflineCompany
    {
        [Key]
        [StringLength(32)]
        public string ApplyListID { get; set; }

        [StringLength(32)]
        public string ApplyID { get; set; }

        [StringLength(32)]
        public string ComName_En { get; set; }

        [StringLength(32)]
        public string ComName_Cn { get; set; }

        [StringLength(32)]
        public string Tel { get; set; }

        public virtual t_ApplySouch t_ApplySouch { get; set; }
    }
}
