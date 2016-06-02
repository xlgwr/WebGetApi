namespace EFLibEMMS.EMMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class m_TableField
    {
        [Key]
        [StringLength(32)]
        public string FieldID { get; set; }

        [StringLength(32)]
        public string NewTable { get; set; }

        [StringLength(32)]
        public string NewField { get; set; }

        [StringLength(32)]
        public string OldTable { get; set; }

        [StringLength(32)]
        public string OldField { get; set; }

        [StringLength(32)]
        public string LanguageCode { get; set; }

        [StringLength(256)]
        public string Remark { get; set; }
    }
}
