namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ApplyOfflineCase
    {
        [Key]
        [StringLength(32)]
        public string ApplyListID { get; set; }

        [StringLength(32)]
        public string ApplyID { get; set; }

        public int? AgeLimit { get; set; }

        [StringLength(32)]
        public string ComOrPerson { get; set; }

        [StringLength(32)]
        public string ComName_En { get; set; }

        [StringLength(32)]
        public string ComName_Cn { get; set; }

        [StringLength(32)]
        public string P_PerName_En { get; set; }

        [StringLength(32)]
        public string P_PerNmae_Cn { get; set; }

        [StringLength(32)]
        public string D_PerNmae_En { get; set; }

        [StringLength(32)]
        public string D_PerNmae_Cn { get; set; }

        public virtual t_ApplySouch t_ApplySouch { get; set; }
    }
}
