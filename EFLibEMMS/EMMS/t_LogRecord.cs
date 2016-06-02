namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_LogRecord
    {
        [Key]
        [StringLength(32)]
        public string LogID { get; set; }

        public int Type { get; set; }

        [StringLength(32)]
        public string MemberID { get; set; }

        [StringLength(32)]
        public string UserID { get; set; }

        [StringLength(32)]
        public string Form { get; set; }

        public int? OperateType { get; set; }

        [StringLength(256)]
        public string Content { get; set; }

        public DateTime AddDateTime { get; set; }

        public virtual m_Member m_Member { get; set; }

        public virtual m_User m_User { get; set; }
    }
}
