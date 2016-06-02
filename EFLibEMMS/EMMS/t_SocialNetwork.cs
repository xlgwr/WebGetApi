namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_SocialNetwork
    {
        [Key]
        [StringLength(32)]
        public string SocialNetworkID { get; set; }

        public long? Entityid { get; set; }

        [StringLength(32)]
        public string NetName { get; set; }

        [StringLength(64)]
        public string URL { get; set; }

        [StringLength(32)]
        public string SocialNumber { get; set; }

        public DateTime? SocialDate { get; set; }

        [StringLength(64)]
        public string Pic { get; set; }

        public virtual s_Entity s_Entity { get; set; }
    }
}
