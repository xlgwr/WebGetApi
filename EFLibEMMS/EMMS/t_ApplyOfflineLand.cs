namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_ApplyOfflineLand
    {
        [Key]
        [StringLength(32)]
        public string ApplyListID { get; set; }

        [StringLength(32)]
        public string ApplyID { get; set; }

        [StringLength(32)]
        public string RoomNO { get; set; }

        [StringLength(32)]
        public string Floor { get; set; }

        [StringLength(32)]
        public string Street { get; set; }

        public virtual t_ApplySouch t_ApplySouch { get; set; }
    }
}
