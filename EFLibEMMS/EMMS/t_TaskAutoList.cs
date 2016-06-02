namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_TaskAutoList
    {
        [Key]
        [StringLength(32)]
        public string TaskListID { get; set; }

        [Required]
        [StringLength(32)]
        public string TaskID { get; set; }

        [Required]
        [StringLength(32)]
        public string TaskGroupID { get; set; }

        public int? ComOrPerson { get; set; }

        [StringLength(64)]
        public string Name_En { get; set; }

        [StringLength(64)]
        public string Name_Cn { get; set; }

        [StringLength(256)]
        public string Reference { get; set; }
    }
}
