namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_TaskAutoGroup
    {
        [Key]
        [StringLength(32)]
        public string TaskGroupID { get; set; }

        [Required]
        [StringLength(32)]
        public string TaskID { get; set; }

        [StringLength(16)]
        public string GroupName { get; set; }

        public virtual t_TaskAutoMonitoring t_TaskAutoMonitoring { get; set; }
    }
}
