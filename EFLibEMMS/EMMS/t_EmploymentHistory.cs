namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_EmploymentHistory
    {
        [Key]
        [StringLength(32)]
        public string Employmentid { get; set; }

        public long? Entityid { get; set; }

        [StringLength(64)]
        public string Employer { get; set; }

        [StringLength(32)]
        public string Department { get; set; }

        [StringLength(32)]
        public string Position { get; set; }

        [StringLength(32)]
        public string LenghtServices { get; set; }

        [StringLength(128)]
        public string OfficeAddress { get; set; }

        public virtual s_Person s_Person { get; set; }
    }
}
